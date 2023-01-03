using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmySquardCtrl : MonoBehaviour
{
    public GameObject armyText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        armyText.transform.rotation = Quaternion.identity;
    }
}
