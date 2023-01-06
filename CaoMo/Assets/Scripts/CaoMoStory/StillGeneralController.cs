using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;
using TMPro;


public class StillGeneralController : MonoBehaviour
{
    public GameObject stateMap;
    public GameObject subTextBoard;
    public GameObject zhuangPos;
    public GameObject swordGeneral;
    public GameObject zhuangLine;
    public TextMeshProUGUI zhuangLineText;
    public GameObject caoMoPos;
    public GameObject caoMoState;
    public GameObject caoMoLine;
    public TextMeshProUGUI caoMoLineText;
    public GameObject bingPos;
    public GameObject dioZi;

    public bool isOKToMove = false;
    public bool isCaoMoCanMove = false;
    public bool isOKToDio = false;
    public Animator caoMoAnimator;
    // Start is called before the first frame update
    void Start()
    {
        stateMap.GetComponent<Image>().DOFade(0, 1.5f).OnComplete(()=> HideStateMap());
        subTextBoard.SetActive(false);
        swordGeneral.SetActive(false);
        zhuangLine.SetActive(false);
        caoMoLine.SetActive(false);
        isOKToMove = false;
        isCaoMoCanMove = false;
        isOKToDio = false;
        dioZi.SetActive(false);
        Invoke("CallCaoMo", 1f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(isCaoMoCanMove)
        {
            if (Input.GetMouseButton(0))
            {
                if (Input.mousePosition.x - caoMoPos.transform.position.x < -5.0f)
                {
                    //left move
                    caoMoPos.transform.position += new Vector3(-30 * Time.fixedDeltaTime, 0, 0);
                    caoMoAnimator.Play("CaoMoCrippleMoving");
                }
            }
            if(caoMoPos.transform.localPosition.x <130f)
            {
                swordGeneral.SetActive(true);
            }
            if (caoMoPos.transform.localPosition.x < -80f)
            {
                isCaoMoCanMove = false;
                ZhuangActStart();
            }
        }
    }
    void HideStateMap()
    {
        stateMap.SetActive(false);
    }
    void CallCaoMo()
    {
        zhuangLine.SetActive(true);
        Invoke("CaoMoMovingIn", 1f);
    }
    void CaoMoMovingIn()
    {
        zhuangLine.SetActive(false);
        caoMoPos.transform.DOLocalMove(-200 * caoMoPos.transform.right + caoMoPos.transform.localPosition, 2f);
        zhuangPos.transform.DOLocalMove(-100 * zhuangPos.transform.right + zhuangPos.transform.localPosition, 2f).OnComplete(()=> CaoMoCanMove());
    }
    void CaoMoCanMove()
    {
        isCaoMoCanMove = true;
    }
    void ZhuangActStart()
    {
        swordGeneral.transform.SetParent(caoMoPos.transform);
        swordGeneral.transform.localPosition = new Vector3(50, -113, 0);
        Invoke("ZhuangAskDio", 1f);
    }
    void ZhuangAskDio()
    {
        zhuangLine.SetActive(true);
        zhuangLineText.text = "丢我！";
        Invoke("ZhuangAskDioDone", 3f);
    }
    void ZhuangAskDioDone()
    {
        zhuangLine.SetActive(false);
        Invoke("CaoMoCarryZhuang", 2f);
    }
    void CaoMoCarryZhuang()
    {
        zhuangPos.transform.localPosition = new Vector3(-152, 109, 0);
        isOKToDio = true;
        Invoke("DioZiShow", 1.0f);
    }
    void DioZiShow()
    {
        dioZi.SetActive(true);
    }
    public void ThrowZhuang()
    {
        Vector3 zPos = zhuangPos.transform.localPosition;
        zhuangPos.transform.DOLocalJump(zPos, 8000, 1, 10f, false);
        dioZi.SetActive(false);
    }
}
