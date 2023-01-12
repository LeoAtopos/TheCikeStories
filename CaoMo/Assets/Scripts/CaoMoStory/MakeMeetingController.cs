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
    public GameObject guanPos;
    public GameObject guanTitleText;
    // Start is called before the first frame update
    void Start()
    {
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
    }
}
