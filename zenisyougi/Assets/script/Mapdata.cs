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
        {-1, 6}, //-1のkeyをsumのインデックスナンバーとする

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

    public Text[] Texts1 = new Text[7];
    public Text[] Texts2 = new Text[7];

    //public int[] P1motikinn = new int[7];
   // public int[] P2motikinn = new int[7];

    public int[,] motikinn = new int[2, 7];
  
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
        for(int i = 0; i < 2; i++)
        {
            for (int j = 0; j < 7; j++)
                motikinn[i, j] = 0;
        }

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
        for(int i = 0; i < 7; i++)
        {
            if (i == 5) continue;
            Texts1[i].text = motikinn[0,i].ToString();
            Texts2[i].text = motikinn[1,i].ToString();
        }

    }

    public void Motikinnsum()
    {
        motikinn[0, 6] = motikinn[0,0] + (5 * motikinn[0,1]) + (10 * motikinn[0,2]) + (50 * motikinn[0,3]) + (100 * motikinn[0,4]) + (500 * motikinn[0,5]);
        motikinn[1,6] = motikinn[1,0] + (5 * motikinn[1,1]) + (10 * motikinn[1,2]) + (50 * motikinn[1,3]) + (100 * motikinn[1,4]) + (500 * motikinn[1,5]);

    }


}



