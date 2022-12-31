using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

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
    // Start is called before the first frame update
    void Start()
    {
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
    }

    // Update is called once per frame
    void Update()
    {
        if(isOKToMove)
        {
            if(Input.GetMouseButton(0))
            {
                if(Input.mousePosition.x - transform.position.x < -5.0f)
                {
                    //left move
                    transform.position += new Vector3(-250 * Time.deltaTime, 0 , 0);
                    animator.Play("CaoMoMoving");
                }else if(Input.mousePosition.x - transform.position.x > 5.0f)
                {
                    //right move
                    transform.position += new Vector3( 250 * Time.deltaTime, 0 , 0);
                    animator.Play("CaoMoMoving");
                }
            }

            if(gameObject.GetComponent<RectTransform>().localPosition.x < -290.0f)
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
                if(Input.mousePosition.x > transform.position.x + 10.0f)
                {
                    animator.Play("CaoMoMoving");
                    horseAnimator.Play("HorseMoving");
                    trees.transform.position += new Vector3(-100 * Time.deltaTime,0,0);
                }
            }

            if(trees.transform.localPosition.x <= -470.0f)
            {
                isOKToLead = false;
                ZeiJump();
            }
        }

        if(isXiing)
        {
            xiZiScale += 0.2f * Time.deltaTime;
            xiZi.transform.DOScale( xiZiScale, 0);
            Color xiZiColor = xiZi.GetComponent<Image>().color;
            xiZiColor.a -= xiZiScale / 6000;
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
                    trees.transform.position += new Vector3(-100 * Time.deltaTime, 0, 0);
                }
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
        isXiing = true;
    }

    void CaoMoXiGou()
    {
        // 需要声音演出，这里zeng的一身
        Invoke("XiZiShrink", 2);
    }

    void XiZiShrink()
    {
        xiZi.transform.DOScale(1.0f, 1.5f).OnComplete(() => XiZiHide());
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
    }
}
