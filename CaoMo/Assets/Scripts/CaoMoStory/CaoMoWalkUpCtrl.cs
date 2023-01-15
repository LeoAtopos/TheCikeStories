using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System;

public class CaoMoWalkUpCtrl : MonoBehaviour
{
    public GameObject stage;
    public GameObject subText;

    public GameObject walkers;
    public GameObject opWalkers;
    public GameObject opWalkers2;
    public GameObject luXiang;
    public GameObject qiBingLine;
    public GameObject weiXiangLine;
    public GameObject xingXiangLine;
    public GameObject zhengXiangLine;
    public GameObject caoXiangLine;
    public GameObject chuXiangLine;
    public GameObject songXiangLine;

    bool isOKToMove;
    bool isNoteHaveStopped;
    // Start is called before the first frame update
    void Start()
    {
        qiBingLine.SetActive(false);
        weiXiangLine.SetActive(false);
        xingXiangLine.SetActive(false);
        zhengXiangLine.SetActive(false);
        caoXiangLine.SetActive(false);
        chuXiangLine.SetActive(false);
        songXiangLine.SetActive(false);
        subText.SetActive(false);
        isOKToMove = false;
        isNoteHaveStopped = true;
        //stage.transform.DOLocalMove(new Vector3(0, 0, 0), 5f).OnComplete(() => StageInDone());
        stage.transform.DOLocalMove(new Vector3(0, 0, 0), 0.1f).OnComplete(() => StageInDone());
    }

    // -176,-707,-931,-1141,-1600
    void FixedUpdate()
    {
        if(isOKToMove)
        {
            if(Input.GetMouseButton(0))
            {
                opWalkers.transform.localPosition -= 80f * opWalkers.transform.up  * Time.fixedDeltaTime;
                opWalkers2.transform.localPosition -= 80f * opWalkers.transform.up * Time.fixedDeltaTime;
            }
            if (isNoteHaveStopped && opWalkers.transform.localPosition.y < -176)
                StopZhuang();
            if (opWalkers.transform.localPosition.y < -607)
                weiXiangLine.SetActive(true);
            if (opWalkers.transform.localPosition.y < -657)
            {
                weiXiangLine.SetActive(false);
                xingXiangLine.SetActive(true);
            }
            if (opWalkers.transform.localPosition.y < -831)
                zhengXiangLine.SetActive(true);
            if (opWalkers.transform.localPosition.y < -881)
            {
                zhengXiangLine.SetActive(false);
                caoXiangLine.SetActive(true);
            }
            if (opWalkers.transform.localPosition.y < -1041)
                songXiangLine.SetActive(true);
            if (opWalkers.transform.localPosition.y < -1091)
            {
                songXiangLine.SetActive(false);
                chuXiangLine.SetActive(true);
            }

        }
    }

    private void StopZhuang()
    {
        isOKToMove = false;
        qiBingLine.SetActive(true);
        Invoke("XiangMoveAway", 2.5f);
    }
    void XiangMoveAway()
    {
        luXiang.transform.SetParent(opWalkers.transform);
        luXiang.transform.DOLocalMove(luXiang.transform.localPosition + luXiang.transform.right * 100, 1f).OnComplete(() => LuXiangMoveDone());
    }
    void LuXiangMoveDone()
    {
        qiBingLine.SetActive(false);
        isOKToMove = true;
        isNoteHaveStopped = false;
    }
    void StageInDone()
    {
        subText.SetActive(true);
        isOKToMove = true;
    }
}
