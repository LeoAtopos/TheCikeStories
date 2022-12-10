using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    private static GameController instance;
    public static GameController Instance
    {
        get => instance;
    }

    public bool isGaming = false;
    public GameObject gamingCanvas;
    public GameObject pausePanelPrefab;
    public GameObject pausePanel;
    public bool isPausing = false;

    void Awake()
    {
        instance = this;
        DontDestroyOnLoad(this);
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(isGaming && !isPausing)
            {
                if(pausePanel == null)
                {
                    gamingCanvas = GameObject.Find("Canvas");
                    pausePanel = Instantiate(pausePanelPrefab,gamingCanvas.transform);
                }
                else
                {
                    pausePanel.SetActive(true);
                }
                isPausing = true;
                Time.timeScale = 0;
            }else
            {
                if (isPausing)
                {
                    ContinueGame();
                }
            }
        }
    }

    public void ContinueGame()
    {
        pausePanel.SetActive(false);
        isPausing = false;
        Time.timeScale = 1f;
    }

    public void PauseToMainmanu()
    {
        isGaming = false;
        isPausing = false;
        Time.timeScale = 1;
        SceneManager.MoveGameObjectToScene(this.gameObject, SceneManager.GetActiveScene());
        SceneManager.LoadScene("MainMenu");
    }
}
