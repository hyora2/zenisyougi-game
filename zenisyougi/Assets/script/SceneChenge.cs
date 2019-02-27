using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChenge : MonoBehaviour
{
    GameObject FadeOutObj;
    FadeScript fade;

    private void Start()
    {
        FadeOutObj = GameObject.Find("Canvas");
        fade = FadeOutObj.GetComponent<FadeScript>();
    }

    public void GameStart()
    {
        fade.SetchangesceneKey("gamescene");
        fade.Setfadeout(true);
      //  SceneManager.LoadScene("gamescene");
    }

    public void howtoplay()
    {
        fade.SetchangesceneKey("howtoplay");
        fade.Setfadeout(true);

       // SceneManager.LoadScene("howtoplay");
    }


}
