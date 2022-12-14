using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseLuState : MonoBehaviour
{
    public GameObject chooseInUniverse;
    public GameObject chooseOnEarth;
    public GameObject chooseOnStateMap;
    public GameObject cmHead;
    
    // Start is called before the first frame update
    void Awake()
    {
        chooseOnEarth.SetActive(false);
        chooseOnStateMap.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChoosedEarth()
    {
        chooseInUniverse.GetComponent<Animator>().Play("FaintAway");
        chooseOnEarth.SetActive(true);
    }

    public void ChooseInUniverseFade()
    {
        chooseInUniverse.SetActive(false);
    }


    public void ChoosedStates()
    {
        chooseOnEarth.GetComponent<Animator>().Play("FaintAway");
        chooseOnStateMap.SetActive(true);
    }

    public void ChooseOnEarthFade()
    {
        chooseOnEarth.SetActive(false);
    }

    public void ChoosedLu()
    {
        chooseOnStateMap.GetComponent<Animator>().Play("ZoomUp");
        cmHead.GetComponent<CaoMoHeadNormalAsCursor>().MoveToCenter();
    }
}
