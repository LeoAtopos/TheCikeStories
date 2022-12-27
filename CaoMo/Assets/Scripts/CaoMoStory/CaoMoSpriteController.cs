using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaoMoSpriteController : MonoBehaviour
{
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
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
    }
}
