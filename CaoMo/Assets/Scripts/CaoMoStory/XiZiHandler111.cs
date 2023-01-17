using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class XiZiHandler111 : MonoBehaviour, IPointerClickHandler
{
    public HijackCtrl hC;
    public void OnPointerClick(PointerEventData eventData)
    {
        hC.XiQiClicked();
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
