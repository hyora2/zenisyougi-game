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

    private List<int>  BLOCKKOMAKIND = new List<int>
    {
        5,
        100,

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

    private void DataReset(){
        this.selectnow = false;
        this.Komakind = 0;
        this.blockflg = false;
        this.Junpflg = false;
        this.PorE = 0;
        for(int k = 0; k < 24; k++)
        {
            ableMove[k] = false;
        }

    }

    public int GetKomakind(){
        return Komakind;
    }

    public int GetPorE(){
        return PorE;
    }

    public bool GetJunpflg(){
        return Junpflg;
    }

    public bool GetBlockflg(){
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

    private void PorESet(){

        for (int i = 0; i < 12; i++){
            if(i < 6){
                if (this.gameObject.name == komaname[i]) PorE = 1;
            }else if(i >= 6 && i < 12){
                if (this.gameObject.name == komaname[i]) PorE = 2;
            }else{
                Debug.Log("name set error.");
            }
        }

    }

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

    private void KomanameSet(){

        for(int i = 0; i < this.komaNames.Count; i++)
        {
            komaname[i] = komaNames[i];
        }
        //komaname[0] = "1yen1(Clone)";
        //komaname[1] = "5yen1(Clone)";
        //komaname[2] = "10yen1(Clone)";
        //komaname[3] = "50yen1(Clone)";
        //komaname[4] = "100yen1(Clone)";
        //komaname[5] = "500yen1(Clone)";
        //komaname[6] = "1yen2(Clone)";
        //komaname[7] = "5yen2(Clone)";
        //komaname[8] = "10yen2(Clone)";
        //komaname[9] = "50yen2(Clone)";
        //komaname[10] = "100yen2(Clone)";
        //komaname[11] = "500yen2(Clone)";
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
        1,
        5,
        10,
        50,
        100,
        500,
    };

    private void KomakindSet(){

        for(int i = 0; i < komaname.Length; i++)
        {
            if(this.gameObject.name.Equals(komaname[i]))
            {
                // 移動可能なマスを定義する。
                int key = komaKinds[i];

                List<bool> ableMoveArea = komaInfos[key];
                for (int j = 0; j < ableMoveArea.Count; j++)
                    ableMove[j] = ableMoveArea[j];
            }
        }

        //if (this.gameObject.name == komaname[0]) {  Komakind = 1;ableMove[6] = ableMove[7] = ableMove[8] = true;}
        //if (this.gameObject.name == komaname[1]) { Komakind = 5; ableMove[6] = ableMove[8] = ableMove[15] = ableMove[17] = true; }
        //if (this.gameObject.name == komaname[2]) { Komakind = 10; ableMove[6] = ableMove[7] = ableMove[8] = ableMove[11] =ableMove[12] = ableMove[16] = true; }
        //if (this.gameObject.name == komaname[3]) { Komakind = 50; ableMove[1] = ableMove[2] = ableMove[3] = ableMove[11] = ableMove[12] = true; }
        //if (this.gameObject.name == komaname[4]) { Komakind = 100; ableMove[2] = ableMove[7] = ableMove[12] = ableMove[13] = ableMove[16] = ableMove[21] = ableMove[11] = ableMove[10] = true; }
        //if (this.gameObject.name == komaname[5]) { Komakind = 500; ableMove[6] = ableMove[7] = ableMove[8] = ableMove[11] = ableMove[12] = ableMove[15] = ableMove[16] = ableMove[17] = true; }
        //if (this.gameObject.name == komaname[6]) { Komakind = 1; ableMove[15] = ableMove[16] = ableMove[17] = true; }
        //if (this.gameObject.name == komaname[7]) { Komakind = 5; ableMove[15] = ableMove[17] = ableMove[6] = ableMove[8] = true; }
        //if (this.gameObject.name == komaname[8]) { Komakind = 10; ableMove[16] = ableMove[17] = ableMove[15] = ableMove[7] = ableMove[11]=ableMove[12] = true; }
        //if (this.gameObject.name == komaname[9]) { Komakind = 50; ableMove[20] = ableMove[21] = ableMove[22] = ableMove[11] = ableMove[12] = true; }
        //if (this.gameObject.name == komaname[10]) { Komakind = 100; ableMove[2] = ableMove[7] = ableMove[12] = ableMove[13] = ableMove[16] = ableMove[21] = ableMove[11] = ableMove[10] = true; }
        //if (this.gameObject.name == komaname[11]) { Komakind = 500; ableMove[6] = ableMove[7] = ableMove[8] = ableMove[11] = ableMove[12] = ableMove[15] = ableMove[16] = ableMove[17] = true; }

    }

    private void KomadataSet(int kind){
        if (kind == 5 || kind == 100) this.blockflg = true;
        if (kind == 50) this.Junpflg = true;


    }


    public void InvisibleMove(GameObject komaobj) 
    {
        foreach(Transform item in komaobj.transform)
        {
            item.gameObject.SetActive(false);
        }


    }
    public Vector2 RetRelativeMatlix(int x, int y)
    {
        Vector2 result;
        result = Vector2.zero;

        if (x == 0) result.x = -2;
        if (x == 1) result.x = -1;
        if (x == 2) result.x = 0;
        if (x == 3) result.x = 1;
        if (x == 4) result.x = 2;

        if (y == 0) result.y = 2;
        if (y == 1) result.y = 1;
        if (y == 2) result.y = 0;
        if (y == 3) result.y = -1;
        if (y == 4) result.y = -2;

        return result;
    }

   
   public void ShowMove(int kind, int TP)
    {
        mapdata = cont.GetComponent<Mapdata>();

        int indexnum;
        Vector2 rela;
        //int[] blockkomakind = new int[] { BLOCKKOMA_5, BLOCKKOMA_100, };
             
            for(int y = 0; y < 5; y++)
            {
                for (int x = 0; x < 5; x++) {
                bool show = true;       //実際表示できるか判別
                bool mapnotOn = false;  //自分の駒が乗って無いかを判別する
                    rela = RetRelativeMatlix(x, y);
                    indexnum = (y * 5) + x;
                    if (indexnum == 12) continue;
                    if (indexnum >= 13) indexnum = indexnum - 1;

                    if (ableMove[indexnum] == true){ 
                        if (LocalKomaPos.y + rela.y >= 8) continue;
                        if (LocalKomaPos.y + rela.y <= 0) continue;
                        if (LocalKomaPos.x + rela.x >= 8) continue;
                        if (LocalKomaPos.x + rela.x <= 0) continue;

                        if(TP == 1) { if (mapdata.map[(int)LocalKomaPos.x + (int)rela.x, (int)LocalKomaPos.y + (int)rela.y] <= 0) mapnotOn = true; }else if(TP == 2) { if (mapdata.map[(int)LocalKomaPos.x + (int)rela.x, (int)LocalKomaPos.y + (int)rela.y] >= 0) mapnotOn = true; }

                    if (mapnotOn){
                           
                        if (Komakind == 50){
                            if (indexnum <= 4){
                                for (int k = 0; k < BLOCKKOMAKIND.Count; k++)
                                {
                                    int blockkoma = 0;
                                    if (TP == 1) { blockkoma = (-1) * BLOCKKOMAKIND[k]; } else if (TP == 2) { blockkoma = BLOCKKOMAKIND[k]; }
                                    if (mapdata.map[(int)LocalKomaPos.x, (int)LocalKomaPos.y + 1] == blockkoma) show = false;
                                }
                            }
                        }

                            if(Komakind == 100){
                                if(indexnum == 2) { if (mapdata.map[(int)LocalKomaPos.x , (int)LocalKomaPos.y + 1] != 0) continue; }
                                if(indexnum == 10) { if (mapdata.map[(int)LocalKomaPos.x - 1, (int)LocalKomaPos.y ] != 0) continue; }
                                if(indexnum == 13) { if (mapdata.map[(int)LocalKomaPos.x + 1, (int)LocalKomaPos.y ] != 0) continue; }
                                if(indexnum == 21) { if (mapdata.map[(int)LocalKomaPos.x , (int)LocalKomaPos.y - 1] != 0) continue; }
                            }
                          
                        if (show == true){
                            transform.Find("select" + indexnum.ToString()).gameObject.SetActive(true);
                        }
                        }
                    } 
                    }
            }

       
       

       
       

    }
    









        


       
        /*

    public void ShowMove(int kind, int TP)
    {
        mapdata = cont.GetComponent<Mapdata>();

        int indexnum;
        Vector2 rela;
       


        if(TP == 1)
        {
            for(int y = 0; y < 5; y++)
            {
                for (int x = 0; x < 5; x++) {
                    rela = RetRelativeMatlix(x, y);
                    indexnum = (y * 5) + x;
                    if (indexnum == 12) continue;
                    if (indexnum >= 13) indexnum = indexnum - 1;
                                    
                    if (ableMove[indexnum] == true)
                    {
                       
                        if (LocalKomaPos.y + rela.y >= 8) continue;
                        if (LocalKomaPos.y + rela.y <= 0) continue;
                        if (LocalKomaPos.x + rela.x >= 8) continue;
                        if (LocalKomaPos.x + rela.x <= 0) continue;

                        if (mapdata.map[(int)LocalKomaPos.x + (int)rela.x, (int)LocalKomaPos.y + (int)rela.y] <= 0)
                        {

                            if(Komakind == 50)
                            {
                                if (mapdata.map[(int)LocalKomaPos.x, (int)LocalKomaPos.y + 1] == -5 || mapdata.map[(int)LocalKomaPos.x, (int)LocalKomaPos.y + 1] == -100) { if (indexnum <= 4) continue; }
                            }
                            if(Komakind == 100)
                            {
                                if(indexnum == 2) { if (mapdata.map[(int)LocalKomaPos.x , (int)LocalKomaPos.y + 1] != 0) continue; }
                                if(indexnum == 10) { if (mapdata.map[(int)LocalKomaPos.x - 1, (int)LocalKomaPos.y ] != 0) continue; }
                                if(indexnum == 13) { if (mapdata.map[(int)LocalKomaPos.x + 1, (int)LocalKomaPos.y ] != 0) continue; }
                                if(indexnum == 21) { if (mapdata.map[(int)LocalKomaPos.x , (int)LocalKomaPos.y - 1] != 0) continue; }

                            }

                            transform.Find("select" + indexnum.ToString()).gameObject.SetActive(true);
                        }
                    } 
                    }
            }

        }
        else if(TP == 2)
        {
            for (int y = 0; y < 5; y++)
            {
                for (int x = 0; x < 5; x++)
                {
                    rela = RetRelativeMatlix(x, y);
                    indexnum = y * 5 + x;
                    if (indexnum == 12) continue;
                    if (indexnum >= 13) indexnum--;

                    if (ableMove[indexnum] == true)
                    {
                        if (LocalKomaPos.y + rela.y >= 8)  continue;
                        if (LocalKomaPos.y + rela.y <= 0) continue;
                        if (LocalKomaPos.x + rela.x >= 8) continue;
                        if (LocalKomaPos.x + rela.x <= 0) continue;

                        if (mapdata.map[(int)LocalKomaPos.x + (int)rela.x, (int)LocalKomaPos.y + (int)rela.y] >= 0)
                        {
                            if(Komakind == 50)
                            {
                                if (mapdata.map[(int)LocalKomaPos.x, (int)LocalKomaPos.y - 1] == 5 || mapdata.map[(int)LocalKomaPos.x, (int)LocalKomaPos.y - 1] == 100)if(indexnum >= 19) continue;
                            }
                            if (Komakind == 100)
                            {
                                if (indexnum == 2) { if (mapdata.map[(int)LocalKomaPos.x, (int)LocalKomaPos.y + 1] != 0) continue; }
                                if (indexnum == 10) { if (mapdata.map[(int)LocalKomaPos.x - 1, (int)LocalKomaPos.y] != 0) continue; }
                                if (indexnum == 13) { if (mapdata.map[(int)LocalKomaPos.x + 1, (int)LocalKomaPos.y] != 0) continue; }
                                if (indexnum == 21) { if (mapdata.map[(int)LocalKomaPos.x, (int)LocalKomaPos.y - 1] != 0) continue; }

                            }

                            transform.Find("select" + indexnum.ToString()).gameObject.SetActive(true);
                        }
                    }
                }
            }

        }


       
       

    }
    */
  
}
