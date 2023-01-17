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
        if (gameObject.name == "Option1")
            hC.OptionChecked(1, this.gameObject);
        if (gameObject.name == "Option2")
            hC.OptionChecked(2, this.gameObject);
        if (gameObject.name == "Option3")
            hC.OptionChecked(3, this.gameObject);
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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
