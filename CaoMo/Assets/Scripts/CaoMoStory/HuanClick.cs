using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HuanClick : MonoBehaviour, IPointerClickHandler
{
    public HijackCtrl hJC;
    public void OnPointerClick(PointerEventData eventData)
    {
        if (hJC.isOKToHijack)
            hJC.HijackMOve();
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
