using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OptionController : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public MakeMeetingController mMC;
    public GameObject hooveOverImage;
    public void OnPointerClick(PointerEventData eventData)
    {
        if(gameObject.name == "Option1")
            mMC.HuanAns(1);
        if (gameObject.name == "Option2")
            mMC.HuanAns(2);
        if (gameObject.name == "Option3")
            mMC.HuanAns(3);
        hooveOverImage.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        hooveOverImage.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        hooveOverImage.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        hooveOverImage.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
