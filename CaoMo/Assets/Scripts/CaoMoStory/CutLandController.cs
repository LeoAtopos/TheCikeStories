using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;
using TMPro;

public class CutLandController : MonoBehaviour
{
    public GameObject subTextBoard;
    public GameObject subText1;
    public GameObject subText2;
    public GameObject geZi;
    public int cutTime = 0;
    public Image stateMap;
    public Image stateMapCut;
    public Sprite stateMapCut1;
    public Sprite stateMapCut2;
    public Sprite stateMapCut3;
    public GameObject qiArmyLine;
    public TextMeshProUGUI qiArmyLineText;
    public GameObject qiArmy;
    public GameObject qiArmyName;

    public AudioSource cutLandSound;
    // Start is called before the first frame update
    void Start()
    {
        subText1.SetActive(false);
        geZi.SetActive(false);
        qiArmyLine.SetActive(false);
        Invoke("ShowGeZi", 2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void ShowGeZi()
    {
        geZi.SetActive(true);
    }
    public void CutLand()
    {
        cutLandSound.Play();
        cutTime++;
        geZi.SetActive(false);
        if (cutTime == 1)
        {
            stateMapCut.sprite = stateMapCut1;
            stateMapCut.color = new Color(stateMap.color.r, stateMap.color.g, stateMap.color.b, 0); ;
            stateMapCut.DOFade(1, 2f).OnComplete(()=> FirstCutDone());
        }
        if (cutTime == 2)
        {
            stateMapCut.sprite = stateMapCut2;
            stateMapCut.color = new Color(stateMap.color.r, stateMap.color.g, stateMap.color.b, 0); ;
            stateMapCut.DOFade(1, 2f).OnComplete(() => SecondCutDone());
        }
        if (cutTime == 3)
        {
            stateMapCut.sprite = stateMapCut3;
            stateMapCut.color = new Color(stateMap.color.r, stateMap.color.g, stateMap.color.b, 0); ;
            stateMapCut.DOFade(1, 2f).OnComplete(() => ThirdCutDone());
        }
    }
    void FirstCutDone()
    {
        stateMap.sprite = stateMapCut1;
        Invoke("QiArmyFirstRespond", 1f);
    }
    void QiArmyFirstRespond()
    {
        qiArmyLine.SetActive(true);
        qiArmyLineText.text = "鲁国风光真不错啊";// 文本需要优化，体现点文化内涵，最好用上诗经里的外交辞令
        Invoke("GoCut2", 2f);
    }
    void GoCut2()
    {
        qiArmyLine.SetActive(false);
        geZi.SetActive(true);
    }
    void SecondCutDone()
    {
        stateMap.sprite = stateMapCut2;
        Invoke("QiArmySecondRespond", 1f);
    }
    void QiArmySecondRespond()
    {
        qiArmyLine.SetActive(true);
        qiArmyLineText.text = "鲁公大方天下闻名";
        Invoke("GoCut3", 2f);
    }
    void GoCut3()
    {
        qiArmyLine.SetActive(false);
        geZi.SetActive(true);
        geZi.transform.DOShakePosition(20f, 5, 10, 30, false, true);
    }
    void ThirdCutDone()
    {
        Invoke("QiArmyThirdRespond", 1f);
    }
    void QiArmyThirdRespond()
    {
        qiArmyLine.SetActive(true);
        qiArmyLineText.text = "齐鲁兄弟永修同好";
        Invoke("QiArmyTurnBack", 2f);
    }
    void QiArmyTurnBack()
    {
        qiArmyLine.SetActive(false);
        qiArmy.transform.rotation *= Quaternion.Euler(0, 0, 180f);
        qiArmy.transform.DOLocalMove(qiArmy.transform.up * 600 + qiArmy.transform.localPosition, 2f);
        Invoke("QiArmyFade", 1.5f);
    }
    void QiArmyFade()
    {
        qiArmy.GetComponent<Image>().DOFade(0, 0.5f).OnComplete(()=> CutScene());
        qiArmyName.SetActive(false);
    }
    void CutScene()
    {
        geZi.transform.DOKill();
        SceneManager.LoadScene("108StillGeneral");
    }
}
