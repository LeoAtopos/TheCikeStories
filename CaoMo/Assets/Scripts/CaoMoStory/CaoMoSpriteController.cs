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

    public GameObject maChe;
    public GameObject zhuang;
    public GameObject zhuangTitleText;
    public GameObject zhuangLines;

    public GameObject trees;
    public GameObject zei;
    public Animator zeiAnimator;
    public GameObject zeiMobsNear;
    public GameObject zeiMobsFar;
    public GameObject zeiShoutLine;

    public GameObject xiZi;
    public float xiZiScale;
    public bool isXiing = false;

    public Animator caoMoHeadShoutAnimator;
    // Start is called before the first frame update
    void Start()
    {
        isOKToMove = false;
        isOKToLead = false;
        zhuangLines.SetActive(false);
        zeiShoutLine.SetActive(false);
        xiZi.SetActive(false);
        isXiing = false;
        xiZiScale = 1;
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
            xiZiScale += 0.5f * Time.deltaTime;
            xiZi.transform.DOScale( xiZiScale, 0);
            Color xiZiColor = xiZi.GetComponent<Image>().color;
            xiZiColor.a -= xiZiScale / 10000;
            Debug.Log(xiZiColor.a);
            xiZi.GetComponent<Image>().color = xiZiColor;
            if (xiZiScale > 15.5f)
            {
                isXiing = false;
                CaoMoXiGou();
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
    }
}
