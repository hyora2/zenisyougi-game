using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeButton : MonoBehaviour
{
    Mapdata mapdata;
    Gamecontroller gamecontroller;


    // Start is called before the first frame update
    void Start()
    {
        mapdata = GetComponent<Mapdata>();
        gamecontroller = GetComponent<Gamecontroller>();
       
    }

    public void Change1Up1()
    {
        gamecontroller = GetComponent<Gamecontroller>();
        mapdata = GetComponent<Mapdata>();

        if (gamecontroller.turnplayer != 1) return;
        if (mapdata.motikinn[0, 0] < 5) return;
        if (mapdata.motikinn[0, 1] >= 10) return;
        mapdata.motikinn[0, 0] = mapdata.motikinn[0,0] - 5;
        mapdata.motikinn[0,1]++;
        mapdata.TextUpdate();
        return;
    }

    public void Break5_1()
    {
        mapdata = GetComponent<Mapdata>();
        gamecontroller = GetComponent<Gamecontroller>();
        if (gamecontroller.turnplayer != 1) return;
        if (mapdata.motikinn[0,1] <= 0) return;
        if (mapdata.motikinn[0,0] >= 10) return;
        mapdata.motikinn[0,1]--;
        mapdata.motikinn[0,0] = mapdata.motikinn[0,0] + 5;
        mapdata.TextUpdate();
        return;
    }

    public void Change5Up1()
    {
        mapdata = GetComponent<Mapdata>();
        gamecontroller = GetComponent<Gamecontroller>();
        if (gamecontroller.turnplayer != 1) return;
        if (mapdata.motikinn[0,1] < 2) return;
        if (mapdata.motikinn[0,2] >= 10) return;
        mapdata.motikinn[0,1] = mapdata.motikinn[0,1] - 2;
        mapdata.motikinn[0,2]++;
        mapdata.TextUpdate();
        return;
    }

    public void Break10_1()
    {
        mapdata = GetComponent<Mapdata>();
        gamecontroller = GetComponent<Gamecontroller>();
        if (gamecontroller.turnplayer != 1) return;
        if (mapdata.motikinn[0,2] <= 0) return;
        if (mapdata.motikinn[0,1] >= 10) return;
        mapdata.motikinn[0,2]--;
        mapdata.motikinn[0,1] = mapdata.motikinn[0,1] + 2;
        mapdata.TextUpdate();
        return;
    }

    public void Change10Up1()
    {
        mapdata = GetComponent<Mapdata>();
        gamecontroller = GetComponent<Gamecontroller>();
        if (gamecontroller.turnplayer != 1) return;
        if (mapdata.motikinn[0,2] < 5) return;
        if (mapdata.motikinn[0,3] >= 10) return;
        mapdata.motikinn[0,2] = mapdata.motikinn[0,2] - 5;
        mapdata.motikinn[0,3]++;
        mapdata.TextUpdate();
        return;
    }

    public void Break50_1()
    {
        mapdata = GetComponent<Mapdata>();
        gamecontroller = GetComponent<Gamecontroller>();
        if (gamecontroller.turnplayer != 1) return;
        if (mapdata.motikinn[0,3] <= 0) return;
        if (mapdata.motikinn[0,2] >= 10) return;
        mapdata.motikinn[0,3]--;
        mapdata.motikinn[0,2] = mapdata.motikinn[0,2] + 5;
        mapdata.TextUpdate();
        return;
    }
    public void Change50Up1()
    {
        mapdata = GetComponent<Mapdata>();
        gamecontroller = GetComponent<Gamecontroller>();
        if (gamecontroller.turnplayer != 1) return;
        if (mapdata.motikinn[0,3] < 2) return;
        if (mapdata.motikinn[0,4] >= 10) return;
        mapdata.motikinn[0,3] = mapdata.motikinn[0,3] - 2;
        mapdata.motikinn[0,4]++;
        mapdata.TextUpdate();
        return;
    }

    public void Break100_1()
    {
        mapdata = GetComponent<Mapdata>();
        gamecontroller = GetComponent<Gamecontroller>();
        if (gamecontroller.turnplayer != 1) return;
        if (mapdata.motikinn[0,4] <= 0) return;
        if (mapdata.motikinn[0,3] >= 10) return;
        mapdata.motikinn[0,4]--;
        mapdata.motikinn[0,3] = mapdata.motikinn[0,3] + 2;
        mapdata.TextUpdate();
        return;
    }

    public void Change1Up2()
    {
        mapdata = GetComponent<Mapdata>();
        gamecontroller = GetComponent<Gamecontroller>();
        if (gamecontroller.turnplayer != 2) return;
        if (mapdata.motikinn[1,0] < 5) return;
        if (mapdata.motikinn[1,1] >= 10) return;
        mapdata.motikinn[1,0] = mapdata.motikinn[1,0] - 5;
        mapdata.motikinn[1,1]++;
        mapdata.TextUpdate();
        return;
    }

    public void Break5_2()
    {
        mapdata = GetComponent<Mapdata>();
        gamecontroller = GetComponent<Gamecontroller>();
        if (gamecontroller.turnplayer != 2) return;
        if (mapdata.motikinn[1,1] <= 0) return;
        if (mapdata.motikinn[1,0] >= 10) return;
        mapdata.motikinn[1,1]--;
        mapdata.motikinn[1,0] = mapdata.motikinn[1,0] + 5;
        mapdata.TextUpdate();
        return;
    }

    public void Change5Up2()
    {
        mapdata = GetComponent<Mapdata>();
        gamecontroller = GetComponent<Gamecontroller>();
        if (gamecontroller.turnplayer != 2) return;
        if (mapdata.motikinn[1,1] < 2) return;
        if (mapdata.motikinn[1,2] >= 10) return;
        mapdata.motikinn[1,1] = mapdata.motikinn[1,1] - 2;
        mapdata.motikinn[1,2]++;
        mapdata.TextUpdate();
        return;
    }

    public void Break10_2()
    {
        mapdata = GetComponent<Mapdata>();
        gamecontroller = GetComponent<Gamecontroller>();
        if (gamecontroller.turnplayer != 2) return;
        if (mapdata.motikinn[1,2] <= 0) return;
        if (mapdata.motikinn[1,1] >= 10) return;
        mapdata.motikinn[1,2]--;
        mapdata.motikinn[1,1] = mapdata.motikinn[1,1] + 2;
        mapdata.TextUpdate();
        return;
    }

    public void Change10Up2()
    {
        mapdata = GetComponent<Mapdata>();
        gamecontroller = GetComponent<Gamecontroller>();
        if (gamecontroller.turnplayer != 2) return;
        if (mapdata.motikinn[1,2] < 5) return;
        if (mapdata.motikinn[1,3] >= 10) return;
        mapdata.motikinn[1,2] = mapdata.motikinn[1,2] - 5;
        mapdata.motikinn[1,3]++;
        mapdata.TextUpdate();
        return;
    }

    public void Break50_2()
    {
        mapdata = GetComponent<Mapdata>();
        gamecontroller = GetComponent<Gamecontroller>();
        if (gamecontroller.turnplayer != 2) return;
        if (mapdata.motikinn[1,3] <= 0) return;
        if (mapdata.motikinn[1,2] >= 10) return;
        mapdata.motikinn[1,3]--;
        mapdata.motikinn[1,2] = mapdata.motikinn[1,2] + 5;
        mapdata.TextUpdate();
        return;
    }
    public void Change50Up2()
    {
        mapdata = GetComponent<Mapdata>();
        gamecontroller = GetComponent<Gamecontroller>();
        if (gamecontroller.turnplayer != 2) return;
        if (mapdata.motikinn[1,3] < 2) return;
        if (mapdata.motikinn[1,4] >= 10) return;
        mapdata.motikinn[1,3] = mapdata.motikinn[1,3] - 2;
        mapdata.motikinn[1,4]++;
        mapdata.TextUpdate();
        return;
    }

    public void Break100_2()
    {
        mapdata = GetComponent<Mapdata>();
        gamecontroller = GetComponent<Gamecontroller>();
        if (gamecontroller.turnplayer != 2) return;
        if (mapdata.motikinn[1,4] <= 0) return;
        if (mapdata.motikinn[1,3] >= 10) return;
        mapdata.motikinn[1,4]--;
        mapdata.motikinn[1,3] = mapdata.motikinn[1,3] + 2;
        mapdata.TextUpdate();
        return;
    }



}
