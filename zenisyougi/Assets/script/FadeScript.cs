using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEditor;
using UnityEngine.SceneManagement;
using System.Collections.Generic;


/*ロジックの大部分は調べたもの*/

public class FadeScript : MonoBehaviour
{
    float alfa;
    float speed = 0.04f;
    float red, green, blue;
    private bool fedeout;
    public bool fadein = false;
    private GameObject _panel;

    public float FadeInTimeCount = 2f;
    public float timecount = 4f;
   public float changescenetime = 2f;
    private int changesceneKey;


    private List<string> SceneNames = new List<string>
    {
        "title",
        "gamescene",
        "howtoplay",

    };

    public void SetAlfa(float a)
    {
        alfa = a;
    }


    public void SetchangesceneKey(string name)
    {
        int key = 99;
        for(int i = 0; i < SceneNames.Count; i++)
        {
            if (name.Equals(SceneNames[i])) key = i;
        }

        changesceneKey = key;
        if (changesceneKey == 99) Debug.Log("error");
    }

    public void Setfadeout(bool k)
    {
        fedeout = k;
    }

    public void Setfadein(bool k)
    {
        fadein = k;
    }



    void Start()
    {
        fedeout = false;      
        _panel = transform.FindChild("Panel").gameObject;

        red = _panel.GetComponent<Image>().color.r;
        green = _panel.GetComponent<Image>().color.g;
        blue = _panel.GetComponent<Image>().color.b;
    }

    void Update()
    {

        if (fadein)
        {
            if (FadeInTimeCount > -1) FadeInTimeCount -= Time.deltaTime;
            if(FadeInTimeCount <= 0)
            {
                _panel.GetComponent<Image>().color = new Color(red, green, blue, alfa);
                alfa -= speed;

            }
            if(alfa < 0)
            {
                fadein = false;
            }

        }


        if (fedeout)
        {
            if(timecount > -1) timecount -= Time.deltaTime;
            if (timecount <= 0)
            {
                _panel.GetComponent<Image>().color = new Color(red, green, blue, alfa);
                alfa += speed;
            }
        }
        if(alfa >= 1)
        {
            changescenetime -= Time.deltaTime;
            if(changescenetime <= 0)
            {
                //EditorApplication.isPlaying = false;
                SceneManager.LoadScene(SceneNames[changesceneKey]);
            }

        }
    }



}
