using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CaoMoShoutLineCtrl : MonoBehaviour
{
    // Start is called before the first frame update
    void OnEnable()
    {
        transform.DOShakePosition(5.0f, 5.0f, 9, 80.0f, false, false);
        Debug.Log("called");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
