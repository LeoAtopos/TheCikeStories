using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuGameController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadGameStartScene()
    {
        GameController.Instance.PlaySound("click");
        SceneManager.LoadScene("Start");
        GameController.Instance.isGaming = true;
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
