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
    // Start is called before the first frame update
    void Start()
    {
        subText.SetActive(false);
        stage.transform.DOLocalMove(new Vector3(0, 0, 0), 5f).OnComplete(() => StageInDone());
        //stage.transform.DOLocalMove(new Vector3(0, 0, 0), 0.1f).OnComplete(() => StageInDone());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void StageInDone()
    {
        subText.SetActive(true);
    }
}
