using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PressForShow : MonoBehaviour
{
    public GameObject menu;
    public static bool GameIsPaused = false;


    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
               Resume();
            }
            else
            {        
                Pause();
            }
        }

      
    }

    public void Resume()
    {
        menu.SetActive(false);
        Time.timeScale = 1;
        GameIsPaused = false;
    }

    void Pause()
    {
        menu.SetActive(true);
        Time.timeScale = 0;
        GameIsPaused = true;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame()
    {
        Debug.Log(" Quit Game .......");
        Application.Quit();
    }
}
