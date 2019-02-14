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

    private int RetObjindexnum(int TP, int k)
    {
        if(TP == 1)
        {
            if(k == 1) { return 1; }
            else if(k == 5) { return 3; }
            else if(k == 10) { return 5; }
            else if(k == 50) { return 7; }
            else if(k == 100) { return 9; }
            else if(k == 500) { return 11; }

        }
        else if(TP == 2)
        {
            if (k == 1) { return 2; }
            else if (k == 5) { return 4; }
            else if (k == 10) { return 6; }
            else if (k == 50) { return 8; }
            else if (k == 100) { return 10; }
            else if (k == 500) { return 12; }

        }
        return -1;

    }


}
