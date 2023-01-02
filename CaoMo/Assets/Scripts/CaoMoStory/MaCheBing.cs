using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaCheBing : MonoBehaviour
{
    public CaoMoToWar cmTW;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(animator.GetLayerName(0));
        Debug.Log(gameObject.name);
        if (cmTW.isOKTOCharge || cmTW.isCuttingScene)
        {
            animator.Play("HorseBingMoving", 0);
        }
    }
}
