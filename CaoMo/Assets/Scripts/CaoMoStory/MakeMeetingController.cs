using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System;

public class MakeMeetingController : MonoBehaviour
{
    public GameObject stage;// 2944
    public GameObject timeText;
    public GameObject locationText;
    public GameObject huanPos;
    public GameObject huanTitleText;

    public GameObject huanLine;
    public GameObject guanPos;
    public GameObject guanTitleText;
    public GameObject guanLine;
    public GameObject options;
    public GameObject subText;

    int ansCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        ansCount = 0;
        subText.SetActive(false);
        huanLine.SetActive(false);
        guanLine.SetActive(false);
        options.SetActive(false);
        stage.transform.DOLocalMove(new Vector3(0, 0, 0), 8f).OnComplete(()=> StageInDone());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void StageInDone()
    {
        timeText.SetActive(false);
        locationText.SetActive(false);
        Invoke("HideTitles", 2);
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
        Invoke("HuanLine1Done", 3f);
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
        options.SetActive(true);
    }
    internal void HuanAns(int t)
    {
        ansCount++;
        options.SetActive(false);
        guanLine.SetActive(false);
        if (t == 1) huanLine.GetComponent<LineController>().SetText("好的，仲父");
        if (t == 2) huanLine.GetComponent<LineController>().SetText("明白，亚父");
        if (t == 3) huanLine.GetComponent<LineController>().SetText("我懂，恩相");
        if (ansCount == 1) Invoke("HuanLine2", 0.1f);
        if (ansCount == 2) Invoke("HuanLine3", 0.1f);
        if (ansCount == 3) Invoke("HuanLine4", 0.1f);
    }
    void HuanLine2()
    {
        huanLine.SetActive(true);
        Invoke("HuanLine2Done", 2.5f);
    }
    void HuanLine2Done()
    {
        huanLine.SetActive(false);
        Invoke("HuanLine2p", 0.5f);
    }
    void HuanLine2p()
    {
        huanLine.GetComponent<LineController>().SetText("先立大义，政治动员");
        huanLine.SetActive(true);
        Invoke("HuanLine2pDone", 3.5f);
    }
    void HuanLine2pDone()
    {
        huanLine.SetActive(false);
        Invoke("GuanLine2", 1.3f);
    }
    void GuanLine2()
    {
        guanLine.GetComponent<LineController>().SetText("再会盟诸侯");
        guanLine.SetActive(true);
        Invoke("GuanLine2Done", 2.5f);
    }
    void GuanLine2Done()
    {
        options.SetActive(true);
    }
    void HuanLine3()
    {
        huanLine.SetActive(true);
        Invoke("HuanLine3Done", 2.5f);
    }
    void HuanLine3Done()
    {
        huanLine.SetActive(false);
        Invoke("HuanLine3p", 0.5f);
    }
    void HuanLine3p()
    {
        huanLine.GetComponent<LineController>().SetText("看谁不来，以多欺少");
        huanLine.SetActive(true);
        Invoke("HuanLine3pDone", 3.5f);
    }
    void HuanLine3pDone()
    {
        huanLine.SetActive(false);
        Invoke("GuanLine3", 1.3f);
    }
    void GuanLine3()
    {
        guanLine.GetComponent<LineController>().SetText("积极帮助解决\n各国问题");
        guanLine.SetActive(true);
        Invoke("GuanLine3Done", 2.5f);
    }
    void GuanLine3Done()
    {
        options.SetActive(true);
    }
    void HuanLine4()
    {
        huanLine.SetActive(true);
        Invoke("HuanLine4Done", 2.5f);
    }
    void HuanLine4Done()
    {
        huanLine.SetActive(false);
        Invoke("HuanLine4p", 0.5f);
    }
    void HuanLine4p()
    {
        huanLine.GetComponent<LineController>().SetText("小的吞并，大的控制");
        huanLine.SetActive(true);
        Invoke("HuanLine4pDone", 3.5f);
    }
    void HuanLine4pDone()
    {
        huanLine.SetActive(false);
        Invoke("GuanLine4", 1.3f);
    }
    void GuanLine4()
    {
        guanLine.GetComponent<LineController>().SetText("从简单的开始");
        guanLine.SetActive(true);
        Invoke("GuanLine4Done", 3.5f);
    }
    void GuanLine4Done()
    {
        guanLine.SetActive(false);
        Invoke("HuanLine5", 2.5f);
    }
    void HuanLine5()
    {
        huanLine.GetComponent<LineController>().SetText("来人，叫鲁公开会");
        huanLine.SetActive(true);
        Invoke("HuanLine5Done", 4f);
    }
    void HuanLine5Done()
    {
        stage.transform.DOLocalMove(new Vector3(1500, 0, 0), 2f).OnComplete(() => StageOutDone());
    }
    void StageOutDone()
    {
        SceneManager.LoadScene("110WalkUp");
    }
}
