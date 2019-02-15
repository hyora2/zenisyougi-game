using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEditor;
using UnityEngine.SceneManagement;


/*ロジックの大部分は調べたもの*/

public class FadeScript : MonoBehaviour
{
    float alfa;
    float speed = 0.01f;
    float red, green, blue;
    public bool fede;
    private GameObject _panel;
    public float timecount = 4f;
   public float changescenetime = 2f;

    public void Setfade(bool k)
    {
        fede = k;
    }

    void Start()
    {
        fede = false;
        _panel = transform.FindChild("Panel").gameObject;

        red = _panel.GetComponent<Image>().color.r;
        green = _panel.GetComponent<Image>().color.g;
        blue = _panel.GetComponent<Image>().color.b;
    }

    void Update()
    {
        if (fede)
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
                SceneManager.LoadScene("title");
            }

        }
    }
}
