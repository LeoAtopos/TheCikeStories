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
    public GameObject subText;
    public GameObject qiArmy;
    public GameObject zhuangPos;
    public GameObject zhuangState;
    // Start is called before the first frame update
    void Start()
    {
        stateMap.GetComponent<Image>().DOFade(0, 0f);
        qiArmy.GetComponent<Image>().DOFade(0, 0f);
        qiArmy.SetActive(false);
        subText.SetActive(false);
        Invoke("StartShrinkBattleMap", 1f);
        zhuangPos.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void StartShrinkBattleMap()
    {
        battleMap.transform.DOScale(0.1f, 3f);
        battleMap.GetComponent<Image>().DOFade(0, 3f);
        
        Invoke("StartShowStateMap", 2.5f);
    }
    void StartShowStateMap()
    {
        qiArmy.SetActive(true);
        stateMap.GetComponent<Image>().DOFade(1, 3f);
        qiArmy.GetComponent<Image>().DOFade(1, 3f);
        Invoke("StartShrinkStateMap", 2.8f);
        Invoke("QiArmyMartchOn", 1.5f);
    }
    void StartShrinkStateMap()
    {
        stateMap.transform.DOScale(0.2f, 3f);
        stateMap.transform.DOLocalMove(new Vector3(85, 40, 0), 3f).OnComplete(()=> ZhuangFallDown());
    }
    void QiArmyMartchOn()
    {
        qiArmy.transform.DOLocalMove(qiArmy.transform.up * 500 + qiArmy.transform.localPosition, 16f);
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
        zhuangPos.transform.DOLocalMove(zhuangPos.transform.right * 130 + zhuangPos.transform.localPosition, 1.2f);
        zhuangState.transform.DOShakePosition(1.2f, 5, 10, 30, false, true);
    }
}
