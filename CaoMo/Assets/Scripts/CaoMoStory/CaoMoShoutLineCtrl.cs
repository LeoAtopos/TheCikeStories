using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CaoMoShoutLineCtrl : MonoBehaviour
{
    // Start is called before the first frame update
    void OnEnable()
    {
        transform.DOShakePosition(5.0f, 10.0f, 30, 80.0f, false, false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
