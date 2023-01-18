using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OptionCtrl111 : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public HijackCtrl hC;
    public GameObject hooveOverImage;
    public void OnPointerClick(PointerEventData eventData)
    {
        if (gameObject.transform.parent.name == "OptionPos")
        {
            if (gameObject.name == "Option1")
                hC.OptionChecked(1, this.gameObject);
            if (gameObject.name == "Option2")
                hC.OptionChecked(2, this.gameObject);
            if (gameObject.name == "Option3")
                hC.OptionChecked(3, this.gameObject);
            hooveOverImage.SetActive(false);
        }
        if (gameObject.transform.parent.name == "AnsOptionPos")
        {
            if (gameObject.name == "Option1")
                hC.AnsLuXiang(1);
            if (gameObject.name == "Option2")
                hC.AnsLuXiang(2);
            if (gameObject.name == "Option3")
                hC.AnsLuXiang(3);
        }
        if (gameObject.transform.parent.name == "HuanOptions")
        {
            if (gameObject.name == "Option1")
                hC.HuanAns(1);
            if (gameObject.name == "Option2")
                hC.HuanAns(2);
            if (gameObject.name == "Option3")
                hC.HuanAns(3);
        }
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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
