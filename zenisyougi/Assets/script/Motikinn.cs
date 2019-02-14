using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motikinn : MonoBehaviour
{
   
    [SerializeField] int Komakind;
    [SerializeField] int PorE;
    GameObject cont;
    Mapdata mapdata;
    GameObject motikinnshow;

    private string[] komaname = new string[12];


    private void Start()
    {
        cont = GameObject.Find("GameCont");
        mapdata = cont.GetComponent<Mapdata>();
        motikinnshow = GameObject.Find("motikinnshowObj");

        DataReset();
        KomanameSet();
        PorESet();
        KomakindSet();
       
    }

    public int GetKomakindToIndexnum(int kind)
    {
        int result = -1;
        switch (kind)
        {
            case 1:
                result = 0;
                break;
            case 5:
                result = 1;
                break;
            case 10:
                result = 2;
                break;
            case 50:
                result = 3;
                break;
            case 100:
                result = 4;
                break;
            case 500:
                result = 5;
                break;
        }
        return result;
    }

    private void DataReset()
    {
        this.Komakind = 0;
        this.PorE = 0;
    }

    public int GetKomakind()
    {
        return Komakind;
    }

    public int GetPorE()
    {
        return PorE;
    }

  
    private void PorESet()
    {

        for (int i = 0; i < 12; i++)
        {
            if (i < 6)
            {
                if (this.gameObject.name == komaname[i]) PorE = 1;
            }
            else if (i >= 6 && i < 12)
            {
                if (this.gameObject.name == komaname[i]) PorE = 2;
            }
            else
            {
                Debug.Log("name set error.");
            }
        }

    }
    private void KomanameSet()
    {
        komaname[0] = "1_1";
        komaname[1] = "1_5";
        komaname[2] = "1_10";
        komaname[3] = "1_50";
        komaname[4] = "1_100";
        komaname[5] = "500y";
        komaname[6] = "2_1";
        komaname[7] = "2_5";
        komaname[8] = "2_10";
        komaname[9] = "2_50";
        komaname[10] = "2_100";
        komaname[11] = "500yen2";

    }

    private void KomakindSet()
    {
        if (this.gameObject.name == komaname[0]) Komakind = 1;
        if (this.gameObject.name == komaname[1]) Komakind = 5;
        if (this.gameObject.name == komaname[2]) Komakind = 10;
        if (this.gameObject.name == komaname[3]) Komakind = 50;
        if (this.gameObject.name == komaname[4]) Komakind = 100;
        if (this.gameObject.name == komaname[5]) Komakind = 500;
        if (this.gameObject.name == komaname[6]) Komakind = 1;
        if (this.gameObject.name == komaname[7]) Komakind = 5;
        if (this.gameObject.name == komaname[8]) Komakind = 10;
        if (this.gameObject.name == komaname[9]) Komakind = 50;
        if (this.gameObject.name == komaname[10]) Komakind = 100;
        if (this.gameObject.name == komaname[11]) Komakind = 500;
    }



    public void InvisibleMove()
    {
        foreach (Transform item in motikinnshow.transform)
        {
            item.gameObject.SetActive(false);
        }
        transform.Find("motikinnselect").gameObject.SetActive(false);
    }

    public int ReturnXYnum(int x, int y)
    {
        return 10 * y + x;
    }


    public void MotikinnShowMove(int kind, int TP)
    {
        mapdata = cont.GetComponent<Mapdata>();
        int xynum;
        for (int y = 1; y < 8; y++) {
            for (int x = 1; x < 8; x++)
            {
                if (TP == 1)
                {
                    if (y >= 7 && (kind == 50 || kind == 1)) break;
                    if (y >= 6 && (kind == 50)) break;
                    if (mapdata.map[x, y] == 0)
                    {
                        xynum = ReturnXYnum(x, y);
                        motikinnshow.transform.Find(xynum.ToString()).gameObject.SetActive(true);
                    }
                }else if (TP == 2)
                {
                    if (y <= 1 && (kind == 50 || kind == 1)) break;
                    if (y <= 2 && (kind == 50)) break;
                    if (mapdata.map[x,y] == 0)
                    {
                        xynum = ReturnXYnum(x, y);
                        motikinnshow.transform.Find(xynum.ToString()).gameObject.SetActive(true);
                    }

                }
            }
        }
       

    }

    /*
    internal void InvisibleMove(GameObject selectedobj)
    {
        throw new NotImplementedException();
    }
    */
}

