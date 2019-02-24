using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KomaData : MonoBehaviour
{
    [SerializeField] const int RelativeAreaWidth = 5;
    public int GetRelativeAreaWidth() { return RelativeAreaWidth; }
    [SerializeField] const int CenterPoint = (RelativeAreaWidth / 2) + 1;
    public int GetCenterPoint(){ return CenterPoint; }

    public const int LONGRANGEKOMAKIND = 100;
    public List<int> BLOCKKOMAKINDLIST = new List<int>
    {
        5,
        100,
    };

    public List<int> JUMPKOMAKINDLIST = new List<int>
    {
        50,

    };

  
    public List<string> komaNamesLIST = new List<string>
    {
        "1yen1(Clone)",
        "5yen1(Clone)",
        "10yen1(Clone)",
        "50yen1(Clone)",
        "100yen1(Clone)",
        "500yen1(Clone)",
        "1yen2(Clone)",
        "5yen2(Clone)",
        "10yen2(Clone)",
        "50yen2(Clone)",
        "100yen2(Clone)",
        "500yen2(Clone)",

    };

  
    public int PorESet(string komaname)
    {
        for (int i = 0; i < komaNamesLIST.Count; i++)
        {
            if (i < (komaNamesLIST.Count / 2))
            {
                if (komaname == komaNamesLIST[i]) return 1;
            }
            else if (i >= (komaNamesLIST.Count / 2) && i < komaNamesLIST.Count)
            {
                if (komaname == komaNamesLIST[i]) return 2;
            }
            else
            {  
                Debug.Log("name set error.");
            }
        }
        return 0;
    }

    public Dictionary<int, List<bool>> komaMovableInfos = new Dictionary<int, List<bool>>
    {
        {1,new List<bool>{
        false,false,false,false,false,
        false,true,true,true,false,
        false,false,    false,false,
        false,false,false,false,false,
        false,false,false,false,false,
        } },

        {5,new List<bool>{
        false,false,false,false,false,
        false,true,false,true,false,
        false,false,     false,false,
        false,true,false,true,false,
        false,false,false,false,false,
        } },

        {10,new List<bool>{
        false,false,false,false,false,
        false,true,true,true,false,
        false,true,    true,false,
        false,false,true,false,false,
        false,false,false,false,false,
        } },

        {50,new List<bool>{
        false,true,true,true,false,
        false,false,false,false,false,
        false,true,      true,false,
        false,false,false,false,false,
        false,false,false,false,false,
        } },

        {100,new List<bool>{
        false,false,true,false,false,
        false,false,true,false,false,
        true, true,       true,true,
        false,false,true,false,false,
        false,false,true,false,false,
        } },

        {500,new List<bool>{
        false,false,false,false,false,
        false,true,true,true,false,
        false,true,     true,false,
        false,true,true,true,false,
        false,false,false,false,false,
        } },

        {0,new List<bool>{
        false,false,false,false,false,
        false,false,false,false,false,
        false,false,    false,false,
        false,false,false,false,false,
        false,false,false,false,false,
        } },
    };

    /*
    public List<Vector2> RelativeKomaData = new List<Vector2>
    {
        new Vector2(-2f,2f),new Vector2(-1f,2f),new Vector2(0f,2f),new Vector2(1f,2f),new Vector2(2f,2f),
        new Vector2(-2f, 1f),new Vector2(-1f, 1f),new Vector2(0f, 1f),new Vector2(1f, 1f),new Vector2(2f, 1f),
        new Vector2(-2f,0f),new Vector2(-1f, 0f),new Vector2(0f,0f),new Vector2(1f,0f),new Vector2(2f,0f),
        new Vector2(-2f,-1f),new Vector2(-1f,-1f),new Vector2(0f,-1f),new Vector2(1f,-1f),new Vector2(2f,-1f),
        new Vector2(-2f,-2f),new Vector2(-1f,-2f),new Vector2(0f,-2f),new Vector2(1f,-2f),new Vector2(2f,-2f),
    };
    */

    private List<int> komaKinds = new List<int>
    {
        1,
        5,
        10,
        50,
        100,
        500,
    };

    public int KomakindSet(string komaname)
    {
        int result = 0;
        for (int i = 0; i < komaNamesLIST.Count; i++)
        {
            if (komaname.Equals(komaNamesLIST[i]))
            {
                if (i >= (komaNamesLIST.Count / 2)) { result = komaKinds[i - (komaNamesLIST.Count / 2)]; } else { result = komaKinds[i]; }

            }
        }
        return result;
    }

}
