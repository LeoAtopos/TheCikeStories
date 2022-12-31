using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DioZiHandle : MonoBehaviour, IPointerClickHandler
{
    public CaoMoSpriteController cmSC;
    public void OnPointerClick(PointerEventData eventData)
    {
        if (cmSC.isOKToLeadAgain)
            cmSC.ThrowZeiBody();
        Debug.Log("clicked");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
