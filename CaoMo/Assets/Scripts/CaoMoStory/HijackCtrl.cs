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
    public GameObject subTextline9;
    public GameObject subTextline10;
    public GameObject subTextline11;
    public GameObject subTextline12;
    public GameObject subTextline13;
    public GameObject subTextline14;
    public GameObject subTextline15;
    public GameObject subTextline16;
    public GameObject subTextline17;

    public GameObject walkers;
    public GameObject zhuangPos;
    public GameObject caoMoPos;
    public Animator caoMoAnimation;
    public GameObject xiZi;
    public Animator luXiangAnimation;
    public Animator ZhuangAnimation;
    public GameObject opWalkers;
    public GameObject huanState;
    public GameObject huanOption;
    public GameObject guanLine;
    public GameObject opWalkers2;
    public GameObject luXiang;
    //public GameObject qiBingLine;
    public GameObject weiXiangLine;
    public GameObject xingXiangLine;
    public GameObject zhengXiangLine;
    public GameObject caoXiangLine;
    public GameObject chuXiangLine;
    public GameObject songXiangLine;
    public GameObject luXiangLine;

    bool isOKToMove;
    bool isCaoMoStopped;
    bool isOKToWalkDown;
    //bool isNoteHaveStopped;
    public GameObject daggerPos;
    public GameObject dagger;
    public GameObject hitSlider;
    public bool isOKToCatch;
    public bool isOKToHijack;

    public GameObject qiBing1;
    public GameObject qiBing2;
    public GameObject qiBing3;
    public GameObject qiBing4;
    public GameObject guanPos;

    public GameObject shoutText;
    public GameObject huanLine;
    public TextMeshProUGUI huanLineText;
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
    public GameObject ansOptionPos;

    public GameObject dioZi;
    private bool isQTE2;
    private bool isQTE3;
    int qteSpeed = 20;

    public AudioSource huanAudioSource;
    public AudioClip huanGet;
    public AudioClip huanAgree;
    public AudioSource caoMoAudioSource;
    public AudioClip caoMoTalkLand;
    public AudioClip caoMoExplain;
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
        luXiangLine.SetActive(false);
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
        huanOption.SetActive(false);
        guanLine.SetActive(false);
        caoMoLine.SetActive(false);
        stateMapPos.SetActive(false);
        stateMap3.SetActive(true);
        optionPos.SetActive(false);
        ansOptionPos.SetActive(false);
        dioZi.SetActive(false);
        hitSlider.SetActive(false);
        //stateMap2.SetActive(false);
        //stateMap1.SetActive(false);
        //stateMap.SetActive(false);

        isOKToCatch = false;
        isOKToHijack = false;
        isOKToWalkDown = false;
        isQTE2 = false;
        qteSpeed = 20;

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
        if(isOKToWalkDown)
        {
            if (Input.GetMouseButton(0))
            {
                opWalkers.transform.localPosition += 80f * opWalkers.transform.up * Time.fixedDeltaTime;
                opWalkers2.transform.localPosition += 80f * opWalkers.transform.up * Time.fixedDeltaTime;
                caoMoAnimation.Play("CaoMoWalkUpMoving");
            }
            //14,78;-322;-66;154;350;
            if(opWalkers2.transform.localPosition.y > -322)
            {
                chuXiangLine.SetActive(true);
            }
            if (opWalkers2.transform.localPosition.y > -272)
            {
                chuXiangLine.SetActive(false);
                songXiangLine.SetActive(true);
            }
            if (opWalkers2.transform.localPosition.y > -116)
            {
                songXiangLine.SetActive(false);
                caoXiangLine.SetActive(true);
            }
            if (opWalkers2.transform.localPosition.y > -66)
            {
                caoXiangLine.SetActive(false);
                zhengXiangLine.SetActive(true);
            }
            if (opWalkers2.transform.localPosition.y > 104)
            {
                zhengXiangLine.SetActive(false);
                xingXiangLine.SetActive(true);
            }
            if (opWalkers2.transform.localPosition.y > 154)
            {
                xingXiangLine.SetActive(false);
                weiXiangLine.SetActive(true);
            }
            if (opWalkers2.transform.localPosition.y > 224)
            {
                weiXiangLine.SetActive(false);
            }
            if (opWalkers2.transform.localPosition.y > 350)
            {
                luXiangLine.SetActive(true);
                isOKToWalkDown = false;
                Invoke("AnsLuXiangOptionShowUp", 2.5f);
            }
        }
        if(isOKToCatch || isQTE2 || isQTE3)
        {
            hitSlider.GetComponent<Slider>().value -= Time.fixedDeltaTime * qteSpeed;
            if (hitSlider.GetComponent<Slider>().value < 1) FailHijack();
        }
    }

    void StageInDone()
    {
        stage.transform.DOLocalMove(new Vector3(0, -227, 0), 1.5f);
        daggerPos.transform.SetParent(stage.transform);
        stage.transform.DOScale(0.5f, 1.5f).OnComplete(() => StageZoomDone());
        
        //subText.SetActive(false);
        //isOKToMove = true;
    }
    void ShowDaggerSlider()
    {
        hitSlider.SetActive(true);
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
        daggerPos.transform.DOLocalMove(new Vector3(0, 333, 0), 8f).OnComplete(()=> FailHijack());
        dagger.transform.DORotate(new Vector3(0, 0, 540), 8f, RotateMode.FastBeyond360);
        isOKToCatch = true;
        Invoke("ShowDaggerSlider", 0.3f);
        subText.SetActive(true);
    }
    public void CheckDaggerClick()
    {
        isOKToCatch = false;
        isOKToHijack = true;
        daggerPos.transform.DOKill();
        dagger.transform.DOKill();
        Vector3 cP = daggerPos.transform.position;
        cP.x -= 50;
        caoMoPos.transform.position = cP;
        daggerPos.transform.SetParent(caoMoPos.transform);
        daggerPos.transform.SetAsFirstSibling();
        daggerPos.transform.localPosition = new Vector3(103, -60, 0);
        dagger.transform.rotation = Quaternion.Euler(0, 0, -28);
        subTextline1.SetActive(false);
        subTextline2.SetActive(true);
        hitSlider.transform.SetParent(huanState.transform);
        hitSlider.transform.localPosition = Vector3.zero;
        hitSlider.GetComponent<Slider>().value = 100;
        qteSpeed = 40;
        isQTE2 = true;
    }
    //103,-60; -28
    //75,203
    void FailHijack()
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
        isQTE2 = false;
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
        hitSlider.transform.SetParent(xiZi.transform);
        hitSlider.transform.localPosition = Vector3.zero;
        hitSlider.GetComponent<Slider>().value = 100;
        qteSpeed = 80;
        isQTE3 = true;
    }
    //-127,238;253,245;-163,60;317,58;
    //204,1535
    public void XiQiClicked()
    {
        xiZi.SetActive(false);
        CaoMoShout();
        isQTE3 = false;
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
        caoMoAudioSource.clip = caoMoTalkLand;
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
        Invoke("DioZiShowUp", 2f);
    }
    void DioZiShowUp()
    {
        dioZi.SetActive(true);
    }
    public void DaggerFlyAway()
    {
        dioZi.SetActive(false);
        daggerPos.transform.DOLocalMove(daggerPos.transform.localPosition + new Vector3(0, 1000f,0), 1f);
        Invoke("WalkDown", 2.5f);
    }
    void WalkDown()
    {
        subTextline8.SetActive(false);
        subTextline9.SetActive(true);
        zhuangPos.transform.SetParent(opWalkers.transform);
        caoMoPos.transform.DOLocalJump(new Vector3(14, 78, 0), 4, 3, 0.4f, false).OnComplete(()=> { isOKToWalkDown = true; });
    }
    //14,78;-322;-66;154;350;
    void AnsLuXiangOptionShowUp()
    {
        ansOptionPos.SetActive(true);
    }
    public void AnsLuXiang(int n)
    {
        luXiangLine.SetActive(false);
        luXiang.transform.SetParent(opWalkers.transform);
        ansOptionPos.SetActive(false);
        caoMoAudioSource.clip = caoMoExplain;
        if (n == 1)
        {
            caoMoLineText.text = "劫持了齐侯\n齐侯答应还地了";
            caoMoLine.SetActive(true);
        }
        if (n == 2)
        {
            caoMoLineText.text = "谈谈条件\n齐侯答应还地了";
            caoMoLine.SetActive(true);
        }
        if (n == 3)
        {
            caoMoLineText.text = "会盟而已\n齐侯答应还地了";
            caoMoLine.SetActive(true);
        }
        Invoke("AnsLuXiangDone", 2.5f);
    }
    void AnsLuXiangDone()
    {
        subTextline9.SetActive(false);
        subTextline10.SetActive(true);
        Invoke("BackToMentTan", 2.5f);
    }
    void BackToMentTan()
    {
        subText.SetActive(false);
        stage.transform.DOLocalMove(new Vector3(-60, -2038, 0), 0.3f, false).OnComplete(()=> HuanAngry());
    }
    void HuanAngry()
    {
        huanState.transform.DOShakePosition(600, 4, 10, 60, false, false);
        subTextline10.SetActive(false);
        subTextline11.SetActive(true);
        subText.SetActive(true);
        Invoke("GuanSaid1", 4f);
    }
    void GuanSaid1()
    {
        subTextline11.SetActive(false);
        subTextline12.SetActive(true);
        guanLine.SetActive(true);
        huanState.transform.DOKill();
        Invoke("GuanSaid2", 2.5f);
    }
    void GuanSaid2()
    {
        subTextline12.SetActive(false);
        subTextline13.SetActive(true);
        Invoke("GuanSaid3", 7f);
    }
    void GuanSaid3()
    {
        subTextline13.SetActive(false);
        subTextline14.SetActive(true);
        Invoke("HuanOptionShowUp", 3f);
    }
    void HuanOptionShowUp()
    {
        guanLine.SetActive(false);
        huanOption.SetActive(true);
    }
    public void HuanAns(int n)
    {
        huanOption.SetActive(false);
        guanLine.SetActive(false);
        if (n == 1)
        {
            huanLineText.text = "好的，仲父";
        }
        if (n == 2)
        {
            huanLineText.text = "明白，亚父";
        }
        if (n == 3)
        {
            huanLineText.text = "我懂，恩相";
        }
        huanAudioSource.clip = huanGet;
        huanLine.SetActive(true);
        Invoke("HuanAns2", 3.5f);
    }
    void HuanAns2()
    {
        huanLine.SetActive(false);
        huanAudioSource.clip = huanAgree;
        huanLineText.text = "别人的国土\n换自己的名声";
        huanLine.SetActive(true);
        Invoke("DealSet", 4.5f);
    }
    void DealSet()
    {
        huanLine.SetActive(false);
        subTextline14.SetActive(false);
        subTextline15.SetActive(true);
        Invoke("CutScene", 4.5f);
    }
    void CutScene()
    {
        SceneManager.LoadScene("112End");
    }
}