using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaoMoBodyShowUpCtrl : MonoBehaviour
{
    public CaoMoSpriteController cmSC;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowUpEnd()
    {
        cmSC.SetOkToMove();
    }
}
