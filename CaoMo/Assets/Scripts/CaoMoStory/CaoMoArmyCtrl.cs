using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class CaoMoArmyCtrl : MonoBehaviour
{
    public GameObject armyText;
    public FightQiCtrl fqC;

    Vector3 targetPos;
    Vector3 dir;
    bool hasTarget = false;

    public bool isHit = false;
    public GameObject fightSign;
    int firstTimeFightNum = 0;

    public float speed = 40f;
    
    // Start is called before the first frame update
    void Start()
    {
        isHit = false;
        fightSign.SetActive(false);
        firstTimeFightNum = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (fqC.isOKToMove)
        {
            if (Input.GetMouseButton(0))
            {
                Vector3 screenPoint = Input.mousePosition;
                screenPoint.z = 10.0f; //distance of the plane from the camera
                targetPos = Camera.main.ScreenToWorldPoint(screenPoint);
                targetPos.z = transform.position.z;
                dir = targetPos - transform.position;
                float ang = Vector3.SignedAngle(transform.up, dir, Vector3.forward);
                transform.Rotate(new Vector3(0, 0, ang));
                hasTarget = true;
            }
            if (hasTarget)
            {
                Vector3 d = targetPos - transform.position;
                if (d.magnitude > 0.1f)
                {
                    if(isHit)
                    {
                        isHit = false;
                        hasTarget = false;
                        fqC.caoArmy.transform.localPosition -= 0.01f * speed * Time.fixedDeltaTime * dir.normalized;
                    }
                    else
                    {
                        fqC.caoArmy.transform.localPosition += speed * Time.fixedDeltaTime * dir.normalized;
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
        if (collision.gameObject.name.Contains("QiArmy"))
        {
            ShowFightSign(gameObject, collision.gameObject);
            if (fqC.isLerking && collision.gameObject.name == "QiArmySquard001")
            {
                fqC.AnbushCaoMo();
            }
            
        }   
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        isHit = true;
    }
    private void ShowFightSign(GameObject gameObject1, GameObject gameObject2)
    {
        fightSign.SetActive(true);
        fightSign.transform.position = (gameObject1.transform.position + gameObject2.transform.position) / 2;
        fightSign.transform.DOShakePosition(1f, 1, 8, 60, false, false).OnComplete(() => FirstFightHappened());
    }
    void FirstFightHappened()
    {
        firstTimeFightNum++;
        fightSign.SetActive(false);
        if(firstTimeFightNum == 3)
        {
            QiArmyFakeRunAway();
        }
    }
    void QiArmyFakeRunAway()
    {
        fqC.QiArmyFakeRunAway();
    }
}
