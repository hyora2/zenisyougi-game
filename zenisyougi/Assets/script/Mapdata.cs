using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mapdata : MonoBehaviour
{

    const int mapWidth = 8; //7*7なので。ローカル座標をそのまま使えるように、1~7を使う。（0は使用しない）また、今後正方形であることは変更しないのでWidthのみの定義
    public int GetmapWidth(){return mapWidth;}
    public int[,] map = new int[mapWidth,mapWidth];

    public Dictionary<int, int> GetKomakindToIndexnum = new Dictionary<int, int>
    {
        { 1, 0},
        {5, 1},
        {10, 2},
        {50, 3},
        {100, 4},
        {500, 5},
    };

    /// <summary>
    /// index 0 ...1yen
    ///       1 ...5yen
    ///       2 ...10yen
    ///       3 ...50
    ///       4 ...100
    ///       5 ...500
    ///       6 ...sum
    /// </summary>
    public List<int[]> motikinnLIST = new List<int[]>
    {
        new int[7]{0,0,0,0,0,0,0},
        new int[7]{0,0,0,0,0,0,0},

    };



    /// <summary>
    /// index 0 ...1yen
    ///       1 ...5yen
    ///       2 ...10yen
    ///       3 ...50
    ///       4 ...100
    /// </summary>
    public int[] P1motikinn = new int[6];
    public int P1motikinnsum;
    public int[] P2motikinn = new int[6];
    public int P2motikinnsum;

    public Text P1Text1;
    public Text P1Text5;
    public Text P1Text10;
    public Text P1Text50;
    public Text P1Text100;
    public Text P1sum;

    public Text P2Text1;
    public Text P2Text5;
    public Text P2Text10;
    public Text P2Text50;
    public Text P2Text100;
    public Text P2sum;


    public List<GameObject> Kdatalist = new List<GameObject>();

    ToChangePoint toChangePoint;

 


    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < mapWidth; i++)
        {
            for(int j = 0; j < mapWidth; j++)
            {
                map[i, j] = 0;
            }
        }
        for(int i = 0; i < 6; i++)
        {
            P1motikinn[i] = 0;
            P2motikinn[i] = 0;
        }

        P1motikinnsum = 0;
        P2motikinnsum = 0;

        //初期位置のデータセット
        map[1, 2] = 1;
        map[2, 2] = 5;
        map[3, 2] = 10;
        map[4, 2] = 100;
        map[5, 2] = 10;
        map[6, 2] = 5;
        map[7, 2] = 1;
        map[3, 1] = 50;
        map[5, 1] = 50;
        map[4, 1] = 500;

        map[1, 6] = -1;
        map[2, 6] = -5;
        map[3, 6] = -10;
        map[4, 6] = -100;
        map[5, 6] = -10;
        map[6, 6] = -5;
        map[7, 6] = -1;
        map[3, 7] = -50;
        map[5, 7] = -50;
        map[4, 7] = -500;

        TextUpdate();

    }


    public void TextUpdate()
    {
        P1Text1.text = P1motikinn[0].ToString();
        P1Text5.text = P1motikinn[1].ToString();
        P1Text10.text = P1motikinn[2].ToString();
        P1Text50.text = P1motikinn[3].ToString();
        P1Text100.text = P1motikinn[4].ToString();
        P1sum.text = P1motikinnsum.ToString();

        P2Text1.text = P2motikinn[0].ToString();
        P2Text5.text = P2motikinn[1].ToString();
        P2Text10.text = P2motikinn[2].ToString();
        P2Text50.text = P2motikinn[3].ToString();
        P2Text100.text = P2motikinn[4].ToString();
        P2sum.text = P2motikinnsum.ToString();


    }

    public void Motikinnsum()
    {
        P1motikinnsum = P1motikinn[0] + (5 * P1motikinn[1]) + (10 * P1motikinn[2]) + (50 * P1motikinn[3]) + (100 * P1motikinn[4]) + (500 * P1motikinn[5]);
        P2motikinnsum = P2motikinn[0] + (5 * P2motikinn[1]) + (10 * P2motikinn[2]) + (50 * P2motikinn[3]) + (100 * P2motikinn[4]) + (500 * P2motikinn[5]);

    }


}



