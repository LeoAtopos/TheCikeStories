using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OptionController : MonoBehaviour, IPointerClickHandler
{
    public MakeMeetingController mMC;
    public void OnPointerClick(PointerEventData eventData)
    {
        mMC.HuanAns(1);
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
