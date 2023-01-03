using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FightQiCtrl : MonoBehaviour
{
    public GameObject battleMap;
    public GameObject caoArmy;
    public GameObject luArmy;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("BattleMapFlyIn", 2f);
    }

    // Update is called once per frame
    void Update()
    {
        
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
        caoArmy.transform.DOLocalMove(new Vector3(-274, -110, 0), 1.5f);
        luArmy.transform.DOLocalMove(new Vector3(-309, -137, 0), 1.5f);
    }
}
