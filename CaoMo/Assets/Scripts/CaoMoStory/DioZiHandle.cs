using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DioZiHandle : MonoBehaviour, IPointerClickHandler
{
    public CaoMoSpriteController cmSC;
    public StillGeneralController sGC;
    public void OnPointerClick(PointerEventData eventData)
    {
        if(cmSC != null)
        {
            if (!cmSC.isDioZhuang)
                cmSC.ThrowZeiBody();
            else
                cmSC.ThrowZhuang();
        }
        if(sGC != null)
        {
            if (sGC.isOKToDio)
                sGC.ThrowZhuang();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
