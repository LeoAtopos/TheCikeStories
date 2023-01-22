using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class QiAnbushArmyMoveForward : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += transform.up * 8f * Time.fixedDeltaTime;
    }
}
