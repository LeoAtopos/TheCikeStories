using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausePanel : MonoBehaviour
{
    public GameObject ToMainManuButton;
    public GameObject ContinueButton;

    void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ToMainManu()
    {
        GameController.Instance.PauseToMainmanu();
    }
    public void Continue()
    {
        GameController.Instance.ContinueGame();
    }
}
