using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class XiZiHandle : MonoBehaviour ,IPointerClickHandler
{
    public CaoMoSpriteController cmSC;
    public void OnPointerClick(PointerEventData eventData)
    {
        if(cmSC.isXiing)
        {
            cmSC.audioController.GetComponent<AudioSource>().clip = cmSC.audioController.GetComponent<AudioController>().audioClips[3];
            cmSC.audioController.GetComponent<AudioSource>().Play();
            cmSC.xiZiScale += 1.5f;
        }   
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
