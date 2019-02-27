using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HowtoPlay : MonoBehaviour
{
    GameObject howtoplaycontObj;
    HowtoPlayCont cont;

    private void Start()
    {
        howtoplaycontObj = GameObject.Find("HowtoplayCanvas");
        cont = howtoplaycontObj.GetComponent<HowtoPlayCont>();
    }

    public void NextButtonClicked()
    {
        cont.ShowNextPage();
    }

    public void PreButtonClicked()
    {
        cont.ShowPrePage();
    }

}
