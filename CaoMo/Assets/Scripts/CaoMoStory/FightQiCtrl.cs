using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FightQiCtrl : MonoBehaviour
{
    public GameObject battleMap;
    public GameObject caoArmy;
    public GameObject luArmy;
    public GameObject luArmySquard;
    public GameObject qiArmy;
    public GameObject qiArmySquard;

    public bool isOKToMove = false;
    public bool isLuArmyMovingForward = false;
    public bool isQiArmyMovingForward = false;

    public GameObject leftBorder;
    public GameObject BottonBorder;

    public GameObject qiArmySurrounds;
    public bool isLerking = false;
    public GameObject failText;

    Vector3 caoArmyStartPos;
    Vector3 luArmyStartPos;
    Quaternion caoArmyStartFacing;
    Quaternion qiArmySquardFacing;

    public int fightTime;

    public GameObject qiArmyShock;
    // Start is called before the first frame update
    void Start()
    {
        fightTime = 1;
        caoArmyStartPos = caoArmy.transform.position;
        luArmyStartPos = luArmy.transform.position;
        caoArmyStartFacing = caoArmy.transform.rotation;
        qiArmySquardFacing = qiArmySquard.transform.rotation;
        isOKToMove = false;
        Invoke("BattleMapFlyIn", 1f);
        qiArmy.SetActive(false);
        isLuArmyMovingForward = false;
        isQiArmyMovingForward = false;
        leftBorder.SetActive(false);
        BottonBorder.SetActive(false);
        qiArmySurrounds.SetActive(false);
        isLerking = false;
        failText.SetActive(false);
        qiArmyShock.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(fightTime == 1)
        {
            if (isLuArmyMovingForward)
                luArmy.transform.position += luArmySquard.transform.up * 1 * Time.deltaTime;
            if (isQiArmyMovingForward)
                qiArmy.transform.position += qiArmySquard.transform.up * 1 * Time.deltaTime;
        }
        if (fightTime == 2)
        {
            if (isLuArmyMovingForward)
                luArmy.transform.position += luArmySquard.transform.up * 20 * Time.deltaTime;
        }

    }
    void BattleMapFlyIn()
    {
        battleMap.transform.DOLocalMove(new Vector3(0, 0, 0), 5f).OnComplete(()=> BattleMapFlyInDone());
    }
    void BattleMapFlyInDone()
    {
        Invoke("CaoLuArmyMovingIn", 0.5f);
    }
    void CaoLuArmyMovingIn()
    {
        caoArmy.transform.DOLocalMove(new Vector3(-274, -110, 0), 1.5f).OnComplete(()=> CaoMoArmyCanMove());
        luArmy.transform.DOLocalMove(new Vector3(-309, -137, 0), 1.5f);
    }
    void CaoMoArmyCanMove()
    {
        isOKToMove = true;
        Invoke("LuArmyMovingForward", 1.5f);
        Invoke("QiArmyShowUp", 3f);
        leftBorder.SetActive(true);
        BottonBorder.SetActive(true);
    }
    void LuArmyMovingForward()
    {
        isLuArmyMovingForward = true;
    }
    void QiArmyShowUp()
    {
        qiArmy.SetActive(true);
        isQiArmyMovingForward = true;
    }
    public void QiArmyFakeRunAway()
    {
        isQiArmyMovingForward = false;
        //Vector3 rot = qiArmySquard.transform.rotation.eulerAngles;
        //rot = new Vector3(rot.x, rot.y + 180, rot.z);
        qiArmySquard.transform.rotation *= Quaternion.Euler(0, 0, 180f);
        qiArmySquard.transform.DOLocalMove(qiArmySquard.transform.up * 100 + qiArmySquard.transform.localPosition, 1.5f).OnComplete(()=> LerkingCaoMo());
    }
    void LerkingCaoMo()
    {
        isLerking = true;
    }
    public void AnbushCaoMo()
    {
        qiArmySurrounds.SetActive(true);
        qiArmySurrounds.transform.SetParent(battleMap.transform);
        qiArmySquard.SetActive(false);
        Invoke("FirstFail", 5f);
    }
    void FirstFail()
    {
        failText.SetActive(true);
        Invoke("ReadySecondFight", 3);
    }
    void ReadySecondFight()
    {
        fightTime++;

        isOKToMove = false;
        qiArmy.SetActive(false);
        isLuArmyMovingForward = false;
        isQiArmyMovingForward = false;
        leftBorder.SetActive(false);
        BottonBorder.SetActive(false);
        qiArmySurrounds.SetActive(false);
        isLerking = false;
        failText.SetActive(false);
        qiArmyShock.SetActive(false);
        qiArmySquard.SetActive(true);
        qiArmySquard.transform.localPosition = new Vector3(0, 0, 0);
        qiArmySquard.transform.rotation = qiArmySquardFacing;

        caoArmy.transform.position = caoArmyStartPos;
        luArmy.transform.position = luArmyStartPos;
        caoArmy.transform.rotation = caoArmyStartFacing;
        caoArmy.GetComponent<CaoMoArmyCtrl>().speed = 25f;
        //luArmy.transform.SetParent(caoArmy.transform);
        Invoke("CaoLuArmyMovingIn", 0.5f);
        Invoke("ShockAttact", 3f);
    }
    void ShockAttact()
    {
        qiArmyShock.SetActive(true);
        qiArmyShock.transform.DOLocalMove(qiArmyShock.transform.localPosition + qiArmyShock.transform.up * 2000, 1f);
        luArmy.transform.rotation *= Quaternion.Euler(0, 0, 180f);
    }
}
