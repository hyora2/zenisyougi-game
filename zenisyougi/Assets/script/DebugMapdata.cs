using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugMapdata : MonoBehaviour
{
    Mapdata mapdata;
    [SerializeField] int[] Map = new int[64];

   
    // Update is called once per frame
    void Update()
    {

        mapdata = GetComponent<Mapdata>();
        mapinfo();


    }

    void mapinfo()
    {
        for(int y = 0; y < 8; y++)
        {
            for (int x = 0; x < 8; x++)
            {
                Map[x + y * 8] = mapdata.map[x, y];

            }
        }
    }




}
