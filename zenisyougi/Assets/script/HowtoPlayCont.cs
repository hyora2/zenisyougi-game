using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class HowtoPlayCont : MonoBehaviour
{
    public List<GameObject> ImagesOBJ;

    public Text Titletext;
    private int page;
    private List<string> TitleNames = new List<string>
    {
        "タイトル画面に戻ります",
        "表示画面 (1/9)",
        "表示画面 (2/9)",
        "基本ルール (3/9)",
        "小銭の動き (4/9)",
        "特殊能力 (5/9)",
        "特殊能力 (6/9)",
        "その他ルール (7/9)",
        "その他 (8/9)",
        "クレジット (9/9)",
        "タイトル画面に戻ります",

    };

    // Start is called before the first frame update
    void Start()
    {
        page = 1;
        Titletext.text = TitleNames[1];
    }

    public void ShowNextPage()
    {
       ImagesOBJ[page].SetActive(false);
       page++;
        if (page == 10) SceneManager.LoadScene("title");
        ChangeText(page);
        ImagesOBJ[page].SetActive(true);

    }

    public void ShowPrePage()
    {
        ImagesOBJ[page].SetActive(false);
        page--;
        if (page == 0) SceneManager.LoadScene("title");
        ChangeText(page);
        ImagesOBJ[page].SetActive(true);

    }

    public void ChangeText(int key)
    {
        Titletext.text = TitleNames[key];
    }


}
