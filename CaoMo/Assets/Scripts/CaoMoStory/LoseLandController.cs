using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;
using TMPro;

public class LoseLandController : MonoBehaviour
{
    public GameObject battleMap;
    public GameObject stateMap;
    public GameObject subTextBoard;
    public GameObject qiArmy;
    public GameObject zhuangPos;
    public GameObject zhuangState;
    public GameObject zhuangLine;
    public GameObject subText1;
    public GameObject subText2;
    // Start is called before the first frame update
    void Start()
    {
        stateMap.GetComponent<Image>().DOFade(0, 0f);
        qiArmy.GetComponent<Image>().DOFade(0, 0f);
        qiArmy.SetActive(false);
        subTextBoard.SetActive(false);
        Invoke("StartShrinkBattleMap", 1f);
        zhuangPos.SetActive(false);
        zhuangLine.SetActive(false);
        subText2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void StartShrinkBattleMap()
    {
        battleMap.transform.DOScale(0.1f, 1.5f);
        battleMap.GetComponent<Image>().DOFade(0, 1.5f);
        
        Invoke("StartShowStateMap", 1.0f);
    }
    void StartShowStateMap()
    {
        qiArmy.SetActive(true);
        stateMap.GetComponent<Image>().DOFade(1, 1.5f);
        qiArmy.GetComponent<Image>().DOFade(1, 1.5f);
        Invoke("StartShrinkStateMap", 1.4f);
        Invoke("QiArmyMartchOn", 0.7f);
    }
    void StartShrinkStateMap()
    {
        stateMap.transform.DOScale(0.2f, 1.5f);
        stateMap.transform.DOLocalMove(new Vector3(85, 40, 0), 1.5f).OnComplete(()=> ZhuangFallDown());
    }
    void QiArmyMartchOn()
    {
        qiArmy.transform.DOLocalMove(qiArmy.transform.up * 500 + qiArmy.transform.localPosition, 8f);
    }
    void ZhuangFallDown()
    {
        zhuangPos.SetActive(true);
        zhuangPos.transform.DOLocalMove(new Vector3(-252,-60,0),2f).OnComplete(()=> ZhuangFallDownDone());
    }
    void ZhuangFallDownDone()
    {
        Invoke("ZhuangWalkUp", 0.5f);
    }
    void ZhuangWalkUp()
    {
        zhuangPos.transform.DOLocalMove(zhuangPos.transform.right * 130 + zhuangPos.transform.localPosition, 1.2f).OnComplete(()=> ZhuangWalkedUp());
        zhuangState.transform.DOShakePosition(1.2f, 5, 10, 30, false, true);
    }
    void ZhuangWalkedUp()
    {
        Invoke("ZhuangShock", 1.5f);
    }
    void ZhuangShock()
    {
        zhuangLine.SetActive(true);
        zhuangLine.transform.DOShakePosition(1.5f, 5, 10, 80, false, true).OnComplete(()=> ZhuangShockDone());
    }
    void ZhuangShockDone()
    {
        subTextBoard.SetActive(true);
        Invoke("NextSubText", 3f);
    }
    void NextSubText()
    {
        //subText1.SetActive(false);
        //subText2.SetActive(true);
        Invoke("CutScene", 2f);
    }
    void CutScene()
    {
        SceneManager.LoadScene("107CutLand");
    }
}
