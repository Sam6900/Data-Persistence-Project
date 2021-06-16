using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

#if UNITY_EDITOR
using UnityEditor;
#endif

[DefaultExecutionOrder(500)]
public class MenuUiHandler : MonoBehaviour
{
    public Text bestScoreShowText;

    private void Start()
    {
        LoadBestScore();
    }

    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }

    public void NewNameSelected(Text name)
    {
        GameManager.Instance.PlayerName = name.text;
    }

    public void LoadBestScore()
    {
        bestScoreShowText.text = "Best Score:"+ GameManager.Instance.PlayerName + " : " + GameManager.Instance.PlayerScore;
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
