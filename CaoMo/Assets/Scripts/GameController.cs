using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using TMPro;

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

    public AudioSource bgm;
    public AudioClip mainMenuBGM;
    public AudioClip plotBGM;
    public AudioClip warBGM;
    public AudioClip hijackBGM;
    public AudioSource sfx;
    public AudioClip clickSound;

    public GameObject introPanel;
    public GameObject moodPanel;

    public TextMeshProUGUI chineseLN;
    public TextMeshProUGUI englishLN;

    void Awake()
    {
        instance = this;
        DontDestroyOnLoad(this);
        QualitySettings.vSyncCount = 1;  // VSync must be disabled
        Application.targetFrameRate = 60;
    }
    // Start is called before the first frame update
    void Start()
    {
        if(LocalizationSettings.SelectedLocale == LocalizationSettings.AvailableLocales.Locales[0])
        {
            chineseLN.color = Color.black;
            englishLN.color = Color.grey;
        }
        else
        {
            chineseLN.color = Color.grey;
            englishLN.color = Color.black;
        }
        
        sfx.clip = clickSound;
        DOTween.KillAll();
        introPanel.SetActive(false);
        moodPanel.SetActive(false);
        if (GameObject.Find("EndTag") != null) moodPanel.SetActive(true);
        levelList = new List<GameObject>();
        SceneManager.activeSceneChanged += OnSceneChange;
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
        PlaySound("click");
        if (pausePanel != null)
            pausePanel.SetActive(false);
        isPausing = false;
        Time.timeScale = 1f;
    }

    public void PauseToMainmanu()
    {
        PlaySound("click");
        isGaming = false;
        isPausing = false;
        Time.timeScale = 1;
        SceneManager.MoveGameObjectToScene(this.gameObject, SceneManager.GetActiveScene());
        SceneManager.LoadScene("MainMenu");
    }

    public void NewLevelList(GameObject pausePanel)
    {
        GameObject content = pausePanel.GetComponent<PausePanel>().content;
        levelList.Add(NewLevel(1,"101ChooseHeadIcon", "caomozhe", content));
        levelList.Add(NewLevel(2,"102FindLuState", "luren", content));
        levelList.Add(NewLevel(3,"103BraveOne", "yiyong", content));
        levelList.Add(NewLevel(4, "104GeneralCao", "caomoweilujiang", content));
        levelList.Add(NewLevel(5, "105FightQi", "yuqi", content));
        levelList.Add(NewLevel(6, "106LoseLand", "zhuanggongju", content));
        levelList.Add(NewLevel(7, "107CutLand", "naixiansuiyi", content));
        levelList.Add(NewLevel(8, "108StillGeneral", "youfuyiweijiang", content));
        levelList.Add(NewLevel(9, "109MakeMeeting", "qihuangongxuyulu", content));
        levelList.Add(NewLevel(10, "110WalkUp", "huangongyuzhuanggong", content));
        levelList.Add(NewLevel(11, "111Hijack", "jieqihuangong", content));
        levelList.Add(NewLevel(12, "112End", "jinfuyulu", content));
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
        PlaySound("click");
        if (ChooseLevelPanel == null)
        {
            gamingCanvas = GameObject.Find("Canvas");
            ChooseLevelPanel = Instantiate(pausePanelPrefab, gamingCanvas.transform);
            NewLevelList(ChooseLevelPanel);
            ChooseLevelPanel.GetComponent<PausePanel>().continueButton.SetActive(false);
        }else
        {

        }
    }
    void OnSceneChange(Scene current, Scene next)
    {
        if (bgm != null)
        {
            if (next.name == "MainMenu")
            {
                bgm.clip = mainMenuBGM;
                bgm.volume = 1f;
                bgm.Play();
            }
            if (next.name == "Start")
            {
                bgm.Stop();
            }
            if (next.name == "101ChooseHeadIcon"
                || next.name == "101ChooseHeadIcon"
                || next.name == "102FindLuState"
                || next.name == "103BraveOne"
                || next.name == "104GeneralCao"
                || next.name == "106LoseLand"
                || next.name == "107CutLand"
                || next.name == "108StillGeneral"
                || next.name == "109MakeMeeting"
                || next.name == "110WalkUp"
                || next.name == "112End")
            {
                if(bgm.clip != plotBGM)
                {
                    bgm.clip = plotBGM;
                    bgm.volume = 0.2f;
                    bgm.Play();
                }
            }
            if(next.name == "105FightQi")
            {
                if (bgm.clip != warBGM)
                {
                    bgm.clip = warBGM;
                }
                bgm.volume = 0.1f;
                bgm.Play();
            }
            if (next.name == "111Hijack")
            {
                if (bgm.clip != hijackBGM)
                {
                    bgm.clip = hijackBGM;
                }
                bgm.volume = 0.5f;
                bgm.Play();
            }
            if (next.name == "Start02")
            {
                bgm.Stop();
            }
            if (next.name == "Future")
            {
                bgm.Stop();
            }
        }
    }
    public void ShowIntroPanel()
    {
        PlaySound("click");
        introPanel.SetActive(true);
    }
    public void PlaySound(string sn)
    {
        if(sn == "click")
        {
            sfx.clip = clickSound;
            sfx.Play();
        }
    }

    public void SetLanguage(string l)
    {
        if (l=="Chinese")
        {
            LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[0];
            chineseLN.color = Color.black;
            englishLN.color = Color.grey;
        }
            
        if (l == "English")
        {
            LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[1];
            chineseLN.color = Color.grey;
            englishLN.color = Color.black;
        }
            
    }
}
