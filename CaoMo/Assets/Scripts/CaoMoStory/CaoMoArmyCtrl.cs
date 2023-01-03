using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CaoMoArmyCtrl : MonoBehaviour
{
    public GameObject armyText;
    public FightQiCtrl fqC;

    Vector3 targetPos;
    Vector3 dir;
    bool hasTarget = false;

    public bool isHit = false;
    // Start is called before the first frame update
    void Start()
    {
        isHit = false;
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
                float ang = Vector3.SignedAngle(transform.up, dir, Vector3.forward);
                transform.Rotate(new Vector3(0, 0, ang));
                hasTarget = true;
            }
            if (hasTarget)
            {
                Vector3 d = targetPos - transform.position;
                if (d.magnitude > 1)
                {
                    if(isHit)
                    {
                        isHit = false;
                        hasTarget = false;
                        fqC.caoArmy.transform.position -= 80 * Time.deltaTime * dir.normalized;
                    }
                    else
                    {
                        fqC.caoArmy.transform.position += 40 * Time.deltaTime * dir.normalized;
                    }
                }
                else
                {
                    hasTarget = false;
                }
            }
        }
        armyText.transform.rotation = Quaternion.identity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isHit = true;
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        isHit = true;
    }
}
