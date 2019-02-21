using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class koma : MonoBehaviour
{
    Vector3 WorldKomaPos;
    [SerializeField] Vector2 LocalKomaPos;
    [SerializeField] int Komakind;
    [SerializeField] int PorE;
    [SerializeField] bool Junpflg;
    [SerializeField] bool blockflg;
    [SerializeField] bool[] ableMove = new bool[24];

    private bool selectnow;
    GameObject cont;
    ToChangePoint changePoint;
    Mapdata mapdata;


    private string[] komaname = new string[12];

    private List<int> BLOCKKOMAKIND = new List<int>
    {
        5,
        100,

    };

    private List<string> komaNames = new List<string>
    {
        "1yen1(Clone)",
        "5yen1(Clone)",
        "10yen1(Clone)",
        "50yen1(Clone)",
        "100yen1(Clone)",
        "500yen1(Clone)",
        "1yen2(Clone)",
        "5yen2(Clone)",
        "10yen2(Clone)",
        "50yen2(Clone)",
        "100yen2(Clone)",
        "500yen2(Clone)",

    };


    private void Start()
    {
        cont = GameObject.Find("GameCont");
        changePoint = cont.GetComponent<ToChangePoint>();
        mapdata = cont.GetComponent<Mapdata>();

        selectnow = false;
        DataReset();
        WorldKomaPos = this.gameObject.transform.position;

        LocalKomaPos.x = changePoint.ToLocalPoint(WorldKomaPos.x);
        LocalKomaPos.y = changePoint.ToLocalPoint(WorldKomaPos.y);

        KomanameSet();
        PorESet();
        KomakindSet();
        KomadataSet(this.Komakind);

    }

    private void DataReset() {
        this.selectnow = false;
        this.Komakind = 0;
        this.blockflg = false;
        this.Junpflg = false;
        this.PorE = 0;
        for (int k = 0; k < 24; k++)
        {
            ableMove[k] = false;
        }

    }

    public int GetKomakind() {
        return Komakind;
    }

    public int GetPorE() {
        return PorE;
    }

    public bool GetJunpflg() {
        return Junpflg;
    }

    public bool GetBlockflg() {
        return blockflg;
    }

    public bool GetSelectNow()
    {
        return selectnow;
    }

    public Vector2 GetLocalKomaPos()
    {
        return LocalKomaPos;
    }

    public void SetLocalKomaPos(Vector2 lp)
    {
        LocalKomaPos.x = lp.x;
        LocalKomaPos.y = lp.y;
    }

    private void PorESet() {

        for (int i = 0; i < 12; i++) {
            if (i < 6) {
                if (this.gameObject.name == komaname[i]) PorE = 1;
            } else if (i >= 6 && i < 12) {
                if (this.gameObject.name == komaname[i]) PorE = 2;
            } else {
                Debug.Log("name set error.");
            }
        }
    }



    private void KomanameSet() {
        for (int i = 0; i < this.komaNames.Count; i++)
        {
            komaname[i] = komaNames[i];
        }
    }

    private Dictionary<int, List<bool>> komaInfos = new Dictionary<int, List<bool>>
    {
        {1,new List<bool>{
        false,false,false,false,false,
        false,true,true,true,false,
        false,false,    false,false,
        false,false,false,false,false,
        false,false,false,false,false,
        } },

        {5,new List<bool>{
        false,false,false,false,false,
        false,true,false,true,false,
        false,false,     false,false,
        false,true,false,true,false,
        false,false,false,false,false,
        } },

        {10,new List<bool>{
        false,false,false,false,false,
        false,true,true,true,false,
        false,true,    true,false,
        false,false,true,false,false,
        false,false,false,false,false,
        } },

        {50,new List<bool>{
        false,true,true,true,false,
        false,false,false,false,false,
        false,true,      true,false,
        false,false,false,false,false,
        false,false,false,false,false,
        } },

        {100,new List<bool>{
        false,false,true,false,false,
        false,false,true,false,false,
        true, true,       true,true,
        false,false,true,false,false,
        false,false,true,false,false,
        } },

        {500,new List<bool>{
        false,false,false,false,false,
        false,true,true,true,false,
        false,true,     true,false,
        false,true,true,true,false,
        false,false,false,false,false,
        } },

        {0,new List<bool>{
        false,false,false,false,false,
        false,false,false,false,false,
        false,false,    false,false,
        false,false,false,false,false,
        false,false,false,false,false,
        } },
    };

    private List<int> komaKinds = new List<int>
    {
        1,
        5,
        10,
        50,
        100,
        500,
    };




    private void KomakindSet() {
        for (int i = 0; i < komaname.Length; i++)
        {
            if (this.gameObject.name.Equals(komaname[i]))
            {
                // 移動可能なマスを定義する。
                int key;
                if (i >= (komaname.Length / 2)) { key = komaKinds[i - (komaname.Length / 2)]; } else { key = komaKinds[i]; }

                this.Komakind = key;
                List<bool> ableMoveArea = komaInfos[key];
                for (int j = 0; j < ableMoveArea.Count; j++)
                    ableMove[j] = ableMoveArea[j];
            }
        }

    }

    private void KomadataSet(int kind) {
        if (kind == 5 || kind == 100) this.blockflg = true;
        if (kind == 50) this.Junpflg = true;
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
    {//<int, int[,]> == <indexnum, [x value, y value]>
       
        {2,new Vector2(0,1)},
        {10,new Vector2(-1,0)},
        {13,new Vector2(1, 0)},
        {21,new Vector2(0, -1)},


    };




    private bool JudgmentFlg(Vector2 rela, int LPX, int LPY, int kind, int TP, int indexnum)
    {
        if (TP == 1 && (mapdata.map[LPX + (int)rela.x, LPY + (int)rela.y] > 0)){ return false; }else if(TP == 2 && (mapdata.map[LPX + (int)rela.x, LPY + (int)rela.y] < 0)) { return false; }

        if (kind == 50)
        {
            for(int k = 0; k < BLOCKKOMAKIND.Count; k++)
            {
                int variable = 1;
                int bkkind = BLOCKKOMAKIND[k];
                if (TP == 1) { bkkind = (-1) * bkkind; }else { variable = -1;  }
                if (mapdata.map[LPX, LPY + variable] == bkkind || mapdata.map[LPX, LPY + variable] == bkkind) { if (indexnum <= 4) return false; }
            }
        }
        if (kind == 100)
        {
            if (indexnum == 2 || indexnum == 10 || indexnum == 13 || indexnum == 21)
            {
                Vector2 Cval = CalculationValue[indexnum];
                if (TP == 2) Cval = (-1) * Cval;
                if (mapdata.map[LPX + (int)Cval.x, LPY + (int)Cval.y] != 0) return false;
            }
        }
        return true;
    }

  

    public void ShowMove(int kind, int TP)
    {
        mapdata = cont.GetComponent<Mapdata>();

        int indexnum;
        Vector2 rela;
            for(int y = 0; y < 5; y++)
            {
                for (int x = 0; x < 5; x++) {
                    bool showflg = true;

                    rela = RetRelativeMatlix(x, y, TP);
                    indexnum = (y * 5) + x;

                    if (indexnum == 12) continue;
                    if (indexnum >= 13) indexnum--;
                                  
                    if (ableMove[indexnum] == true){
                        if (LocalKomaPos.y + rela.y >= 8) continue;
                        if (LocalKomaPos.y + rela.y <= 0) continue;
                        if (LocalKomaPos.x + rela.x >= 8) continue;
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
    /// 持ち金の打つ範囲を消す関数。
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
