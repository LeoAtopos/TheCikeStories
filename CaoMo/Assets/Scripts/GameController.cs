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

    public List<GameObject> levelList;
    public GameObject LevelButtonPrefab;

    void Awake()
    {
        instance = this;
        DontDestroyOnLoad(this);
    }
    // Start is called before the first frame update
    void Start()
    {
        levelList = new List<GameObject>();
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
                    NewLevelList(pausePanel);
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
        if(pausePanel != null)
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

    public void NewLevelList(GameObject pausePanel)
    {
        GameObject content = pausePanel.GetComponent<PausePanel>().content;
        levelList.Add(NewLevel(1,"101ChooseHeadIcon","曹沫者", content));
        levelList.Add(NewLevel(2,"102FindLuState","曹沫者 鲁人也", content));
        levelList.Add(NewLevel(3,"103BraveOne","以勇力事鲁公", content));
    }

    GameObject NewLevel(int ln, string ls, string ll,GameObject content)
    {
        float offsetY = levelList.Count * 50f;
        
        GameObject g = Instantiate(LevelButtonPrefab, content.transform);
        g.GetComponent<LevelButtonController>().SetLevel(ln,ls,ll);
        return g;
    }
}
