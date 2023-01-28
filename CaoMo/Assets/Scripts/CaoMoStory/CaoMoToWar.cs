using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class CaoMoToWar : MonoBehaviour
{
    public GameObject caoMoHire;
    public GameObject caoMoHelmet;
    public GameObject caoMoBodyNormal;
    public GameObject caoMoBodyArmed;
    public GameObject maChe;

    public Animator horseAnimator;
    public bool isOKToMove = false;
    public GameObject trees;
    public GameObject maCheBingPos;

    public bool isOKTOCharge = false;
    public GameObject caoMoLine;
    public bool isChargeDone = false;
    public bool isCuttingScene = false;

    public GameObject dirCursor;
    public AudioSource horseStepSound;
    // Start is called before the first frame update
    void Start()
    {
        isOKToMove = false;
        isOKTOCharge = false;
        caoMoLine.SetActive(false);
        isChargeDone = false;
        isCuttingScene = false;
        dirCursor.SetActive(false);
        Invoke("NormalFitFlyAway", 1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if(isOKToMove)
        {
            if (Input.GetMouseButton(0))
            {
                if (Input.mousePosition.x > transform.position.x + 10.0f)
                {
                    horseAnimator.Play("HorseMoving");
                    if (!horseStepSound.isPlaying) horseStepSound.Play();
                    trees.transform.localPosition += new Vector3(-600 * Time.deltaTime, 0, 0);
                    dirCursor.SetActive(false);
                }
            }
            else
            {
                horseStepSound.Stop();
                if (Input.mousePosition.x > transform.position.x + 10.0f)
                {
                    dirCursor.GetComponent<RectTransform>().localScale = new Vector3(-1, 1, 1);
                    dirCursor.SetActive(true);
                }
                else
                {
                    dirCursor.SetActive(false);
                    Cursor.visible = true;
                }
            }
            if (trees.transform.localPosition.x <= -1400.0f)
            {
                horseStepSound.Stop();
                isOKToMove = false;
                maCheBingPos.transform.DOLocalMove(new Vector3(990f, 0, 0), 1f).OnComplete(() => MaCheBingGethered());
            }
        }
        if (isOKTOCharge)
        {
            if (!horseStepSound.isPlaying) horseStepSound.Play();
            horseAnimator.Play("HorseMoving");
            trees.transform.localPosition += new Vector3(-600 * Time.deltaTime, 0, 0);

            if (trees.transform.localPosition.x <= -3500.0f)
            {
                isChargeDone = true;
                isOKTOCharge = false;
            }
        }
        if(isChargeDone)
        {
            isCuttingScene = true;
            transform.DOLocalMove(new Vector3(-1000, 0, 0), 3).OnComplete(() => CutScene());
            isChargeDone = false;
        }
        if(isCuttingScene)
        {
            if (!horseStepSound.isPlaying) horseStepSound.Play();
            horseAnimator.Play("HorseMoving");
            trees.transform.localPosition += new Vector3(-600 * Time.deltaTime, 0, 0);
        }
    }
    void NormalFitFlyAway()
    {
        caoMoHire.transform.DOLocalMove(new Vector3(-0.5f, 1000f, 0), 1f);
        caoMoBodyNormal.transform.DOLocalMove(new Vector3(0f, -1000f, 0), 1f);
        Invoke("ArmFitFlyIn", 1f);
    }
    void ArmFitFlyIn()
    {
        caoMoHelmet.transform.DOLocalMove(new Vector3(-0.5f, 0.5f, 0), 0.5f);
        caoMoBodyArmed.transform.DOLocalMove(new Vector3(0f, -63.5f, 0), 0.5f);
        Invoke("MaCheFlyIn", 1f);
    }
    void MaCheFlyIn()
    {
        maChe.transform.DOLocalMove(new Vector3(129.9f, -87.6f, 0), 1f);
        maChe.transform.SetParent(transform);
        Invoke("ZoomOut", 2f);
    }
    void ZoomOut()
    {
        transform.DOScale(0.5f, 0.5f).OnComplete(() => OKToMove());
    }
    void OKToMove()
    {
        isOKToMove = true;
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
        SceneManager.LoadScene("105FightQi");
    }
}
