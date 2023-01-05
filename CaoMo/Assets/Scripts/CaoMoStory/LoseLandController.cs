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
    // Start is called before the first frame update
    void Start()
    {
        stateMap.GetComponent<Image>().DOFade(0, 0f);
        qiArmy.GetComponent<Image>().DOFade(0, 0f);
        qiArmy.SetActive(false);
        subText.SetActive(false);
        Invoke("StartShrinkBattleMap", 1f);
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
    }
    void StartShrinkStateMap()
    {
        stateMap.transform.DOScale(0.1f, 3f);
    }
}
