using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CaoMoToWar : MonoBehaviour
{
    public GameObject caoMoHire;
    public GameObject caoMoHelmet;
    public GameObject caoMoBodyNormal;
    public GameObject caoMoBodyArmed;
    public GameObject maChe;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("NormalFitFlyAway", 1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void NormalFitFlyAway()
    {
        caoMoHire.transform.DOLocalMove(new Vector3(-0.5f, 1000f, 0), 1f);
        caoMoBodyNormal.transform.DOLocalMove(new Vector3(0f, -1000f, 0), 1f);
        Invoke("ArmFitFlyIn", 1f);
    }
    void ArmFitFlyIn()
    {
        caoMoHelmet.transform.DOLocalMove(new Vector3(-0.5f, 0.5f, 0), 0.5f);
        caoMoBodyArmed.transform.DOLocalMove(new Vector3(0f, -63.5f, 0), 0.5f);
        Invoke("MaCheFlyIn", 1f);
    }
    void MaCheFlyIn()
    {
        maChe.transform.DOLocalMove(new Vector3(129.9f, -87.6f, 0), 1f);
        Invoke("ZoomOut", 2f);
    }
    void ZoomOut()
    {

    }
}
