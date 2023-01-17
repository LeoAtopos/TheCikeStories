using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System;

public class HijackCtrl : MonoBehaviour
{
    public GameObject stage;
    public GameObject subText;
    public GameObject subTextline1;
    public GameObject subTextline2;
    public GameObject subTextline3;
    public GameObject subTextline4;
    public GameObject subTextline5;
    public GameObject subTextline6;
    public GameObject subTextline7;
    public GameObject subTextline8;

    public GameObject walkers;
    public GameObject zhuangPos;
    public GameObject caoMoPos;
    public Animator caoMoAnimation;
    public GameObject xiZi;
    public Animator luXiangAnimation;
    public Animator ZhuangAnimation;
    public GameObject opWalkers;
    public GameObject opWalkers2;
    public GameObject luXiang;
    //public GameObject qiBingLine;
    public GameObject weiXiangLine;
    public GameObject xingXiangLine;
    public GameObject zhengXiangLine;
    public GameObject caoXiangLine;
    public GameObject chuXiangLine;
    public GameObject songXiangLine;

    bool isOKToMove;
    bool isCaoMoStopped;
    //bool isNoteHaveStopped;
    public GameObject dagger;
    public bool isOKToCatch;
    public bool isOKToHijack;

    public GameObject qiBing1;
    public GameObject qiBing2;
    public GameObject qiBing3;
    public GameObject qiBing4;
    public GameObject guanPos;

    public GameObject shoutText;
    public GameObject huanLine;
    public GameObject caoMoLine;
    public TextMeshProUGUI caoMoLineText;

    public GameObject stateMapPos;
    public GameObject stateMap3;
    public GameObject stateMap2;
    public GameObject stateMap1;
    public GameObject stateMap;

    public GameObject optionPos;
    public GameObject option1;
    public GameObject option2;
    public GameObject option3;
    int cutBackCount;
    //public GameObject qiBingTrouble;
    //// Start is called before the first frame update
    void Start()
    {
        //qiBingLine.SetActive(false);
        weiXiangLine.SetActive(false);
        xingXiangLine.SetActive(false);
        zhengXiangLine.SetActive(false);
        caoXiangLine.SetActive(false);
        chuXiangLine.SetActive(false);
        songXiangLine.SetActive(false);
        subText.SetActive(false);
        subTextline1.SetActive(true);
        subTextline2.SetActive(false);
        subTextline3.SetActive(false);
        subTextline4.SetActive(false);
        subTextline5.SetActive(false);
        subTextline6.SetActive(false);
        subTextline7.SetActive(false);
        isOKToMove = false;
        isCaoMoStopped = false;
        xiZi.SetActive(false);
        subText.SetActive(false);
        shoutText.SetActive(false);
        huanLine.SetActive(false);
        caoMoLine.SetActive(false);
        stateMapPos.SetActive(false);
        stateMap3.SetActive(true);
        optionPos.SetActive(false);
        //stateMap2.SetActive(false);
        //stateMap1.SetActive(false);
        //stateMap.SetActive(false);

        isOKToCatch = false;
        isOKToHijack = false;

        cutBackCount = 0;
        //Vector3 sPos = stage.transform.localPosition;

        //isNoteHaveStopped = true;
        //stage.transform.DOLocalMove(new Vector3(0, 0, 0), 5f).OnComplete(() => StageInDone());
        stage.transform.DOLocalMove(new Vector3(0, -445, 0), 3f).OnComplete(() => StageInDone());
        //ZhuangLine1();
    }

