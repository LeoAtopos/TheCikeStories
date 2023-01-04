using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;
using TMPro;

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
    float luArmySpeed = 1;
    public GameObject luArmySquard1;
    public GameObject luArmySquard2;
    public GameObject luArmySquard3;
    public GameObject qiArmySquard2;
    public GameObject qiArmySquard3;
    public GameObject qiArmySquard4;

    public Sprite qiArmySprite;
    public GameObject lineText1;
    public GameObject lineText2;
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
        luArmySpeed = 1;
        qiArmySquard2.SetActive(false);
        qiArmySquard3.SetActive(false);
        qiArmySquard4.SetActive(false);
        lineText2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(fightTime == 1)
        {
            if (isLuArmyMovingForward)
                luArmy.transform.position += luArmySquard.transform.up * luArmySpeed * Time.deltaTime;
            if (isQiArmyMovingForward)
                qiArmy.transform.position += qiArmySquard.transform.up * 1 * Time.deltaTime;
        }
        if (fightTime == 2)
        {
            if (isLuArmyMovingForward)
                luArmy.transform.position += luArmySquard.transform.up * luArmySpeed * Time.deltaTime;
        }
        if(fightTime == 3)
        {
            if (isLuArmyMovingForward)
                luArmy.transform.position += luArmySquard.transform.up * luArmySpeed * Time.deltaTime;
            if (isQiArmyMovingForward)
                qiArmy.transform.position += qiArmySquard.transform.up * 5 * Time.deltaTime;
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
        if (fightTime < 3)
            Invoke("QiArmyShowUp", 3f);
        else
        {
            isQiArmyMovingForward = true;
            Invoke("LuArmyBetrayed", 6f);
        }  
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
        luArmySpeed = 20;

        luArmySquard2.SetActive(false);
        //luArmy.transform.SetParent(caoArmy.transform);
        Invoke("CaoLuArmyMovingIn", 0.5f);
        Invoke("ShockAttact", 8f);
    }
    void ShockAttact()
    {
        qiArmyShock.SetActive(true);
        Invoke("ShockCharge", 2f);
    }
    void ShockCharge()
    {
        qiArmyShock.transform.DOLocalMove(qiArmyShock.transform.localPosition + qiArmyShock.transform.up * 600, 4f);
        Invoke("LuArmyFallBack", 1);
    }
    void LuArmyFallBack()
    {
        luArmy.transform.rotation *= Quaternion.Euler(0, 0, 180f);
        luArmySpeed = 40;
        Invoke("QiArmyShow2and3", 2f);
    }
    void QiArmyShow2and3()
    {
        qiArmySquard2.SetActive(true);
        qiArmySquard3.SetActive(true);
        Invoke("QiArmyOffence", 2.5f);
    }
    void QiArmyOffence()
    {
        qiArmy.transform.DOLocalMove(new Vector3(-175, -16, 0), 0.3f);
        caoArmy.GetComponent<CaoMoArmyCtrl>().speed = 0;
        Invoke("SecondFail", 2f);
    }
    void SecondFail()
    {
        failText.SetActive(true);
        Invoke("ReadyThirdFight", 3);
    }
    void ReadyThirdFight()
    {
        fightTime++;

        isOKToMove = false;
        //qiArmy.SetActive(false);
        isLuArmyMovingForward = false;
        isQiArmyMovingForward = false;
        leftBorder.SetActive(false);
        BottonBorder.SetActive(false);
        qiArmySurrounds.SetActive(false);
        isLerking = false;
        failText.SetActive(false);
        qiArmyShock.SetActive(false);
        qiArmySquard.SetActive(true);
        //qiArmySquard.transform.localPosition = new Vector3(0, 0, 0);
        qiArmySquard.transform.rotation = qiArmySquardFacing;

        caoArmy.transform.position = caoArmyStartPos;
        luArmy.transform.position = luArmyStartPos;
        caoArmy.transform.rotation = caoArmyStartFacing;
        caoArmy.GetComponent<CaoMoArmyCtrl>().speed = 15f;
        luArmySpeed = 3;

        luArmySquard3.SetActive(false);
        luArmy.transform.rotation *= Quaternion.Euler(0, 0, 180f);
        qiArmySquard4.SetActive(true);
        //luArmy.transform.SetParent(caoArmy.transform);
        Invoke("CaoLuArmyMovingIn", 0.5f);
    }
    void LuArmyBetrayed()
    {
        luArmySquard.GetComponent<Image>().sprite = qiArmySprite;
        luArmySquard.GetComponentInChildren<TextMeshProUGUI>().text = "齐";
        luArmySquard.GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
        luArmySquard1.GetComponent<Image>().sprite = qiArmySprite;
        luArmySquard1.GetComponentInChildren<TextMeshProUGUI>().text = "齐";
        luArmySquard1.GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
        Invoke("ThirdFail", 4f);
    }
    void ThirdFail()
    {
        failText.SetActive(true);
        Invoke("ShowSecondLine", 3);
    }
    void ShowSecondLine()
    {
        lineText1.SetActive(false);
        lineText2.SetActive(true);
        Invoke("CutScene", 4);
    }
    void CutScene()
    {
        SceneManager.LoadScene("106LoseLand");
    }
}
