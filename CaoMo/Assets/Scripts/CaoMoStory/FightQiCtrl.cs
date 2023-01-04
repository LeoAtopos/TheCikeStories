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
    // Start is called before the first frame update
    void Start()
    {
        isOKToMove = false;
        Invoke("BattleMapFlyIn", 1f);
        qiArmy.SetActive(false);
        isLuArmyMovingForward = false;
        isQiArmyMovingForward = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(isLuArmyMovingForward)
            luArmy.transform.position += luArmySquard.transform.up * 1 * Time.deltaTime;
        if(isQiArmyMovingForward)
            qiArmy.transform.position += qiArmySquard.transform.up * 1 * Time.deltaTime;

    }
    void BattleMapFlyIn()
    {
        battleMap.transform.DOLocalMove(new Vector3(0, 0, 0), 3f).OnComplete(()=> BattleMapFlyInDone());
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
}
