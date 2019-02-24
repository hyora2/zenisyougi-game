using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class memo : MonoBehaviour
{
    /*
     * koma.cs//
     * public void ShowMove(int kind, int TP)  の中
     * 
     *  if (TP == 1)
        {//自ターン
            switch (kind)
            {
                #region 1case1

                case 1:
                    if (LocalKomaPos.y <= 6) 
                    {
                        if (LocalKomaPos.x >= 2)
                        {
                            if (mapdata.map[(int)LocalKomaPos.x - 1, (int)LocalKomaPos.y + 1] <= 0)
                            {
                                transform.Find("select06").gameObject.SetActive(true);
                            }
                        }
                        if (mapdata.map[(int)LocalKomaPos.x, (int)LocalKomaPos.y + 1] <= 0)
                        {
                            transform.Find("select07").gameObject.SetActive(true);
                        }
                        if (LocalKomaPos.x <= 6)
                        {
                            if (mapdata.map[(int)LocalKomaPos.x + 1, (int)LocalKomaPos.y + 1] <= 0)
                            {
                                transform.Find("select08").gameObject.SetActive(true);
                            }
                        }
                    }
                    break;
                #endregion

                #region 1case5


                case 5:

                    if (LocalKomaPos.y <= 6) {
                        if (LocalKomaPos.x >= 2)
                        {
                            if (mapdata.map[(int)LocalKomaPos.x - 1, (int)LocalKomaPos.y + 1] <= 0)
                            {
                                transform.Find("select06").gameObject.SetActive(true);
                            }

                        }
                        if (LocalKomaPos.x <= 6)
                        {
                            if (mapdata.map[(int)LocalKomaPos.x + 1, (int)LocalKomaPos.y + 1] <= 0)
                            {
                                transform.Find("select08").gameObject.SetActive(true);
                            }
                        }
                    }

                    if (LocalKomaPos.y >= 2) {
                        if (mapdata.map[(int)LocalKomaPos.x, (int)LocalKomaPos.y - 1] <= 0)
                        {
                            transform.Find("select16").gameObject.SetActive(true);
                        }

                    }
                    break;
                #endregion

                #region 1case10


                case 10:
                    if (LocalKomaPos.y <= 6)
                    {
                        if (mapdata.map[(int)LocalKomaPos.x , (int)LocalKomaPos.y + 1] <= 0)
                        {
                            transform.Find("select07").gameObject.SetActive(true);
                        }

                    }


                    if (LocalKomaPos.y >= 2)
                    {
                        if (LocalKomaPos.x >= 2)
                        {
                            if (mapdata.map[(int)LocalKomaPos.x - 1, (int)LocalKomaPos.y - 1] <= 0)
                            {
                                transform.Find("select15").gameObject.SetActive(true);
                            }
                        }
                        if (mapdata.map[(int)LocalKomaPos.x , (int)LocalKomaPos.y - 1] <= 0)
                        {
                            transform.Find("select16").gameObject.SetActive(true);
                        }

                        if (LocalKomaPos.x <= 6)
                        {
                            if (mapdata.map[(int)LocalKomaPos.x + 1, (int)LocalKomaPos.y - 1] <= 0)
                            {
                                transform.Find("select17").gameObject.SetActive(true);
                            }
                        }
                    }
                    break;
                #endregion

                #region 1case50

                case 50:
                    if (LocalKomaPos.y <= 5)
                    {
                        if (LocalKomaPos.x >= 2)
                        {
                            if (mapdata.map[(int)LocalKomaPos.x - 1, (int)LocalKomaPos.y + 2] <= 0)
                            {
                                if (mapdata.map[(int)LocalKomaPos.x, (int)LocalKomaPos.y + 1] != -10 && mapdata.map[(int)LocalKomaPos.x, (int)LocalKomaPos.y + 1] != -100)
                                {
                                    transform.Find("select01").gameObject.SetActive(true);
                                }
                            }
                        }
                            if (mapdata.map[(int)LocalKomaPos.x, (int)LocalKomaPos.y + 2] <= 0)
                            {
                                if (mapdata.map[(int)LocalKomaPos.x, (int)LocalKomaPos.y + 1] != -10 && mapdata.map[(int)LocalKomaPos.x, (int)LocalKomaPos.y + 1] != -100)
                                {
                                    transform.Find("select02").gameObject.SetActive(true);
                                }
                            }
                        if (LocalKomaPos.x <= 6)
                        {
                            if (mapdata.map[(int)LocalKomaPos.x + 1, (int)LocalKomaPos.y + 2] <= 0)
                            {
                                if (mapdata.map[(int)LocalKomaPos.x, (int)LocalKomaPos.y + 1] != -10 && mapdata.map[(int)LocalKomaPos.x, (int)LocalKomaPos.y + 1] != -100)
                                {
                                    transform.Find("select03").gameObject.SetActive(true);
                                }
                            }
                        }
                    }
                    if (LocalKomaPos.x >= 2)
                    {
                        if (mapdata.map[(int)LocalKomaPos.x - 1, (int)LocalKomaPos.y] <= 0)
                        {
                            transform.Find("select11").gameObject.SetActive(true);
                        }
                    }
                    if (LocalKomaPos.x <= 6)
                    {
                        if (mapdata.map[(int)LocalKomaPos.x + 1, (int)LocalKomaPos.y] <= 0)
                        {
                            transform.Find("select12").gameObject.SetActive(true);
                        }
                    }

                    break;
                #endregion

                #region 1case100


                case 100:
                    if (LocalKomaPos.y <= 6)
                    { //上                 
                            if (LocalKomaPos.y <= 5)
                            {
                                if (mapdata.map[(int)LocalKomaPos.x, (int)LocalKomaPos.y + 1] == 0)
                                {
                                    if (mapdata.map[(int)LocalKomaPos.x, (int)LocalKomaPos.y + 2] <= 0)
                                    {
                                        transform.Find("select02").gameObject.SetActive(true);
                                    }
                                }
                            }

                        if (mapdata.map[(int)LocalKomaPos.x , (int)LocalKomaPos.y + 1] <= 0)
                        {
                            transform.Find("select07").gameObject.SetActive(true);
                        }
                     
                    }

                    if (LocalKomaPos.x <= 6)
                    {//右
                        if (LocalKomaPos.x <= 5)
                        {
                            if (mapdata.map[(int)LocalKomaPos.x + 1, (int)LocalKomaPos.y ] == 0)
                            {
                                if (mapdata.map[(int)LocalKomaPos.x + 2, (int)LocalKomaPos.y] <= 0)
                                {
                                    transform.Find("select13").gameObject.SetActive(true);
                                }
                            }
                        }

                        if (mapdata.map[(int)LocalKomaPos.x + 1, (int)LocalKomaPos.y] <= 0)
                        {
                            transform.Find("select12").gameObject.SetActive(true);
                        }

                    }
                   

                    if (LocalKomaPos.y >= 2)
                    {//下
                        if (LocalKomaPos.y >= 3)
                        {
                            if (mapdata.map[(int)LocalKomaPos.x, (int)LocalKomaPos.y - 1] == 0)
                            {
                                if (mapdata.map[(int)LocalKomaPos.x , (int)LocalKomaPos.y - 2] <= 0)
                                {
                                    transform.Find("select21").gameObject.SetActive(true);
                                }
                            }
                        }

                        if (mapdata.map[(int)LocalKomaPos.x, (int)LocalKomaPos.y - 1] <= 0)
                        {
                            transform.Find("select16").gameObject.SetActive(true);
                        }

                    }

                    if (LocalKomaPos.x >= 2)
                    {//左
                        if (LocalKomaPos.x >= 3)
                        {
                            if (mapdata.map[(int)LocalKomaPos.x - 1, (int)LocalKomaPos.y ] == 0)
                            {
                                if (mapdata.map[(int)LocalKomaPos.x - 2, (int)LocalKomaPos.y ] <= 0)
                                {
                                    transform.Find("select10").gameObject.SetActive(true);
                                }
                            }
                        }

                        if (mapdata.map[(int)LocalKomaPos.x - 1, (int)LocalKomaPos.y ] <= 0)
                        {
                            transform.Find("select11").gameObject.SetActive(true);
                        }

                    }


                    break;
                #endregion

                #region 1case500


                case 500:
                    if (LocalKomaPos.y <= 6)
                    {
                        if (LocalKomaPos.x >= 2)
                        {
                            if (mapdata.map[(int)LocalKomaPos.x - 1, (int)LocalKomaPos.y + 1] <= 0)
                            {
                                transform.Find("select06").gameObject.SetActive(true);
                            }
                        }
                        if (mapdata.map[(int)LocalKomaPos.x, (int)LocalKomaPos.y + 1] <= 0)
                        {
                            transform.Find("select07").gameObject.SetActive(true);
                        }

                        if (LocalKomaPos.x <= 6)
                        {
                            if (mapdata.map[(int)LocalKomaPos.x + 1, (int)LocalKomaPos.y + 1] <= 0)
                            {
                                transform.Find("select08").gameObject.SetActive(true);
                            }
                        }
                    }

                    if (LocalKomaPos.x >= 2)
                    {
                        if (mapdata.map[(int)LocalKomaPos.x - 1, (int)LocalKomaPos.y] <= 0)
                        {
                            transform.Find("select11").gameObject.SetActive(true);
                        }
                    }
                    if (LocalKomaPos.x <= 6)
                    {
                        if (mapdata.map[(int)LocalKomaPos.x + 1, (int)LocalKomaPos.y] <= 0)
                        {
                            transform.Find("select12").gameObject.SetActive(true);
                        }
                    }

                    if (LocalKomaPos.y >= 2)
                    {
                        if (LocalKomaPos.x >= 2)
                        {
                            if (mapdata.map[(int)LocalKomaPos.x - 1, (int)LocalKomaPos.y - 1] <= 0)
                            {
                                transform.Find("select15").gameObject.SetActive(true);
                            }
                        }
                        if (mapdata.map[(int)LocalKomaPos.x, (int)LocalKomaPos.y - 1] <= 0)
                        {
                            transform.Find("select16").gameObject.SetActive(true);
                        }
                        if (LocalKomaPos.x <= 6)
                        {
                            if (mapdata.map[(int)LocalKomaPos.x + 1, (int)LocalKomaPos.y - 1] <= 0)
                            {
                                transform.Find("select17").gameObject.SetActive(true);
                            }
                        }
                    }
                    break;

                    #endregion
            }

        }
        else if(TP == 2)
        {
            switch (kind)
            {
                #region 2case1
                case 1:
                    if (LocalKomaPos.y >= 2)
                    {
                        if (LocalKomaPos.x >= 2)
                        {
                            if (mapdata.map[(int)LocalKomaPos.x - 1, (int)LocalKomaPos.y - 1] >= 0)
                            {
                                transform.Find("select15").gameObject.SetActive(true);
                            }
                        }
                        if (mapdata.map[(int)LocalKomaPos.x, (int)LocalKomaPos.y - 1] >= 0)
                        {
                            transform.Find("select16").gameObject.SetActive(true);
                        }
                        if (LocalKomaPos.x <= 6)
                        {
                            if (mapdata.map[(int)LocalKomaPos.x + 1, (int)LocalKomaPos.y - 1] >= 0)
                            {
                                transform.Find("select17").gameObject.SetActive(true);
                            }
                        }
                    }
                    break;



            
                #endregion

                #region 2case5
                case 5:

                    if (LocalKomaPos.y >= 2)
                    {
                        if (LocalKomaPos.x >= 2)
                        {
                            if (mapdata.map[(int)LocalKomaPos.x - 1, (int)LocalKomaPos.y - 1] >= 0)
                            {
                                transform.Find("select15").gameObject.SetActive(true);
                            }

                        }
                        if (LocalKomaPos.x <= 6)
                        {
                            if (mapdata.map[(int)LocalKomaPos.x + 1, (int)LocalKomaPos.y - 1] >= 0)
                            {
                                transform.Find("select17").gameObject.SetActive(true);
                            }
                        }
                    }

                    if (LocalKomaPos.y <= 6)
                    {
                        if (mapdata.map[(int)LocalKomaPos.x, (int)LocalKomaPos.y + 1] >= 0)
                        {
                            transform.Find("select07").gameObject.SetActive(true);
                        }

                    }
                    break;


               
                #endregion

                #region 2case10
                case 10:

                    if (LocalKomaPos.y >= 2)
                    {
                        if (mapdata.map[(int)LocalKomaPos.x, (int)LocalKomaPos.y - 1] >= 0)
                        {
                            transform.Find("select16").gameObject.SetActive(true);
                        }

                    }


                    if (LocalKomaPos.y <= 6)
                    {
                        if (LocalKomaPos.x >= 2)
                        {
                            if (mapdata.map[(int)LocalKomaPos.x - 1, (int)LocalKomaPos.y + 1] >= 0)
                            {
                                transform.Find("select06").gameObject.SetActive(true);
                            }
                        }
                        if (mapdata.map[(int)LocalKomaPos.x, (int)LocalKomaPos.y + 1] >= 0)
                        {
                            transform.Find("select07").gameObject.SetActive(true);
                        }

                        if (LocalKomaPos.x <= 6)
                        {
                            if (mapdata.map[(int)LocalKomaPos.x + 1, (int)LocalKomaPos.y + 1] >= 0)
                            {
                                transform.Find("select08").gameObject.SetActive(true);
                            }
                        }
                    }
                    break;

               
                #endregion

                #region 2case50 
                case 50:

                    if (LocalKomaPos.y >= 3)
                    {
                        if (LocalKomaPos.x >= 2)
                        {
                            if (mapdata.map[(int)LocalKomaPos.x - 1, (int)LocalKomaPos.y - 2] >= 0)
                            {
                                if (mapdata.map[(int)LocalKomaPos.x, (int)LocalKomaPos.y - 1] != 10 && mapdata.map[(int)LocalKomaPos.x, (int)LocalKomaPos.y - 1] != 100)
                                {
                                    transform.Find("select20").gameObject.SetActive(true);
                                }
                            }
                        }
                        if (mapdata.map[(int)LocalKomaPos.x, (int)LocalKomaPos.y - 2] >= 0)
                        {
                            if (mapdata.map[(int)LocalKomaPos.x, (int)LocalKomaPos.y - 1] != 10 && mapdata.map[(int)LocalKomaPos.x, (int)LocalKomaPos.y - 1] != 100)
                            {
                                transform.Find("select21").gameObject.SetActive(true);
                            }
                        }
                        if (LocalKomaPos.x <= 6)
                        {
                            if (mapdata.map[(int)LocalKomaPos.x + 1, (int)LocalKomaPos.y - 2] >= 0)
                            {
                                if (mapdata.map[(int)LocalKomaPos.x, (int)LocalKomaPos.y - 1] != 10 && mapdata.map[(int)LocalKomaPos.x, (int)LocalKomaPos.y - 1] != 100)
                                {
                                    transform.Find("select22").gameObject.SetActive(true);
                                }
                            }
                        }
                    }
                    if (LocalKomaPos.x >= 2)
                    {
                        if (mapdata.map[(int)LocalKomaPos.x - 1, (int)LocalKomaPos.y] >= 0)
                        {
                            transform.Find("select11").gameObject.SetActive(true);
                        }
                    }
                    if (LocalKomaPos.x <= 6)
                    {
                        if (mapdata.map[(int)LocalKomaPos.x + 1, (int)LocalKomaPos.y] >= 0)
                        {
                            transform.Find("select12").gameObject.SetActive(true);
                        }
                    }

                    break;


                #endregion

                #region 2case100

                case 100:

                    if (LocalKomaPos.y <= 6)
                    { //上                 
                        if (LocalKomaPos.y <= 5)
                        {
                            if (mapdata.map[(int)LocalKomaPos.x, (int)LocalKomaPos.y + 1] == 0)
                            {
                                if (mapdata.map[(int)LocalKomaPos.x, (int)LocalKomaPos.y + 2] >= 0)
                                {
                                    transform.Find("select02").gameObject.SetActive(true);
                                }
                            }
                        }

                        if (mapdata.map[(int)LocalKomaPos.x, (int)LocalKomaPos.y + 1] >= 0)
                        {
                            transform.Find("select07").gameObject.SetActive(true);
                        }

                    }

                    if (LocalKomaPos.x <= 6)
                    {//右
                        if (LocalKomaPos.x <= 5)
                        {
                            if (mapdata.map[(int)LocalKomaPos.x + 1, (int)LocalKomaPos.y] == 0)
                            {
                                if (mapdata.map[(int)LocalKomaPos.x + 2, (int)LocalKomaPos.y] >= 0)
                                {
                                    transform.Find("select13").gameObject.SetActive(true);
                                }
                            }
                        }

                        if (mapdata.map[(int)LocalKomaPos.x + 1, (int)LocalKomaPos.y] >= 0)
                        {
                            transform.Find("select12").gameObject.SetActive(true);
                        }

                    }


                    if (LocalKomaPos.y >= 2)
                    {//下
                        if (LocalKomaPos.y >= 3)
                        {
                            if (mapdata.map[(int)LocalKomaPos.x, (int)LocalKomaPos.y - 1] == 0)
                            {
                                if (mapdata.map[(int)LocalKomaPos.x, (int)LocalKomaPos.y - 2] >= 0)
                                {
                                    transform.Find("select21").gameObject.SetActive(true);
                                }
                            }
                        }

                        if (mapdata.map[(int)LocalKomaPos.x, (int)LocalKomaPos.y - 1] >= 0)
                        {
                            transform.Find("select16").gameObject.SetActive(true);
                        }

                    }

                    if (LocalKomaPos.x >= 2)
                    {//左
                        if (LocalKomaPos.x >= 3)
                        {
                            if (mapdata.map[(int)LocalKomaPos.x - 1, (int)LocalKomaPos.y] == 0)
                            {
                                if (mapdata.map[(int)LocalKomaPos.x - 2, (int)LocalKomaPos.y] >= 0)
                                {
                                    transform.Find("select10").gameObject.SetActive(true);
                                }
                            }
                        }

                        if (mapdata.map[(int)LocalKomaPos.x - 1, (int)LocalKomaPos.y] >= 0)
                        {
                            transform.Find("select11").gameObject.SetActive(true);
                        }

                    }


                    break;



                #endregion

                #region 2case500


                case 500:
                    if (LocalKomaPos.y <= 6)
                    {
                        if (LocalKomaPos.x >= 2)
                        {
                            if (mapdata.map[(int)LocalKomaPos.x - 1, (int)LocalKomaPos.y + 1] >= 0)
                            {
                                transform.Find("select06").gameObject.SetActive(true);
                            }
                        }
                        if (mapdata.map[(int)LocalKomaPos.x, (int)LocalKomaPos.y + 1] >= 0)
                        {
                            transform.Find("select07").gameObject.SetActive(true);
                        }

                        if (LocalKomaPos.x <= 6)
                        {
                            if (mapdata.map[(int)LocalKomaPos.x + 1, (int)LocalKomaPos.y + 1] >= 0)
                            {
                                transform.Find("select08").gameObject.SetActive(true);
                            }
                        }
                    }

                    if (LocalKomaPos.x >= 2)
                    {
                        if (mapdata.map[(int)LocalKomaPos.x - 1, (int)LocalKomaPos.y] >= 0)
                        {
                            transform.Find("select11").gameObject.SetActive(true);
                        }
                    }
                    if (LocalKomaPos.x <= 6)
                    {
                        if (mapdata.map[(int)LocalKomaPos.x + 1, (int)LocalKomaPos.y] >= 0)
                        {
                            transform.Find("select12").gameObject.SetActive(true);
                        }
                    }

                    if (LocalKomaPos.y >= 2)
                    {
                        if (LocalKomaPos.x >= 2)
                        {
                            if (mapdata.map[(int)LocalKomaPos.x - 1, (int)LocalKomaPos.y - 1] >= 0)
                            {
                                transform.Find("select15").gameObject.SetActive(true);
                            }
                        }
                        if (mapdata.map[(int)LocalKomaPos.x, (int)LocalKomaPos.y - 1] >= 0)
                        {
                            transform.Find("select16").gameObject.SetActive(true);
                        }
                        if (LocalKomaPos.x <= 6)
                        {
                            if (mapdata.map[(int)LocalKomaPos.x + 1, (int)LocalKomaPos.y - 1] >= 0)
                            {
                                transform.Find("select17").gameObject.SetActive(true);
                            }
                        }
                    }
                    break;
                    #endregion
                
            }





        }

     *   

     */



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
