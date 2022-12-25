using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickAndToss : MonoBehaviour
{
    public GameObject notionWords;

    void Awake()
    {
        notionWords.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Toss()
    {
        notionWords.SetActive(true);
        notionWords.GetComponent<WordsToss>().Toss();
    }
}
