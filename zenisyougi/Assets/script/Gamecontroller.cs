using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class Gamecontroller : MonoBehaviour
{

    public int turnplayer;
    public int AmountOfWin;

    koma komadata;

    ToChangePoint changePoint;
    public GameObject selectedobj;
    Mapdata mapdata;
    SetPosition setP;
    private int keeplistnumber;
    GameObject turnChangeObj;
    TurnChange tc;


    private void Start()
    {
        turnplayer = 1;
        changePoint = GetComponent<ToChangePoint>();
        mapdata = GetComponent<Mapdata>();
        setP = GetComponent<SetPosition>();
        AmountOfWin = 171;
        turnChangeObj = GameObject.Find("TurnChangeObj");
        tc = turnChangeObj.GetComponent<TurnChange>();

    }

    private void Update()
    {
        if ((mapdata.P1motikinnsum >= AmountOfWin) ||(mapdata.P2motikinnsum >= AmountOfWin))
        {
            if ((mapdata.P1motikinnsum >= AmountOfWin) && (mapdata.P2motikinnsum >= AmountOfWin)) GameSet(0);
            if((mapdata.P1motikinnsum >= AmountOfWin) && (mapdata.P2motikinnsum < AmountOfWin))
            {
                GameSet(1);
            }else if((mapdata.P1motikinnsum < AmountOfWin) && (mapdata.P2motikinnsum >= AmountOfWin))
            {
                GameSet(2);
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
                    }else if(turnplayer == 2)
                    {
                        turnplayer = 1;
                    }
                    selectedobj = null;
                    //ここにターン開始時の処理
                    tc.MoveTurnObj(turnplayer);

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

                            if (turnplayer == 1)
                            {
                                    if (mapdata.P1motikinn[motikinn.GetKomakindToIndexnum(motikinn.GetKomakind())] >= 1)
                                    {
                                        motikinn.MotikinnShowMove(motikinn.GetKomakind(), turnplayer);
                                        komaobj.transform.Find("motikinnselect").gameObject.SetActive(true);
                                    }
                                
                            }else if (turnplayer == 2)
                            {                            
                                    if (mapdata.P2motikinn[motikinn.GetKomakindToIndexnum(motikinn.GetKomakind())] >= 1)
                                    {
                                        motikinn.MotikinnShowMove(motikinn.GetKomakind(), turnplayer);
                                    komaobj.transform.Find("motikinnselect").gameObject.SetActive(true);
                                }
                                
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
                    if(turnplayer == 1)
                    {
                        if (mapdata.P1motikinn[motikinn.GetKomakindToIndexnum(motikinn.GetKomakind())] >= 1)
                        {
                            komaobj.transform.Find("motikinnselect").gameObject.SetActive(true);
                            motikinn.MotikinnShowMove(motikinn.GetKomakind(), turnplayer);
                        }

                    }
                    else if(turnplayer == 2)
                    {
                        if (mapdata.P2motikinn[motikinn.GetKomakindToIndexnum(motikinn.GetKomakind())] >= 1)
                        {
                            komaobj.transform.Find("motikinnselect").gameObject.SetActive(true);
                            motikinn.MotikinnShowMove(motikinn.GetKomakind(), turnplayer);
                        }
                    }

                   // Debug.Log(motikinn.GetKomakind());
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
                /*
                if(selectedobj != null)
                {
                    koma Ko;
                    Ko = selectedobj.GetComponent<koma>();
                    Ko.InvisibleMove(selectedobj);
                    selectedobj = null;
                }
                */
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

    public void ReturnKome(int x, int y)
    {
        GameObject game;
        Vector2 lp;
        lp.x = x;
        lp.y = y;
        game = Get_komadataFromList(lp);
        mapdata.map[x, y] = 0;
        TakeKoma(game);


    }

    public void KomaMove(GameObject preobj,GameObject selectpoint)
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

    public void MoveMapdataUpdate(int preLPx, int preLPy, int toLPx, int toLpy, int komakind, int tp)
    {
        int k = 0;

        if (tp == 1) { k = komakind; }else if(tp == 2) { k = komakind * (-1); } else { Debug.Log("error"); }

        mapdata.map[preLPx, preLPy] = 0;
        mapdata.map[toLPx, toLpy] = k;
    }

    /*
public GameObject Get_Unit(Vector3 pos){
        for (int i = 0; i < UnitObj.Count; i++){
            if(UnitObj[i].transform.position == pos){
                return UnitObj[i];
            }
        }
        return null;
    }
*/

    public GameObject Get_komadataFromList(Vector2 lp)
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

    public void TakeKoma(GameObject torarerukoma)
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

    public void AddMotikinn(int kind)
    {
        switch (kind)
        {
            case 1:
                if(turnplayer == 1) { mapdata.P1motikinn[0]++; }else if(turnplayer == 2) { mapdata.P2motikinn[0]++; } else { }
                break;
            case 5:
                if(turnplayer == 1) { mapdata.P1motikinn[1]++; }else if(turnplayer == 2) { mapdata.P2motikinn[1]++; } else { }
                break;
            case 10:
                if(turnplayer == 1) { mapdata.P1motikinn[2]++; }else if(turnplayer == 2) { mapdata.P2motikinn[2]++; } else { }
                break;
            case 50:
                if(turnplayer == 1) { mapdata.P1motikinn[3]++; }else if(turnplayer == 2) { mapdata.P2motikinn[3]++; } else { }
                break;
            case 100:
                if(turnplayer == 1) { mapdata.P1motikinn[4]++; }else if(turnplayer == 2) { mapdata.P2motikinn[4]++; } else { }
                break;
            case 500:
                if(turnplayer == 1) { mapdata.P1motikinn[5]++; }else if(turnplayer == 2) { mapdata.P2motikinn[5]++; } else { }
                break;
            default:
                break;

        }

    }


    public void MotikinnwoBaniUtu(int kind , int TP, GameObject selectpoint)
    {
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

    public void DisMotikinn(int kind)
    {
        switch (kind)
        {
            case 1:
                if (turnplayer == 1) { mapdata.P1motikinn[0]--; } else if (turnplayer == 2) { mapdata.P2motikinn[0]--; } else { }
                break;
            case 5:
                if (turnplayer == 1) { mapdata.P1motikinn[1]--; } else if (turnplayer == 2) { mapdata.P2motikinn[1]--; } else { }
                break;
            case 10:
                if (turnplayer == 1) { mapdata.P1motikinn[2]--; } else if (turnplayer == 2) { mapdata.P2motikinn[2]--; } else { }
                break;
            case 50:
                if (turnplayer == 1) { mapdata.P1motikinn[3]--; } else if (turnplayer == 2) { mapdata.P2motikinn[3]--; } else { }
                break;
            case 100:
                if (turnplayer == 1) { mapdata.P1motikinn[4]--; } else if (turnplayer == 2) { mapdata.P2motikinn[4]--; } else { }
                break;
            case 500:
                if (turnplayer == 1) { mapdata.P1motikinn[5]--; } else if (turnplayer == 2) { mapdata.P2motikinn[5]--; } else { }
                break;
            default:
                break;


        }

    }

    private void GameSet(int winplayer)
    {
        if (winplayer == 0) {
            Debug.Log("draw!");
        } else  {
            Debug.Log(winplayer + "P win!");
                  }
        EditorApplication.isPlaying = false;
    }



}




