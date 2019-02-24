using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class koma : MonoBehaviour
{
   [SerializeField] private string komaname;

    Vector3 WorldKomaPos;
    [SerializeField] Vector2 LocalKomaPos;
    public Vector2 GetLocalKomaPos() { return LocalKomaPos; }

    [SerializeField] int Komakind; 
     public int GetKomakind() { return Komakind; }

    [SerializeField] int PorE; 
     public int GetPorE() { return PorE; }

    [SerializeField] bool[] ableMove = new bool[24];

    GameObject cont;
    ToChangePoint changePoint;
    Mapdata mapdata;
    KomaData komaData;

    [SerializeField] int RelativeAreaW;
   [SerializeField] int KomaAreacenterPoint;
    int komaAreacenterIndex;
   
    private const int komakindZERO = 0;

    private const int LONGRANGEKOMAKIND = 100;

   
    private void Start()
    {
        cont = GameObject.Find("GameCont");
        changePoint = cont.GetComponent<ToChangePoint>();
        mapdata = cont.GetComponent<Mapdata>();
        komaData = GetComponent<KomaData>();

        KomaAreacenterPoint = komaData.GetCenterPoint();
        RelativeAreaW = komaData.GetRelativeAreaWidth();
        komaAreacenterIndex = (RelativeAreaW * (KomaAreacenterPoint - 1)) + (KomaAreacenterPoint - 1);

       // ConstantSet();

        DataReset();
        WorldKomaPos = this.gameObject.transform.position;

        LocalKomaPos.x = changePoint.ToLocalPoint(WorldKomaPos.x);
        LocalKomaPos.y = changePoint.ToLocalPoint(WorldKomaPos.y);
        komaname = this.gameObject.name;
        PorE = komaData.PorESet(komaname);

        Komakind = komaData.KomakindSet(komaname);
        KomaMovableDataSet(Komakind);

    }

  
    private void DataReset() {
        this.Komakind = komakindZERO;
        this.PorE = 0;
        for (int k = 0; k < 24; k++)
        {
            ableMove[k] = false;
        }
    }

    public void SetLocalKomaPos(Vector2 lp)
    {
        LocalKomaPos.x = lp.x;
        LocalKomaPos.y = lp.y;
    }

    private void KomaMovableDataSet(int kind)
    {
        List<bool> ableMoveArea = komaData.komaMovableInfos[kind];
        for(int i = 0; i < ableMoveArea.Count; i++)
        {
            ableMove[i] = ableMoveArea[i];
        }

    }

    private Dictionary<int, int> RelativeValue = new Dictionary<int, int>
    {
        {0, -2},
        {1, -1},
        {2, 0},
        {3, 1},
        {4, 2},
    };


    /// <summary>
    /// Retern the relative matlix.
    /// (Vector2) result.zero is Frame point.
    /// 
    /// 駒の位置をゼロとした相対座標を返す関数
    /// </summary>
    /// <returns>The relative matlix.</returns>
    /// <param name="x">The x coordinate.</param>
    /// <param name="y">The y coordinate.</param>
    /// <param name="TP">turnprayer.</param>
    private Vector2 RetRelativeMatlix(int x, int y, int TP)
    {
        Vector2 result;
        result = Vector2.zero;
        result.x = RelativeValue[x];
        result.y = (-1) * RelativeValue[y];

        if (TP == 2) result = result * (-1);    //turnprayerが2の時は180度回転

        return result;
    }

    private Dictionary<int, Vector2> CalculationValue = new Dictionary<int, Vector2>
    {//<int, Vector2> == <indexnum, [x value, y value]>

        {0, new Vector2(-1f, 1f)},
        {2,new Vector2(0f,1f)},
        {4,new Vector2(1f, 1f)},
        {10,new Vector2(-1f,0f)},
        {13,new Vector2(1f, 0f)},
        {19, new Vector2(-1f, -1f)},
        {21,new Vector2(0f, -1f)},
        {23, new Vector2(1f, -1f)},

    };

    private List<int> LongRengeMoveIndexnum = new List<int>
    {
        0, 
        2,
        4,
        10,
        13,
        19,
        21,
        23,
    };


    private bool JudgmentFlg(Vector2 rela, int LPX, int LPY, int kind, int TP, int indexnum)
    {
        if (TP == 1 && (mapdata.map[LPX + (int)rela.x, LPY + (int)rela.y] > komakindZERO)){ return false; }else if(TP == 2 && (mapdata.map[LPX + (int)rela.x, LPY + (int)rela.y] < komakindZERO)) { return false; }

        //もしJUMPKOMAKINDが2種類以上になるなら、ここにfor文を追加
        if (kind == komaData.JUMPKOMAKINDLIST[0])
        {
            for(int k = 0; k < komaData.BLOCKKOMAKINDLIST.Count; k++)
            {
                int variable = 1;
                int bkkind = komaData.BLOCKKOMAKINDLIST[k];
                if (TP == 1) { bkkind = (-1) * bkkind; }else { variable = -1;  }
                if (mapdata.map[LPX, LPY + variable] == bkkind || mapdata.map[LPX, LPY + variable] == bkkind) { if (indexnum <= 4) return false; }
            }
        }
        //もしLONGRANGEKOMAKINDが2種類以上になるなら、ここにfor文を追加
        if (kind == LONGRANGEKOMAKIND)
        {
            for (int i = 0; i < LongRengeMoveIndexnum.Count; i++)
            {
                if (indexnum == LongRengeMoveIndexnum[i])
                {
                    Vector2 Cval = CalculationValue[indexnum];
                    if (TP == 2) Cval = (-1) * Cval;
                    if (mapdata.map[LPX + (int)Cval.x, LPY + (int)Cval.y] != komakindZERO) return false;
                }
            }
        }
        return true;
    }

  
    public void ShowMove(int kind, int TP)
    {
        mapdata = cont.GetComponent<Mapdata>();

        int indexnum;
        Vector2 rela;
            for(int y = 0; y < RelativeAreaW; y++)
            {
                for (int x = 0; x < RelativeAreaW; x++) {
                    bool showflg = true;

                    rela = RetRelativeMatlix(x, y, TP);
                    indexnum = (y * RelativeAreaW) + x;

                    if (indexnum == komaAreacenterIndex) continue;
                    if (indexnum >= komaAreacenterIndex + 1) indexnum--;
                                  
                    if (ableMove[indexnum] == true){
                        if (LocalKomaPos.y + rela.y >= mapdata.GetmapWidth()) continue;
                        if (LocalKomaPos.y + rela.y <= 0) continue;
                        if (LocalKomaPos.x + rela.x >= mapdata.GetmapWidth()) continue;
                        if (LocalKomaPos.x + rela.x <= 0) continue;

                       showflg = JudgmentFlg(rela, (int)LocalKomaPos.x, (int)LocalKomaPos.y, kind, TP, indexnum);

                        if (showflg == true)
                        {
                            transform.Find("select" + indexnum.ToString()).gameObject.SetActive(true);
                        }
                    } 
                }
            }

    }

    /// <summary>
    /// 打てる範囲を消す関数。
    /// </summary>
    /// <param name="komaobj">Komaobj.</param>

    public void InvisibleMove(GameObject komaobj)
    {
        foreach (Transform item in komaobj.transform)
        {
            item.gameObject.SetActive(false);
        }

    }

}
