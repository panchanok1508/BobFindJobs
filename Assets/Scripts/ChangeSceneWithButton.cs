using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneWithButton : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void MenuScene()
    {
        SceneManager.LoadScene("Menu");
    }

    public void SelectJobsScene()
    {
        SceneManager.LoadScene("SelectJobs");
    }

    public void QuitGame()
    {
        Debug.Log(" I'm OUT ");
        Application.Quit();
    }
}