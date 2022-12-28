using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CaoMoSpriteController : MonoBehaviour
{
    public Animator animator;
    public bool isOKToMove = false;

    public GameObject maChe;
    public GameObject zhuangTitleText;
    public GameObject zhuangLines;
    // Start is called before the first frame update
    void Start()
    {
        isOKToMove = false;
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

            if(transform.position.x < 300.0f)
            {
                isOKToMove = false;
                maChe.transform.SetParent(transform);
                PlayInToStep2();
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
    }
}
