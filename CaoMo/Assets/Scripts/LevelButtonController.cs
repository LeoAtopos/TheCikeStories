using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.Localization.Components;

public class LevelButtonController : MonoBehaviour
{
    public int level;
    public string levelSceneName;
    public string levelLine;

    public TextMeshProUGUI leveltext;
    public LocalizeStringEvent leveltextString;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetLevel(int ln, string ls, string ll)
    {
        level = ln;
        levelSceneName = ls;
        levelLine = ll;
        //leveltext.text = ll;
        leveltextString.SetEntry(ll);
    }

    public void LoadLevel()
    {
        Time.timeScale = 1f;
        GameController.Instance.isGaming = true;
        GameController.Instance.isPausing = false;
        SceneManager.LoadScene(levelSceneName);
    }
}
