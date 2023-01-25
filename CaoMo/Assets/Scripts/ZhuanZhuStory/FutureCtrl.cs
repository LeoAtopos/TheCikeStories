using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FutureCtrl : MonoBehaviour
{
    public GameObject zhuanZhuText;
    public GameObject yuRangText;
    public GameObject nieZhengText;
    public GameObject jingKeText;
    public GameObject guanZhongText;
    public GameObject yaoLiText;
    public GameObject tapToGoText;
    bool isTapToGoShowed;
    // Start is called before the first frame update
    void Start()
    {
        zhuanZhuText.SetActive(false);
        yuRangText.SetActive(false);
        nieZhengText.SetActive(false);
        jingKeText.SetActive(false);
        guanZhongText.SetActive(false);
        yaoLiText.SetActive(false);
        tapToGoText.SetActive(false);
        isTapToGoShowed = false;

        Invoke("ShowZhuanZhuText", 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (isTapToGoShowed && Input.GetMouseButton(0))// && !GameController.Instance.pausePanel.activeSelf
        {
            SceneManager.LoadScene("MainMenu");
        }

    }
    void ShowZhuanZhuText()
    {
        zhuanZhuText.SetActive(true);
        Invoke("ShowYuRangText", 0.5f);
    }
    void ShowYuRangText()
    {
        yuRangText.SetActive(true);
        Invoke("ShowNieZhengText", 0.5f);
    }
    void ShowNieZhengText()
    {
        nieZhengText.SetActive(true);
        Invoke("ShowJingKeText", 0.5f);
    }
    void ShowJingKeText()
    {
        jingKeText.SetActive(true);
        Invoke("ShowGuanZhongText", 0.5f);
    }
    void ShowGuanZhongText()
    {
        guanZhongText.SetActive(true);
        Invoke("ShowYaoLiText", 0.5f);
    }
    void ShowYaoLiText()
    {
        yaoLiText.SetActive(true);
        Invoke("ShowTapToGoText", 0.5f);
    }
    void ShowTapToGoText()
    {
        tapToGoText.SetActive(true);
        Invoke("OKTapToGo", 0.5f);
    }
    void OKTapToGo()
    {
        isTapToGoShowed = true;
    }
}