    //// -176,-707,-931,-1141,-1600
    void FixedUpdate()
    {
        if (isOKToMove)
        {
            //if (Input.GetMouseButton(0))
            //{
            //    opWalkers.transform.localPosition -= 80f * opWalkers.transform.up * Time.fixedDeltaTime;
            //    opWalkers2.transform.localPosition -= 80f * opWalkers.transform.up * Time.fixedDeltaTime;
            if (!isCaoMoStopped) caoMoAnimation.Play("CaoMoWalkUpMoving");
            ZhuangAnimation.Play("ZhuangWalkUpMoving");
            //if (isNoteHaveStopped) luXiangAnimation.Play("LuXiangMoving");
            //}
            //        if (isNoteHaveStopped && opWalkers.transform.localPosition.y < -176)
            //            StopZhuang();
            //        if (opWalkers.transform.localPosition.y < -315)
            //            qiBingTrouble.transform.SetParent(opWalkers2.transform);
            //        if (opWalkers.transform.localPosition.y < -607)
            //            weiXiangLine.SetActive(true);
            //        if (opWalkers.transform.localPosition.y < -657)
            //        {
            //            weiXiangLine.SetActive(false);
            //            xingXiangLine.SetActive(true);
            //        }
            //        if (opWalkers.transform.localPosition.y < -831)
            //            zhengXiangLine.SetActive(true);
            //        if (opWalkers.transform.localPosition.y < -881)
            //        {
            //            zhengXiangLine.SetActive(false);
            //            caoXiangLine.SetActive(true);
            //        }
            //        if (opWalkers.transform.localPosition.y < -1041)
            //            songXiangLine.SetActive(true);
            //        if (opWalkers.transform.localPosition.y < -1091)
            //        {
            //            songXiangLine.SetActive(false);
            //            chuXiangLine.SetActive(true);
            //        }
            //        if (opWalkers.transform.localPosition.y < -1207)
            //        {
            //            SceneManager.LoadScene("111Hijack");
            //        }

        }
    }

