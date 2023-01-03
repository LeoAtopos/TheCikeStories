using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CaoMoArmyCtrl : MonoBehaviour
{
    public GameObject armyImage;
    public FightQiCtrl fqC;

    Vector3 targetPos;
    Vector3 dir;
    bool hasTarget = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (fqC.isOKToMove)
        {
            if (Input.GetMouseButton(0))
            {
                targetPos = Input.mousePosition;
                dir = targetPos - transform.position;
                float ang = Vector3.SignedAngle(armyImage.transform.up, dir, Vector3.forward);
                armyImage.transform.Rotate(new Vector3(0, 0, ang));
                hasTarget = true;
            }
            if (hasTarget)
            {
                Vector3 d = targetPos - transform.position;
                if (d.magnitude > 1)
                {
                    fqC.caoArmy.transform.position += 20 * Time.deltaTime * dir.normalized;
                }
                else
                {
                    hasTarget = false;
                }
            }
        }
    }
}
