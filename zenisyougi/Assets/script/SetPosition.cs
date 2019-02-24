using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPosition : MonoBehaviour
{

    /// <summary>
    /// The okane.
    /// [1][2].1yen_1,2
    /// [3][4].5yen_1,2
    /// [5][6].10yen_1,2
    /// [7][8].50yen_1,2
    /// [9][10].100yen_1,2
    /// [11][12].500yen_1,2
    /// 
    /// [0].null
    /// 
    ///  Instantiate( Type[number],new Vector2(producePosition,Random.Range(-4.5f, 5.5f)), transform.rotation);
    /// 
    /// 
    /// </summary>
    public GameObject[] okane = new GameObject[13];
    Mapdata mapdata;

    // Start is called before the first frame update
    void Start()
    {
        ToChangePoint toChangePoint = GetComponent<ToChangePoint>();
         mapdata = GetComponent<Mapdata>();

        Vector3 pos;

        pos = new Vector3(toChangePoint.ToWorldPoint(1), toChangePoint.ToWorldPoint(2), -1f);
        mapdata.Kdatalist.Add( Instantiate(okane[1], pos, transform.rotation));
        pos = new Vector3(toChangePoint.ToWorldPoint(2), toChangePoint.ToWorldPoint(2), -1f);
        mapdata.Kdatalist.Add( Instantiate(okane[3], pos, transform.rotation));
        pos = new Vector3(toChangePoint.ToWorldPoint(3), toChangePoint.ToWorldPoint(2), -1f);
        mapdata.Kdatalist.Add( Instantiate(okane[5], pos, transform.rotation));
        pos = new Vector3(toChangePoint.ToWorldPoint(4), toChangePoint.ToWorldPoint(2), -1f);
        mapdata.Kdatalist.Add( Instantiate(okane[9], pos, transform.rotation));
        pos = new Vector3(toChangePoint.ToWorldPoint(5), toChangePoint.ToWorldPoint(2), -1f);
        mapdata.Kdatalist.Add( Instantiate(okane[5], pos, transform.rotation));
        pos = new Vector3(toChangePoint.ToWorldPoint(6), toChangePoint.ToWorldPoint(2), -1f);
        mapdata.Kdatalist.Add( Instantiate(okane[3], pos, transform.rotation));
        pos = new Vector3(toChangePoint.ToWorldPoint(7), toChangePoint.ToWorldPoint(2), -1f);
        mapdata.Kdatalist.Add( Instantiate(okane[1], pos, transform.rotation));
        pos = new Vector3(toChangePoint.ToWorldPoint(3), toChangePoint.ToWorldPoint(1), -1f);
        mapdata.Kdatalist.Add( Instantiate(okane[7], pos, transform.rotation));
        pos = new Vector3(toChangePoint.ToWorldPoint(5), toChangePoint.ToWorldPoint(1), -1f);
        mapdata.Kdatalist.Add( Instantiate(okane[7], pos, transform.rotation));
        pos = new Vector3(toChangePoint.ToWorldPoint(4), toChangePoint.ToWorldPoint(1), -1f);
        mapdata.Kdatalist.Add( Instantiate(okane[11], pos, transform.rotation));

        pos = new Vector3(toChangePoint.ToWorldPoint(1), toChangePoint.ToWorldPoint(6), -1f);
        mapdata.Kdatalist.Add( Instantiate(okane[2], pos, transform.rotation));
        pos = new Vector3(toChangePoint.ToWorldPoint(2), toChangePoint.ToWorldPoint(6), -1f);
        mapdata.Kdatalist.Add( Instantiate(okane[4], pos, transform.rotation));
        pos = new Vector3(toChangePoint.ToWorldPoint(3), toChangePoint.ToWorldPoint(6), -1f);
        mapdata.Kdatalist.Add( Instantiate(okane[6], pos, transform.rotation));
        pos = new Vector3(toChangePoint.ToWorldPoint(4), toChangePoint.ToWorldPoint(6), -1f);
        mapdata.Kdatalist.Add( Instantiate(okane[10], pos, transform.rotation));
        pos = new Vector3(toChangePoint.ToWorldPoint(5), toChangePoint.ToWorldPoint(6), -1f);
        mapdata.Kdatalist.Add( Instantiate(okane[6], pos, transform.rotation));
        pos = new Vector3(toChangePoint.ToWorldPoint(6), toChangePoint.ToWorldPoint(6), -1f);
        mapdata.Kdatalist.Add( Instantiate(okane[4], pos, transform.rotation));
        pos = new Vector3(toChangePoint.ToWorldPoint(7), toChangePoint.ToWorldPoint(6), -1f);
        mapdata.Kdatalist.Add( Instantiate(okane[2], pos, transform.rotation));
        pos = new Vector3(toChangePoint.ToWorldPoint(3), toChangePoint.ToWorldPoint(7), -1f);
        mapdata.Kdatalist.Add( Instantiate(okane[8], pos, transform.rotation));
        pos = new Vector3(toChangePoint.ToWorldPoint(4), toChangePoint.ToWorldPoint(7), -1f);
        mapdata.Kdatalist.Add( Instantiate(okane[12], pos, transform.rotation));
        pos = new Vector3(toChangePoint.ToWorldPoint(5), toChangePoint.ToWorldPoint(7), -1f);
        mapdata.Kdatalist.Add( Instantiate(okane[8], pos, transform.rotation));

    }

    public void MBU(int k, int TP, Vector3 wp, int LPX, int LPY)
    {
        int indexnum;

        indexnum = RetObjindexnum(TP, k);
        mapdata.Kdatalist.Add(Instantiate(okane[indexnum], wp, transform.rotation));
        if(TP == 1)
        {
            mapdata.map[LPX, LPY] = k;
        }else if(TP == 2)
        {
            mapdata.map[LPX, LPY] = k * (-1);
        }


    }


    private Dictionary<int, int> P1objindexnum = new Dictionary<int, int>
    {
        {1, 1},
        {5, 3},
        {10, 5},
        {50, 7},
        {100, 9},
        {500, 11},

    };

    private Dictionary<int, int> P2objindexnum = new Dictionary<int, int>
    {
        {1, 2},
        {5, 4},
        {10, 6},
        {50, 8},
        {100, 10},
        {500, 12},

    };

    private int RetObjindexnum(int TP, int k)
    {
        if(TP == 1)
        {
            return P1objindexnum[k];
        }
        else if(TP == 2)
        {
            return P2objindexnum[k];
        }

        return -1;
    }

}
