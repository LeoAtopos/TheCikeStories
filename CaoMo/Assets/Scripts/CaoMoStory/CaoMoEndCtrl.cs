using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System;

public class CaoMoEndCtrl : MonoBehaviour
{
    public GameObject zhuangPos;
    public GameObject nextButton;
    public GameObject subTextLine1;
    public GameObject subTextLine2;
    public bool isCheckingEnd;
    bool isOnShoulder;
    bool isOnRight;
    int jumpNum;
    // Start is called before the first frame update
    void Start()
    {
        nextButton.SetActive(false);
        isOnRight = true;
        isOnShoulder = true;
        isCheckingEnd = false;
        jumpNum = 0;
    }

    // 115,93;-115
    void Update()
    {
        if(isOnShoulder && !isCheckingEnd && Input.GetMouseButtonDown(0))
        {
            zhuangPos.GetComponent<AudioSource>().Play();
            if(isOnRight)
            {
                zhuangPos.transform.DOLocalJump(new Vector3(-115, 93, 0), 500, 1, 0.5f, false).OnComplete(()=> Landed());
            }
            else
            {
                zhuangPos.transform.DOLocalJump(new Vector3(115, 93, 0), 500, 1, 0.5f, false).OnComplete(() => Landed());
            }
            isOnShoulder = false;
            isOnRight = !isOnRight;
            jumpNum++;
            if (jumpNum > 3)
                nextButton.SetActive(true);
        }
    }
    void Landed()
    {
        isOnShoulder = true;
    }
    public void NextButtonClicked()
    {
        nextButton.SetActive(false);
        subTextLine1.SetActive(false);
        subTextLine2.SetActive(true);
        Invoke("CutScene", 6f);
    }
    void CutScene()
    {
        SceneManager.LoadScene("Start02");
    }
}
