using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaoMoHeadShout : MonoBehaviour
{
    public CaoMoSpriteController cmSC;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartShout()
    {
        cmSC.caoMoShoutLine.SetActive(true);
    }
    public void EndShout()
    {
        cmSC.caoMoShoutLine.SetActive(false);
    }
}
