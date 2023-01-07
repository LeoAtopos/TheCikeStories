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
    void Update()
    {
        transform.localPosition += transform.up * 1 * Time.deltaTime;
    }
}
