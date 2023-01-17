using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DaggerClick : MonoBehaviour, IPointerClickHandler
{
    public HijackCtrl hJC;
    public void OnPointerClick(PointerEventData eventData)
    {
        if (hJC.isOKToCatch)
            hJC.CheckDaggerClick();
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
