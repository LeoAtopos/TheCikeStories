using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MakeMeetingController : MonoBehaviour
{
    public GameObject stage;
    public GameObject huanPos;
    public GameObject huanTitleText;
    public GameObject huanLine;
    public GameObject guanPos;
    public GameObject guanTitleText;
    public GameObject guanLine;
    public GameObject subText;
    
    // Start is called before the first frame update
    void Start()
    {
        subText.SetActive(false);
        huanLine.SetActive(false);
        guanLine.SetActive(false);
        stage.transform.DOLocalMove(new Vector3(0, 0, 0), 8f).OnComplete(()=> StageInDone());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void StageInDone()
    {
        Invoke("HideTitles", 5);
    }
    void HideTitles()
    {
        huanTitleText.SetActive(false);
        guanTitleText.SetActive(false);
        Invoke("HuanLine1", 1.3f);
    }
    void HuanLine1()
    {
        huanLine.GetComponent<LineController>().SetText("管相，请教我做事");
        huanLine.SetActive(true);
        Invoke("HuanLine1Done", 2.5f);
    }
    void HuanLine1Done()
    {
        huanLine.SetActive(false);
        Invoke("GuanLine1", 1.3f);
    }
    void GuanLine1()
    {
        guanLine.GetComponent<LineController>().SetText("先要尊王攘夷");
        guanLine.SetActive(true);
        Invoke("GuanLine1Done", 2.5f);
    }
    void GuanLine1Done()
    {
        guanLine.SetActive(false);
        Invoke("HuanLine2", 1.3f);
    }
    void HuanLine2()
    {
        huanLine.GetComponent<LineController>().SetText("好的，亚夫");
        huanLine.SetActive(true);
        //Invoke("HuanLine1Done", 2.5f);
    }
}
