using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OptionController : MonoBehaviour, IPointerClickHandler
{
    public MakeMeetingController mMC;
    public void OnPointerClick(PointerEventData eventData)
    {
        if(gameObject.name == "Option1")
            mMC.HuanAns(1);
        if (gameObject.name == "Option2")
            mMC.HuanAns(2);
        if (gameObject.name == "Option3")
            mMC.HuanAns(3);
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
