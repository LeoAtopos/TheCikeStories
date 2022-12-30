using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CaoMoSpriteController : MonoBehaviour
{
    public Animator animator;
    public Animator horseAnimator;
    public bool isOKToMove = false;
    public bool isOKToLead = false;

    public GameObject maChe;
    public GameObject zhuangTitleText;
    public GameObject zhuangLines;

    public GameObject trees;
    public GameObject zei;
    public Animator zeiAnimator;
    // Start is called before the first frame update
    void Start()
    {
        isOKToMove = false;
        isOKToLead = false;
        zhuangLines.SetActive(false);
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
        Invoke("ZeiShout", 1.0f);
    }

    void ZeiShout()
    {
        zeiAnimator.Play("ZeiShout");
    }
}
