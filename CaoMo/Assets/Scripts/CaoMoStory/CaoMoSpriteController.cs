using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class CaoMoSpriteController : MonoBehaviour
{
    public Animator animator;
    public Animator horseAnimator;
    public bool isOKToMove = false;
    public bool isOKToLead = false;
    public bool isOKToLeadAgain = false;

    public GameObject maChe;
    public GameObject zhuang;
    public GameObject zhuangTitleText;
    public GameObject zhuangLines;

    public GameObject trees;
    public GameObject zei;
    public Animator zeiAnimator;
    public GameObject zeiSword;
    public GameObject zeiBody;
    public Sprite zeiBodyDeadSprite;
    public Sprite swordBloodSprite;
    public GameObject zeiHead;
    public GameObject zeiMobsNear;
    public GameObject zeiMobsFar;
    public GameObject zeiShoutLine;

    public GameObject xiZi;
    public float xiZiScale;
    public bool isXiing = false;

    public Animator caoMoHeadShoutAnimator;
    public GameObject caoMoShoutLine;

    public GameObject dioZi;
    bool isZeiCought = false;
    bool isDioZiShowed = false;

    public TextMeshProUGUI zhuangLineText;
    public Sprite caoMoBodyCarrySprite;
    public GameObject caoMoBody;
    public bool isDioZhuang = false;
    int dioZhuangNum = 0;

    public GameObject CaoMoScript003;
    public GameObject CaoMoScript004;
    public Sprite horseBigEye;
    public GameObject horse;
    public GameObject maCheImage;

    public GameObject audioController;

    public GameObject dirCursor;

    public AudioSource dioSound;
    // Start is called before the first frame update
    void Start()
    {
        CaoMoScript003.SetActive(true);
        CaoMoScript004.SetActive(false);
        isOKToMove = false;
        isOKToLead = false;
        isOKToLeadAgain = false;
        zhuangLines.SetActive(false);
        zeiShoutLine.SetActive(false);
        xiZi.SetActive(false);
        isXiing = false;
        xiZiScale = 1;
        caoMoShoutLine.SetActive(false);
        dioZi.SetActive(false);
        isZeiCought = false;
        isDioZiShowed = false;
        isDioZhuang = false;
        dioZhuangNum = 0;
        dirCursor.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(isOKToMove)
        {
            if(Input.GetMouseButton(0))
            {
                if (Input.mousePosition.x - transform.position.x < -5.0f)
                {
                    //left move
                    transform.localPosition += new Vector3(-250 * Time.fixedDeltaTime, 0 , 0);
                    animator.Play("CaoMoMoving");
                    dirCursor.SetActive(false);
                }
                else if(Input.mousePosition.x - transform.position.x > 5.0f)
                {
                    //right move
                    transform.localPosition += new Vector3( 250 * Time.fixedDeltaTime, 0 , 0);
                    animator.Play("CaoMoMoving");
                }
            }else if (Input.mousePosition.x - transform.position.x < -5.0f)
            {
                dirCursor.SetActive(true);
            }else
            {
                dirCursor.SetActive(false);
                Cursor.visible = true;
            }

            if (gameObject.GetComponent<RectTransform>().localPosition.x < -290.0f)
            {
                isOKToMove = false;
                maChe.transform.SetParent(transform);
                PlayInToStep2();
            }
        }

        if(isOKToLead)
        {
            if(Input.GetMouseButton(0))
            {
                if (Input.mousePosition.x > transform.position.x + 10.0f)
                {
                    animator.Play("CaoMoMoving");
                    horseAnimator.Play("HorseMoving");
                    trees.transform.localPosition += new Vector3(-250 * Time.fixedDeltaTime,0,0);
                    dirCursor.SetActive(false);
                }
            }
            else if (Input.mousePosition.x > transform.position.x + 10.0f)
            {
                dirCursor.GetComponent<RectTransform>().localScale = new Vector3(-1, 1, 1);
                dirCursor.SetActive(true);
            }
            else
            {
                dirCursor.SetActive(false);
                Cursor.visible = true;
            }

            if (trees.transform.localPosition.x <= -470.0f)
            {
                isOKToLead = false;
                ZeiJump();
            }
        }

        if(isXiing)
        {
            xiZiScale += 0.2f * Time.fixedDeltaTime;
            xiZi.transform.DOScale( xiZiScale, 0);
            Color xiZiColor = xiZi.GetComponent<Image>().color;
         
            xiZiColor.a = (xiZiColor.a >0.1f)? (xiZiColor.a - 0.001f) : 0.1f;
            xiZi.GetComponent<Image>().color = xiZiColor;
            if (xiZiScale > 15.5f)
            {
                isXiing = false;
                CaoMoXiGou();
            }
        }

        if(isOKToLeadAgain)
        {
            if (Input.GetMouseButton(0))
            {
                if (Input.mousePosition.x > transform.position.x + 10.0f)
                {
                    animator.Play("CaoMoMoving");
                    horseAnimator.Play("HorseMoving");
                    trees.transform.localPosition += new Vector3(-250 * Time.fixedDeltaTime, 0, 0);
                    dirCursor.SetActive(false);
                }
            }
            else if (Input.mousePosition.x > transform.position.x + 10.0f)
            {
                dirCursor.GetComponent<RectTransform>().localScale = new Vector3(-1, 1, 1);
                dirCursor.SetActive(true);
            }
            else
            {
                dirCursor.SetActive(false);
                Cursor.visible = true;
            }
            if (trees.transform.localPosition.x <= -840.0f && !isZeiCought)
            {
                CatchUpZei();
                isZeiCought = true;
            }
            if (trees.transform.localPosition.x <= -940.0f && !isDioZiShowed)
            {
                ShowThrowButton();
                isDioZiShowed = true;
                dirCursor.SetActive(false);
                Cursor.visible = true;
            }
            if(trees.transform.localPosition.x <= -2800.0f)
            {
                isOKToLeadAgain = false;
            }
        }
    }

    public void SetOkToMove()
    {
        isOKToMove = true;
    }

    void PlayInToStep2()
    {
        transform.DOLocalMove(new Vector3(287f,0.0f,0.0f),4).SetEase(Ease.InOutQuad).OnComplete( () => ShowZhuangTitle());
    }

    void ShowZhuangTitle()
    {
        zhuangTitleText.SetActive(true);
        Invoke("HideZhuangTitle", 1.0f);
    }
    void HideZhuangTitle()
    {
        zhuangTitleText.SetActive(false);
        Invoke("ShowZhuangLine", 1.0f);
    }

    void ShowZhuangLine()
    {
        zhuangLines.SetActive(true);
        audioController.GetComponent<AudioSource>().clip = audioController.GetComponent<AudioController>().audioClips[0];
        audioController.GetComponent<AudioSource>().Play();
        Invoke("HideZhuangLine", 2.0f);
    }

    void HideZhuangLine()
    {
        zhuangLines.SetActive(false);
        Invoke("ZoomOut",1.0f);
    }

    void ZoomOut()
    {
        transform.DOScale(new Vector3(0.5f,0.5f,0), 1.0f);
        transform.DOLocalMove(new Vector3(0.0f,0.0f,0), 1.0f);
        isOKToLead = true;
    }

    // 走到tree的位置是-470
    void ZeiJump()
    {
        audioController.GetComponent<AudioSource>().clip = audioController.GetComponent<AudioController>().audioClips[9];
        audioController.GetComponent<AudioSource>().volume = 1f;
        audioController.GetComponent<AudioSource>().Play();
        zei.transform.DOLocalJump(new Vector3(1000f, 0 , 0), 50.0f, 1, 0.2f, false).OnComplete(() => ZeiShowed());
    }

    void ZeiShowed()
    {
        Invoke("ZeiShout", 1.5f);
        zeiMobsNear.transform.DOLocalMove(new Vector3(-464.0f, 0, 0), 0.3f);
        zeiMobsFar.transform.DOLocalMove(new Vector3(-464.0f, 0, 0), 0.3f);
    }

    void ZeiShout()
    {
        zeiAnimator.Play("ZeiShout");
        zeiShoutLine.SetActive(true);
        audioController.GetComponent<AudioSource>().clip = audioController.GetComponent<AudioController>().audioClips[1];
        audioController.GetComponent<AudioSource>().Play();
        Invoke("ZhuangShrink",0.2f);
        Invoke("HideZeiShoutLine", 1.3f);
    }

    void ZhuangShrink()
    {
        float zx = zhuang.transform.localPosition.x;
        float zy = zhuang.transform.localPosition.y - 45.0f;
        zhuang.transform.DOLocalMove(new Vector3(zx, zy, 0), 1.5f);
        Invoke("XiZiShowUp", 1.1f);
    }
    void HideZeiShoutLine()
    {
        zeiShoutLine.SetActive(false);
    }

    void XiZiShowUp()
    {
        xiZi.SetActive(true);
        xiZi.transform.SetAsLastSibling();
        audioController.GetComponent<AudioSource>().clip = audioController.GetComponent<AudioController>().audioClips[2];
        audioController.GetComponent<AudioSource>().Play();
        isXiing = true;
    }

    void CaoMoXiGou()
    {
        // 需要声音演出，这里zeng的一身
        Invoke("XiZiShrink", 1);
    }

    void XiZiShrink()
    {
        xiZi.transform.DOScale(1.0f, 1.0f).OnComplete(() => XiZiHide());
        CaMoShout();
    }
    void XiZiHide()
    {
        xiZi.SetActive(false);
    }
    void CaMoShout()
    {
        caoMoHeadShoutAnimator.Play("CaoMoHeadShoutEnlarge");
        Invoke("ZeiMobFlyAway", 4.2f);
    }
    void ZeiMobFlyAway()
    {
        zeiMobsNear.transform.DOLocalMove(new Vector3(164.0f, 0, 0), 0.4f).OnComplete(() => ZeiMobGone());
        zeiMobsFar.transform.DOLocalMove(new Vector3(164.0f, 0, 0), 0.3f);
    }
    void ZeiMobGone()
    {
        zeiMobsNear.SetActive(false);
        zeiMobsFar.SetActive(false);
    }
    public void ZeiDoneShout()
    {
        Invoke("ZeiDropSword", 0.7f);
    }
    void ZeiDropSword()
    {
        Vector3 zeiSwordPos = zeiSword.transform.localPosition;
        zeiSwordPos.y -= 170.0f;
        //zeiSword.transform.SetParent(zeiBody.transform);
        zeiSword.transform.SetSiblingIndex(1);
        zeiSword.transform.DOLocalMove(zeiSwordPos, 0.2f, false).OnComplete(() => ZeiDropHead());
    }
    void ZeiDropHead()
    {
        zeiHead.GetComponent<Animator>().enabled = false;
        Vector3 zeiHeadPos = zeiHead.transform.localPosition;
        zeiHeadPos.y -= 210.0f;
        zeiHead.transform.DOLocalMove(zeiHeadPos, 0.4f, false).SetEase(Ease.InQuart).OnComplete(() => ZeiBodyFall());
        zeiHead.transform.DOLocalRotate(new Vector3(0, 0, 15.0f), 0.1f, RotateMode.Fast);
    }
    void ZeiBodyFall()
    {
        zeiBody.GetComponent<RectTransform>().pivot = new Vector2(0.5f, 0.12f);
        Vector3 zPos = zeiBody.transform.localPosition;
        zPos.y -= 71.0f;
        zeiBody.transform.localPosition = zPos;
        zeiBody.transform.DOLocalRotate(new Vector3(0, 0, 35.0f), 0.3f, RotateMode.Fast).SetEase(Ease.InQuart).OnComplete(() => ZeiBodyDead());
    }
    void ZeiBodyDead()
    {
        zeiBody.GetComponent<Image>().sprite = zeiBodyDeadSprite;
        zeiSword.GetComponent<Image>().sprite = swordBloodSprite;
        isOKToLeadAgain = true;
        Vector3 zhuangPos = zhuang.transform.localPosition;
        zhuangPos.y += 45.0f;
        zhuang.transform.DOLocalMove(zhuangPos, 1.0f);
    }
    void CatchUpZei()
    {
        //isOKToLeadAgain = false;
        zeiHead.transform.SetParent(trees.transform);
        zei.transform.SetParent(transform);
        zei.transform.localPosition = new Vector3(148.3f, 78f, 0f);
    }
    void ShowThrowButton()
    {
        dioZi.SetActive(true);
    }
    public void ThrowZeiBody()
    {
        dioSound.Play();
        dioZi.SetActive(false);
        zei.transform.SetParent(trees.transform);
        zei.transform.SetAsLastSibling();
        Vector3 zPos = zei.transform.localPosition;
        zPos.x -= 1800;
        zPos.y += 2000;
        zei.transform.DOLocalMove(zPos, 2);
        zei.transform.DOLocalRotate(new Vector3(0, 0, 15000), 20.0f, RotateMode.FastBeyond360);
        Invoke("ZhuangSayStop", 2.0f);
    }
    void ZhuangSayStop()
    {
        isOKToLeadAgain = false;
        zhuangLines.SetActive(true);
        zhuangLineText.text = " 等等";
        audioController.GetComponent<AudioSource>().clip = audioController.GetComponent<AudioController>().audioClips[8];
        audioController.GetComponent<AudioSource>().volume = 1f;
        audioController.GetComponent<AudioSource>().Play();
        Invoke("ZhuangJumpMaChe", 1.5f);
    }
    void ZhuangJumpMaChe()
    {
        zhuangLines.transform.SetParent(zhuang.transform);
        zhuangLines.SetActive(false);
        Vector3 zhuangPos = zhuang.transform.localPosition;
        zhuangPos.x += 450;
        zhuangPos.y -= 70;
        zhuang.transform.DOLocalJump(zhuangPos, 200, 2, 0.5f, false);
        Invoke("ZhuangAsk", 1.3f);
    }
    void ZhuangAsk()
    {
        zhuangLines.SetActive(true);
        zhuangLineText.text = "丢孤";
        audioController.GetComponent<AudioSource>().clip = audioController.GetComponent<AudioController>().audioClips[5];
        audioController.GetComponent<AudioSource>().Play();
        Invoke("CaoMoGet", 1.5f);
    }
    void CaoMoGet()
    {
        zhuangLines.SetActive(false);
        Invoke("CaoMoCarryZhuang", 0.5f);
    }
    void CaoMoCarryZhuang()
    {
        caoMoBody.GetComponent<Image>().sprite = caoMoBodyCarrySprite;
        Vector3 zPos = zhuang.transform.localPosition;
        zPos.y += 150;
        zhuang.transform.localPosition = zPos;
        Invoke("DioShowAgain", 1.0f);
    }
    void DioShowAgain()
    {
        dioZi.SetActive(true);
        Vector3 dioPos = dioZi.transform.localPosition;
        dioPos.x += 200;
        dioZi.transform.localPosition = dioPos;
        isDioZhuang = true;
    }
    public void ThrowZhuang()
    {
        dioSound.Play();
        dioZhuangNum++;
        Vector3 zPos = zhuang.transform.localPosition;
        if (dioZhuangNum > 4)
        {
            zPos.y = 5000;
            horse.GetComponent<Image>().sprite = horseBigEye;
            audioController.GetComponent<AudioSource>().clip = audioController.GetComponent<AudioController>().audioClips[7];
            audioController.GetComponent<AudioSource>().Play();
        }
        zhuang.transform.DOLocalJump(zPos, 100 * dioZhuangNum * dioZhuangNum, 1, 0.5f * dioZhuangNum, false).OnComplete(()=> ZhuangFlyDone());
        dioZi.SetActive(false);

    }
    void ZhuangFlyDone()
    {
        if(dioZhuangNum <= 4)
        {
            zhuangLines.SetActive(true);
            zhuangLineText.text = "再高";
            audioController.GetComponent<AudioSource>().clip = audioController.GetComponent<AudioController>().audioClips[6];
            audioController.GetComponent<AudioSource>().Play();
            Invoke("ZhuangAskHigherFin", 1.0f);
        }
        else
        {
            ZhuangFlyAway();
        }
    }
    void ZhuangAskHigherFin()
    {
        zhuangLines.SetActive(false);
        dioZi.SetActive(true);
    }
    void ZhuangFlyAway()
    {
        CaoMoScript003.SetActive(false);
        CaoMoScript004.SetActive(true);
        Invoke("FocusCaoMo", 2.5f);
    }
    void FocusCaoMo()
    {
        transform.DOScale(new Vector3(1f, 1f, 0), 1.0f).OnComplete(()=>CutToNextScene());
        horse.GetComponent<Image>().DOFade(0.0f, 0.5f);
        maCheImage.GetComponent<Image>().DOFade(0.0f, 0.5f);
    }
    void CutToNextScene()
    {
        SceneManager.LoadScene("104GeneralCao");
    }
}