    void StageInDone()
    {
        stage.transform.DOLocalMove(new Vector3(0, -227, 0), 1.5f);
        dagger.transform.SetParent(stage.transform);
        stage.transform.DOScale(0.5f, 1.5f).OnComplete(() => StageZoomDone());
        //subText.SetActive(false);
        //isOKToMove = true;
    }
    void StageZoomDone()//0,376;-81,140
    {
        walkers.transform.DOLocalMove(new Vector3(0, 376, 0), 2.0f).OnComplete(() => WalkersMoveUpDone());
        isOKToMove = true;
    }
    void WalkersMoveUpDone()
    {
        isOKToMove = false;
        isCaoMoStopped = true;
        Invoke("ZhuangMoveToPos", 1.0f);

    }
    void ZhuangMoveToPos()
    {
        isOKToMove = true;
        zhuangPos.transform.DOLocalMove(new Vector3(-81, 140, 0), 1.5f).OnComplete(() => ZhuangMoveDone());
    }
    void ZhuangMoveDone()
    {
        isOKToMove = false;
        Invoke("DaggerFlyIn", 1.5f);
    }
    //23,-61
    void DaggerFlyIn()
    {
        dagger.transform.DOLocalMove(new Vector3(0, 333, 0), 8f).OnComplete(()=> FailCatchDagger());
        dagger.transform.DORotate(new Vector3(0, 0, 540), 8f, RotateMode.FastBeyond360);
        isOKToCatch = true;
        subText.SetActive(true);
    }
    public void CheckDaggerClick()
    {
        isOKToCatch = false;
        isOKToHijack = true;
        dagger.transform.DOKill();
        Vector3 cP = dagger.transform.position;
        cP.x -= 50;
        caoMoPos.transform.position = cP;
        dagger.transform.SetParent(caoMoPos.transform);
        dagger.transform.SetAsFirstSibling();
        dagger.transform.localPosition = new Vector3(103, -60, 0);
        dagger.transform.rotation = Quaternion.Euler(0, 0, -28);
        subTextline1.SetActive(false);
        subTextline2.SetActive(true);
    }
    //103,-60; -28
    //75,203
    void FailCatchDagger()
    {
        SceneManager.LoadScene("111Hijack");
    }
    public void HijackMove()
    {
        isOKToHijack = false;
        caoMoPos.transform.localPosition = new Vector3(75, 203, 0);
        qiBing1.transform.DOLocalJump(new Vector3(-127, 238, 0), 5, 2, 0.5f);
        qiBing2.transform.DOLocalJump(new Vector3(253, 245, 0), 5, 2, 0.5f);
        qiBing3.transform.DOLocalJump(new Vector3(-163, 60, 0), 5, 2, 0.5f);
        qiBing4.transform.DOLocalJump(new Vector3(317, 58, 0), 5, 2, 0.5f);
        guanPos.transform.DOLocalJump(new Vector3(204, 1535, 0), 5, 2, 0.5f);
        stage.transform.DOLocalMove(new Vector3(0, -465, 0), 0.2f).OnComplete(()=>HijackMoveDone());
        stage.transform.DOScale(1, 0.2f);
        Invoke("ZhuangHide", 0.4f);
    }
    //30,153,zhuang
    void ZhuangHide()
    {
        zhuangPos.transform.DOLocalJump(new Vector3(30, 153, 0), 3, 5, 0.3f, false);
    }
    void HijackMoveDone()
    {
        xiZi.SetActive(true);
        subTextline2.SetActive(false);
        subText.SetActive(false);
    }
    //-127,238;253,245;-163,60;317,58;
    //204,1535
    public void XiQiClicked()
    {
        xiZi.SetActive(false);
        CaoMoShout();
    }
    void CaoMoShout()
    {
        shoutText.SetActive(true);
        Invoke("ShoutDone", 3);
    }
    void ShoutDone()
    {
        shoutText.SetActive(false);
        subText.SetActive(true);
        subTextline3.SetActive(true);
        Invoke("HuanAsk", 3f);
    }
    void HuanAsk()
    {
        huanLine.SetActive(true);
        subTextline3.SetActive(false);
        subTextline4.SetActive(true);
        Invoke("CaoMoAns1", 2.5f);
    }
    void CaoMoAns1()
    {
        huanLine.SetActive(false);
        subTextline4.SetActive(false);
        subTextline5.SetActive(true);
        caoMoLine.SetActive(true);
        Invoke("CaoMoAns2", 5.5f);
    }
    void CaoMoAns2()
    {
        subTextline5.SetActive(false);
        subTextline6.SetActive(true);
        Invoke("HuanPromiss", 5.5f);
    }
    void HuanPromiss()
    {
        caoMoLine.SetActive(false);
        subTextline6.SetActive(false);
        subTextline7.SetActive(true);
        stateMapPos.SetActive(true);
        stage.transform.DOScale(0.7f, 1).OnComplete(()=> CutBack1());
    }
    void CutBack1()
    {
        cutBackCount++;
        stateMap3.GetComponent<Image>().DOFade(0, 3.5f).OnComplete(()=> CutBack1Done());
    }
    void CutBack1Done()
    {
        optionPos.SetActive(true);
    }
    public void OptionChecked(int n, GameObject g)
    {
        g.SetActive(false);
        optionPos.SetActive(false);
        
        if(n == 1)
        {
            caoMoLineText.text = "鲁国风光不如你们齐国啊";
            caoMoLine.SetActive(true);
        }
        if (n == 2)
        {
            caoMoLineText.text = "齐侯大方也是天下闻名啊";
            caoMoLine.SetActive(true);
        }
        if (n == 3)
        {
            caoMoLineText.text = "鲁齐兄弟永存共亡";
            caoMoLine.SetActive(true);
        }
        if (cutBackCount == 1)
            Invoke("CutBack2", 3.5f);
        if (cutBackCount == 2)
            Invoke("CutBack3", 3.5f);
        if (cutBackCount == 3)
            Invoke("CutAllDone", 3.5f);
    }
    void CutBack2()
    {
        cutBackCount++;
        caoMoLine.SetActive(false);
        stateMap2.GetComponent<Image>().DOFade(0, 3.5f).OnComplete(() => CutBack2Done());
    }
    void CutBack2Done()
    {
        optionPos.SetActive(true);
    }
    void CutBack3()
    {
        cutBackCount++;
        caoMoLine.SetActive(false);
        stateMap1.GetComponent<Image>().DOFade(0, 3.5f).OnComplete(() => CutBack3Done());
    }
    void CutBack3Done()
    {
        optionPos.SetActive(true);
    }
    void CutAllDone()
    {
        caoMoLine.SetActive(false);
        stateMapPos.SetActive(false);
        subTextline7.SetActive(false);
        subText.SetActive(false);
        stage.transform.DOScale(1f, 1).OnComplete(() => DropDagger());
    }
    void DropDagger()
    {
        subTextline8.SetActive(true);
        subText.SetActive(true);
    }
}