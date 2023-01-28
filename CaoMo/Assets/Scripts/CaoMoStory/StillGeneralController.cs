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
    public Image caoMoImage;
    public Sprite caoMoCarry;
    public GameObject caoMOGeneralState;
    public GameObject caoMoLine;
    public TextMeshProUGUI caoMoLineText;
    public GameObject bingPos;
    public GameObject dioZi;

    public bool isOKToMove = false;
    public bool isCaoMoCanMove = false;
    public bool isOKToDio = false;
    public bool isOKTOCharge = false;
    public Animator caoMoAnimator;
    public Animator horseAnimator;
    public GameObject trees;
    bool isChargeDone = false;
    private bool isCuttingScene = false;

    public AudioClip dioWoAudioClip;
    public GameObject dirCursor;
    public AudioSource dioSound;

    public AudioSource bladeOn;

    // Start is called before the first frame update
    void Start()
    {
        stateMap.GetComponent<Image>().DOFade(0, 1.5f).OnComplete(()=> HideStateMap());
        subTextBoard.SetActive(false);
        swordGeneral.SetActive(false);
        zhuangLine.SetActive(false);
        caoMOGeneralState.SetActive(false);
        caoMoLine.SetActive(false);
        trees.SetActive(false);
        bingPos.SetActive(false);
        isOKToMove = false;
        isCaoMoCanMove = false;
        isOKToDio = false;
        isOKTOCharge = false;
        isChargeDone = false;
        isCuttingScene = false;
        dioZi.SetActive(false);
        dirCursor.SetActive(false);
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
                    caoMoPos.transform.localPosition += new Vector3(-30 * Time.fixedDeltaTime, 0, 0);
                    caoMoAnimator.Play("CaoMoCrippleMoving");
                    dirCursor.SetActive(false);
                }
            }
            else if (Input.mousePosition.x - caoMoPos.transform.position.x < -5.0f)
            {
                //dirCursor.GetComponent<RectTransform>().localScale = new Vector3(-1, 1, 1);
                dirCursor.SetActive(true);
            }
            else
            {
                dirCursor.SetActive(false);
                Cursor.visible = true;
            }
            if (caoMoPos.transform.localPosition.x <130f)
            {
                swordGeneral.SetActive(true);
            }
            if (caoMoPos.transform.localPosition.x < -80f)
            {
                bladeOn.Play();
                isCaoMoCanMove = false;
                ZhuangActStart();
            }
        }
        if (isOKTOCharge)
        {

            horseAnimator.Play("HorseMoving");
            trees.transform.localPosition += new Vector3(-600 * Time.deltaTime, 0, 0);

            if (trees.transform.localPosition.x <= -2500.0f)
            {
                isOKTOCharge = false;
                isChargeDone = true;
            }
        }
        if (isChargeDone)
        {
            isCuttingScene = true;
            caoMoPos.transform.DOLocalMove(new Vector3(-1000, 0, 0), 3).OnComplete(() => CutScene());
            isChargeDone = false;
        }
        if (isCuttingScene)
        {
            horseAnimator.Play("HorseMoving");
            trees.transform.localPosition += new Vector3(-600 * Time.deltaTime, 0, 0);
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
        Invoke("HideZhuangLine", 3f);
    }
    void HideZhuangLine()
    {
        zhuangLine.SetActive(false);
    }
    void CaoMoMovingIn()
    {
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
        zhuangLineText.text = "丢孤！";
        zhuangLine.GetComponent<AudioSource>().clip = dioWoAudioClip;
        zhuangLine.GetComponent<AudioSource>().Play();
        Invoke("ZhuangAskDioDone", 3f);
    }
    void ZhuangAskDioDone()
    {
        zhuangLine.SetActive(false);
        Invoke("CaoMoCarryZhuang", 2f);
    }
    void CaoMoCarryZhuang()
    {
        caoMoImage.sprite = caoMoCarry;
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
        dioSound.Play();
        Vector3 cPos = caoMoPos.transform.localPosition;
        cPos.y -= 500f;
        caoMoPos.transform.DOLocalMove(cPos, 0.3f).OnComplete(()=> FlyZhuangAway());
        dioZi.SetActive(false);
        zhuangPos.GetComponent<AudioSource>().Play();
    }
    void FlyZhuangAway()
    {
        Invoke("ZhuangFlyAway", 1f);
        Invoke("DropToCaoMo", 3f);
        caoMoState.SetActive(false);
        caoMOGeneralState.SetActive(true);
        bingPos.SetActive(true);
        swordGeneral.transform.localPosition = new Vector3(120, -93, 0);
    }
    void ZhuangFlyAway()
    {
        Vector3 zPos = zhuangPos.transform.localPosition;
        zPos.y += 2000;
        zhuangPos.transform.DOLocalMove(zPos, 2);
    }
    void DropToCaoMo()
    {
        Vector3 cPos = caoMoPos.transform.localPosition;
        cPos.y += 600f;
        caoMoPos.transform.DOLocalMove(cPos, 1.2f).OnComplete(() => DropDownDone());
    }
    void DropDownDone()
    {
        subTextBoard.SetActive(true);
        trees.SetActive(true);
        Invoke("ZoomOut", 1.5f);
    }
    void ZoomOut()
    {
        caoMoPos.transform.DOScale(0.45f, 0.5f).OnComplete(() => MaCheBingGethered());
    }
    void MaCheBingGethered()
    {
        Invoke("ShowLine", 1f);
        Invoke("ChargeOn", 2.5f);
    }
    void ShowLine()
    {
        caoMoLine.SetActive(true);
    }
    void ChargeOn()
    {
        isOKTOCharge = true;
        caoMoLine.SetActive(false);
    }
    void CutScene()
    {
        SceneManager.LoadScene("109MakeMeeting");
    }
}
