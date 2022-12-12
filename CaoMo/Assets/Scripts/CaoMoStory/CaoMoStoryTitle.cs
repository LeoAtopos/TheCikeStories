using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CaoMoStoryTitle : MonoBehaviour
{
    public AudioSource openSound;
    public GameObject tapToGo;

    bool isShowFinished = false;
    // Start is called before the first frame update
    void Start()
    {
        tapToGo.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(isShowFinished)
        {
            if(Input.GetMouseButton(0))// && !GameController.Instance.pausePanel.activeSelf
            {
                SceneManager.LoadScene("101ChooseHeadIcon");
            }
        }
        
    }

    public void PlayOpenSound()
    {
        openSound.Play();
    }

    public void ShowFinished()
    {
        tapToGo.SetActive(true);
        isShowFinished = true;
    }
}
