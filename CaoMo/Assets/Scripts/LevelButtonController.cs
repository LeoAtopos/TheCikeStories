using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelButtonController : MonoBehaviour
{
    public int level;
    public string levelSceneName;
    public string levelLine;

    public Text leveltext;
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
        leveltext.text = ll;
    }

    public void LoadLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(levelSceneName);
    }
}
