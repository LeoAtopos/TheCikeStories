using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordsToss : MonoBehaviour
{
    public float tossTimeSet = 0;
    float tossTime = 4f;

    void Awake()
    {
        if(tossTimeSet == 0)
        {
            tossTime = 4f;
        }
        else
        {
            tossTime = tossTimeSet;
        }
    }

    void HideSelf()
    {
        this.gameObject.SetActive(false);
    }

    public void Toss()
    {
        CancelInvoke();
        Invoke("HideSelf", tossTime);
    }
}
