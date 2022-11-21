using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class CaoMoHeadNormalShowUp : MonoBehaviour, IPointerClickHandler
{
    public GameObject subText;
    bool isShowedUp = false;
    // Start is called before the first frame update
    void Start()
    {
        subText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HeadShowedUp()
    {
        subText.SetActive(true);
        isShowedUp = true;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(isShowedUp)
            SceneManager.LoadScene("102FindLuState");
    }
}
