using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class Gamecontroller : MonoBehaviour
{

    public int turnplayer;
    public int AmountOfWin;
    private int MotikinnSumIndexnum;

    koma komadata;

    ToChangePoint changePoint;//座標変換用クラス
    public GameObject selectedobj;
    Mapdata mapdata;
    SetPosition setP;
    private int keeplistnumber;
    GameObject turnChangeObj;
    TurnChange tc;
    public GameObject turnOBJ1;
    public GameObject turnOBJ2;

    GameObject fadeoutOBJ;
    FadeScript fade;
    bool gameset;

    public GameObject p1win;
    public GameObject p2win;

    private void Start()
    {

        turnplayer = 1;
        changePoint = GetComponent<ToChangePoint>();
        mapdata = GetComponent<Mapdata>();
        setP = GetComponent<SetPosition>();
        AmountOfWin = 171;
        MotikinnSumIndexnum = mapdata.GetKomakindToIndexnum[-1];

        /*
        turnChangeObj = GameObject.Find("TurnChangeObj");
        tc = turnChangeObj.GetComponent<TurnChange>();
        */
       // turnOBJ1 = GameObject.FindGameObjectWithTag("turn1");
       // turnOBJ2 = GameObject.FindGameObjectWithTag("turn2");      
        fadeoutOBJ = GameObject.Find("GameSetCanvas");
        fade = fadeoutOBJ.GetComponent<FadeScript>();
        gameset = false;
        fade.SetAlfa(1f);
        fade.Setfadein(true);

    }


    private void Update()
    {
        if (gameset == true) return; //勝負が着いた時updateを止める
        if (mapdata.motikinn[0, MotikinnSumIndexnum] >= AmountOfWin || mapdata.motikinn[1, MotikinnSumIndexnum] >= AmountOfWin) {
            if ((mapdata.motikinn[0, MotikinnSumIndexnum] >= AmountOfWin) && (mapdata.motikinn[1, MotikinnSumIndexnum] >= AmountOfWin)) { GameSet(0); }
            for (int i = 0; i < 2; i++)
            {
                if (mapdata.motikinn[i, MotikinnSumIndexnum] >= AmountOfWin)  GameSet(i + 1);
            }

        }
       
        GameObject komaobj = Getclickobj();
        if(komaobj != null){
            if (((komaobj.tag != "toMove" )&&(komaobj.tag != "motikinn")) &&(komaobj.tag != "motikinnToMove"))
            {
                            
                    komadata = komaobj.GetComponent<koma>();
                    if (turnplayer == komadata.GetPorE())
                    {//駒を選んだとき

                        if (selectedobj != null)
                        {
                            if (selectedobj.tag != "motikinn")
                            {//他のこまが選ばれていたとき

                                koma Ko;
                                Ko = selectedobj.GetComponent<koma>();
                                Ko.InvisibleMove(selectedobj);
                                selectedobj = null;
                            }
                            else if (selectedobj.tag == "motikinn")
                            {//他の持ち金が選ばれていたとき

                                Motikinn moti;
                                moti = selectedobj.GetComponent<Motikinn>();
                                moti.InvisibleMove();
                                selectedobj = null;
                            }
                        }

                        selectedobj = komaobj;
                        komadata.ShowMove(komadata.GetKomakind(), turnplayer);

                    }
                
            }else if((komaobj.tag == "toMove") || (komaobj.tag == "motikinnToMove"))
            {//駒または持ち金をすでに選んでおり、移動先を選ぶとき
                if (selectedobj != null)
                {
                    if (komaobj.tag == "toMove")
                    {//駒の移動処理
                        koma Ko;
                        Ko = selectedobj.GetComponent<koma>();

                        KomaMove(selectedobj, komaobj);
                        Ko.InvisibleMove(selectedobj);
                    }
                    else if(komaobj.tag == "motikinnToMove")
                    {
                        //持ち金を打つ処理
                        Motikinn motikinnobj;
                        motikinnobj = selectedobj.GetComponent<Motikinn>();
                        // Debug.Log(motikinnobj.GetKomakind());
                        MotikinnwoBaniUtu(motikinnobj.GetKomakind(), turnplayer, komaobj);
                        motikinnobj.InvisibleMove();

                    }

                    if (turnplayer == 1)
                    {
                        turnplayer = 2;
                        turnOBJ2.gameObject.SetActive(true);
                        turnOBJ1.gameObject.SetActive(false);
                    }else if(turnplayer == 2)
                    {
                        turnplayer = 1;
                        turnOBJ1.gameObject.SetActive(true);
                        turnOBJ2.gameObject.SetActive(false);
                    }
                    selectedobj = null;
                    //ここにターン開始時の処理

                    //tc.MoveTurnObj(turnplayer);

                   // PullOutProcess(turnplayer); //なぜかめちゃくちゃ重くなるのでこのまま
                    if(turnplayer == 1)
                    {//駒の自主撤退
                        for(int y = 7; y >= 6; y--)
                        {
                            for(int x = 0; x < 8; x++)
                            {
                                if(y != 6)
                                {
                                    if (mapdata.map[x, y] == 1) ReturnKome(x, y);
                                }
                                if (mapdata.map[x, y] == 50) ReturnKome(x, y);
                            }
                        }
                    }
                    else if(turnplayer == 2)
                    {
                        for (int y = 1; y <= 2; y++)
                        {
                            for (int x = 0; x < 8; x++)
                            {
                                if(y != 2)
                                {
                                    if (mapdata.map[x, y] == -1) ReturnKome(x, y);
                                }
                                if (mapdata.map[x, y] == -50) ReturnKome(x, y);
                            }
                        }

                    }

                }
            }else if (komaobj.tag == "motikinn")
            {
                //持ち金を選んだとき
                Motikinn motikinn = komaobj.GetComponent<Motikinn>();
                if (turnplayer == motikinn.GetPorE())
                {
                   if (selectedobj != null)
                    {
                        if (selectedobj.tag == "motikinn")
                        {//すでに別の持ち金が選ばれており、変更するとき
                            Motikinn Ko;
                            Ko = selectedobj.GetComponent<Motikinn>();
                            Ko.InvisibleMove();

                          
                                    if (mapdata.motikinn[(turnplayer - 1), mapdata.GetKomakindToIndexnum[motikinn.GetKomakind()]] >= 1)
                                    {
                                        motikinn.MotikinnShowMove(motikinn.GetKomakind(), turnplayer);
                                        komaobj.transform.Find("motikinnselect").gameObject.SetActive(true);
                                    }
                          

                            selectedobj = null;
                        }else if(selectedobj.tag != "motikinn")
                        {//すでに別の場の駒が選ばれており、持ち金に変更するとき
                            koma Ko;
                            Ko = selectedobj.GetComponent<koma>();
                            Ko.InvisibleMove(selectedobj);
                            selectedobj = null;
                           // komaobj.transform.Find("motikinnselect").gameObject.SetActive(true);

                        }
                    }
                    selectedobj = komaobj;
                    //ここに打てる場所のshowmove。

                        if (mapdata.motikinn[(turnplayer -1), motikinn.GetKomakindToIndexnum[motikinn.GetKomakind()]] >= 1)
                        {
                            komaobj.transform.Find("motikinnselect").gameObject.SetActive(true);
                            motikinn.MotikinnShowMove(motikinn.GetKomakind(), turnplayer);
                        }
                    
                }

            }
        }
    }


    public GameObject Getclickobj(){
        GameObject result = null;
        if(Input.GetMouseButtonDown(0)){
            Vector2 clickpoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D collition2D = Physics2D.OverlapPoint(clickpoint);          
            if(collition2D){
                result = collition2D.transform.gameObject;
            }
            else
            {
                if(selectedobj != null)
                {
                    if (selectedobj.tag != "motikinn")
                    {
                        koma Ko;
                        Ko = selectedobj.GetComponent<koma>();
                        Ko.InvisibleMove(selectedobj);
                        selectedobj = null;
                    }else if(selectedobj.tag == "motikinn")
                    {
                        Motikinn Ko;
                        Ko = selectedobj.GetComponent<Motikinn>();
                        Ko.InvisibleMove();
                        selectedobj = null;
                    }
                }
            }
        }
        return result;
    }

    /*
    public void PullOutProcess(int TP)
    {
        if (TP == 1)
        {//駒の自主撤退
            for (int y = 7; y >= 6; y--)
            {
                for (int x = 0; x < 8; x++)
                {
                    if (y != 6)
                    {
                        if (mapdata.map[x, y] == 1) ReturnKome(x, y);
                    }
                    if (mapdata.map[x, y] == 50) ReturnKome(x, y);
                }
            }
        }
        else if (TP == 2)
        {
            for (int y = 1; y <= 2; y++)
            {
                for (int x = 0; x < 8; x++)
                {
                    if (y != 2)
                    {
                        if (mapdata.map[x, y] == -1) ReturnKome(x, y);
                    }
                    if (mapdata.map[x, y] == -50) ReturnKome(x, y);
                }
            }

        }

    }
    */



    private void ReturnKome(int x, int y)
    {
        GameObject game;
        Vector2 lp;
        lp.x = x;
        lp.y = y;
        game = Get_komadataFromList(lp);
        mapdata.map[x, y] = 0;
        TakeKoma(game);

    }

    private void KomaMove(GameObject preobj,GameObject selectpoint)
    {
        Vector3 Movepoint = Vector3.zero;

        float tomovepointZ = -1f;

        Vector2 LP;
        int lpx, lpy;
        int prelpx, prelpy;
        koma komaD = preobj.GetComponent<koma>();

        lpx = changePoint.ToLocalPoint(selectpoint.transform.position.x);
        lpy = changePoint.ToLocalPoint(selectpoint.transform.position.y);
        prelpx = changePoint.ToLocalPoint(preobj.transform.position.x);
        prelpy = changePoint.ToLocalPoint(preobj.transform.position.y);

        Movepoint.x = changePoint.ToWorldPoint(lpx);
        Movepoint.y = changePoint.ToWorldPoint(lpy);

        LP.x = lpx;
        LP.y = lpy;

        Movepoint.z = tomovepointZ;

        if (mapdata.map[lpx, lpy] != 0)
        {
            GameObject game = null;
            game = Get_komadataFromList(LP);
            TakeKoma(game);
        }

       preobj.transform.position = Movepoint;
        MoveMapdataUpdate(prelpx, prelpy, lpx, lpy, komaD.GetKomakind(), turnplayer);
        komaD.SetLocalKomaPos(LP);
          
    }

    private void MoveMapdataUpdate(int preLPx, int preLPy, int toLPx, int toLpy, int komakind, int tp)
    {
        int k = 0;

        if (tp == 1) { k = komakind; }else if(tp == 2) { k = komakind * (-1); } else { Debug.Log("error"); }

        mapdata.map[preLPx, preLPy] = 0;
        mapdata.map[toLPx, toLpy] = k;
    }

  
    private GameObject Get_komadataFromList(Vector2 lp)
    {
        keeplistnumber = -1;
        for(int i = 0; i < mapdata.Kdatalist.Count; i++)
        {
            if(mapdata.Kdatalist[i].GetComponent<koma>().GetLocalKomaPos() == lp)
            {
                keeplistnumber = i;
                return mapdata.Kdatalist[i];
            }
        }
        return null;

    }

    private void TakeKoma(GameObject torarerukoma)
    {
        //ここにmotikinn増加処理
        AddMotikinn(torarerukoma.GetComponent<koma>().GetKomakind());
        mapdata.Motikinnsum();
        mapdata.TextUpdate();
        //リストから削除
        mapdata.Kdatalist.RemoveAt(keeplistnumber);
        //オブジェクトの削除
        Destroy(torarerukoma);

    }

    private void AddMotikinn(int kind)
    {
        int MotikinnlistIndex = mapdata.GetKomakindToIndexnum[kind];
        mapdata.motikinn[(turnplayer - 1), MotikinnlistIndex]++;

    }

    private void MotikinnwoBaniUtu(int kind , int TP, GameObject selectpoint)
    {//持ち金を場に打つ
        Vector3 UtuBasyo = Vector3.zero;
        int lpx, lpy;

        lpx = changePoint.ToLocalPoint(selectpoint.transform.position.x);
        lpy = changePoint.ToLocalPoint(selectpoint.transform.position.y);
        UtuBasyo.x = changePoint.ToWorldPoint(lpx);
        UtuBasyo.y = changePoint.ToWorldPoint(lpy);
        UtuBasyo.z = -1f;

        setP.MBU(kind, TP, UtuBasyo, lpx, lpy);
        DisMotikinn(kind);
        mapdata.Motikinnsum();
        mapdata.TextUpdate();
    }

    private void DisMotikinn(int kind)
    {
        int MotikinnlistIndex = mapdata.GetKomakindToIndexnum[kind];
        mapdata.motikinn[(turnplayer - 1), MotikinnlistIndex]--;

    }

    private void GameSet(int winplayer)
    {
        turnOBJ1.gameObject.SetActive(false);
        turnOBJ2.gameObject.SetActive(false);

        if (winplayer == 0) {
            Debug.Log("draw!");

        } else  {
            Debug.Log(winplayer + "P win!");
            if (winplayer == 1) p1win.SetActive(true);
            if (winplayer == 2) p2win.SetActive(true);
                  }
        gameset = true;
        fade.SetchangesceneKey("title");
        fade.Setfadeout(true);
      
    }

}

