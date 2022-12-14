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

    public GameObject ChooseLevelPanel;

    void Awake()
    {
        instance = this;
        DontDestroyOnLoad(this);
        QualitySettings.vSyncCount = 0;  // VSync must be disabled
        Application.targetFrameRate = 60;
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
        levelList.Add(NewLevel(1,"101ChooseHeadIcon","?????????", content));
        levelList.Add(NewLevel(2,"102FindLuState","?????????", content));
        levelList.Add(NewLevel(3,"103BraveOne","?????????????????? ????????????", content));
        levelList.Add(NewLevel(4, "104GeneralCao", "???????????????", content));
        levelList.Add(NewLevel(5, "105FightQi", "?????????", content));
        levelList.Add(NewLevel(6, "106LoseLand", "????????????", content));
        levelList.Add(NewLevel(7, "107CutLand", "????????????????????????", content));
        levelList.Add(NewLevel(8, "108StillGeneral", "???????????????", content));
        levelList.Add(NewLevel(9, "109MakeMeeting", "?????????????????????????????????", content));
    }

    GameObject NewLevel(int ln, string ls, string ll,GameObject content)
    {
        float offsetY = levelList.Count * 50f;
        
        GameObject g = Instantiate(LevelButtonPrefab, content.transform);
        g.GetComponent<LevelButtonController>().SetLevel(ln,ls,ll);
        return g;
    }

    public void ShowChooseLevelPanel()
    {
        if(ChooseLevelPanel == null)
        {
            gamingCanvas = GameObject.Find("Canvas");
            ChooseLevelPanel = Instantiate(pausePanelPrefab, gamingCanvas.transform);
            NewLevelList(ChooseLevelPanel);
            ChooseLevelPanel.GetComponent<PausePanel>().continueButton.SetActive(false);
        }else
        {

        }
    }
}
