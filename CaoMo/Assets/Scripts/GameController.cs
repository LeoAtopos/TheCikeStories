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
        levelList.Add(NewLevel(1,"101ChooseHeadIcon","曹沫者", content));
        levelList.Add(NewLevel(2,"102FindLuState","鲁人也", content));
        levelList.Add(NewLevel(3,"103BraveOne","以勇力事鲁公 庄公好力", content));
        levelList.Add(NewLevel(4, "104GeneralCao", "曹沫为鲁将", content));
        levelList.Add(NewLevel(5, "105FightQi", "与齐战", content));
        levelList.Add(NewLevel(6, "106LoseLand", "鲁庄公惧", content));
        levelList.Add(NewLevel(7, "107CutLand", "乃献遂邑之地以和", content));
        levelList.Add(NewLevel(8, "108StillGeneral", "犹复以为将", content));
        levelList.Add(NewLevel(9, "109MakeMeeting", "齐桓公许与鲁会于柯而盟", content));
        levelList.Add(NewLevel(10, "110WalkUp", "桓公与庄公既盟于坛上", content));
        levelList.Add(NewLevel(11, "111Hijack", "曹沫执匕首劫齐桓公...", content));
        levelList.Add(NewLevel(12, "112End", "曹沫三战所亡地尽复予鲁...", content));
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
