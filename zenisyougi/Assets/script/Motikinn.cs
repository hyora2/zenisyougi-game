﻿using System;
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
    KomaData komaData;

    private string komaname;

    private void Start()
    {
        cont = GameObject.Find("GameCont");
        mapdata = cont.GetComponent<Mapdata>();
        motikinnshow = GameObject.Find("motikinnshowObj");
        komaData = GetComponent<KomaData>();

        DataReset();
        komaname = this.gameObject.name;
        PorE = komaData.PorESet(komaname);
        Komakind = komaData.KomakindSet(komaname);
       
    }
    public Dictionary<int, int> GetKomakindToIndexnum = new Dictionary<int, int>
    {
        {1, 0},
        {5, 1},
        {10, 2},
        {50, 3},
        {100,4},
        {500, 5},

    };


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

  
    public void InvisibleMove()
    {
        foreach (Transform item in motikinnshow.transform)
        {
            item.gameObject.SetActive(false);
        }
        transform.Find("motikinnselect").gameObject.SetActive(false);
    }

    private int ReturnXYnum(int x, int y)
    {
        return 10 * y + x;
    }


    public void MotikinnShowMove(int kind, int TP)
    {
        mapdata = cont.GetComponent<Mapdata>();
        int xynum;
        bool nifu = false;
       
        for (int y = 1; y < mapdata.GetmapWidth(); y++) {
            for (int x = 1; x < mapdata.GetmapWidth(); x++)
            {
                int ONE = 1;
                if (TP == 1) 
                {
                    if (y >= 7 && (kind == 50 || kind == 1)) break;
                    if (y >= 6 && (kind == 50)) break;
                }
                else if(TP == 2)
                {
                    if (y <= 1 && (kind == 50 || kind == 1)) break;
                    if (y <= 2 && (kind == 50)) break;
                    ONE = ONE * (-1);
                }

                if (kind == 1)
                {
                    for (int k = 1; k < mapdata.GetmapWidth(); k++)
                    {
                        if (mapdata.map[x, k] == ONE) nifu = true;
                    }
                    if (nifu == true)
                    {
                        nifu = false;
                        continue;
                    }
                }
                if (mapdata.map[x, y] == 0)
                {
                    xynum = ReturnXYnum(x, y);
                    motikinnshow.transform.Find(xynum.ToString()).gameObject.SetActive(true);
                }


            }
        }
       

    }

   

}

