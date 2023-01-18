using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class NextButton112 : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    CaoMoEndCtrl cmEC;
    GameObject hooveOverImage;
    public void OnPointerClick(PointerEventData eventData)
    {
        cmEC.NextButtonClicked();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        hooveOverImage.SetActive(true);
        cmEC.isCheckingEnd = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        hooveOverImage.SetActive(false);
        cmEC.isCheckingEnd = false;
    }

    void Awake()
    {
        cmEC = FindObjectOfType<CaoMoEndCtrl>();
        hooveOverImage = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
