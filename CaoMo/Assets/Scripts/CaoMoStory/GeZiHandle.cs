using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GeZiHandle : MonoBehaviour, IPointerClickHandler
{
    public CutLandController cLC;
    public void OnPointerClick(PointerEventData eventData)
    {
        transform.localScale *= 2.5f;
        cLC.CutLand();
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
