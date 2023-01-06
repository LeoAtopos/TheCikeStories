using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaCheBing : MonoBehaviour
{
    public CaoMoToWar cmTW;
    public StillGeneralController sGC;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(cmTW != null)
        {
            if (cmTW.isOKTOCharge || cmTW.isCuttingScene)
            {
                animator.Play("HorseBingMoving", 0);
            }
        }
        if(sGC != null)
        {
            if(sGC.isOKToMove)
            {
                animator.Play("HorseBingMoving", 0);
            }
        }
    }
}
