using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HackerCheckButton : MonoBehaviour
{

    [SerializeField] private Button hacker = null;


    private void Awake()
    {

        hacker.onClick.AddListener(ParameterOnClick);

    }


    private void ParameterOnClick()
    {

        Debug.Log("Button Hacker was pressed!");
    }

    public void HackerWasClicked(string sceneName)
    {
        if (hacker == null)
        {
            Debug.Log(" It's doesn't work ");
        }
        else
        {
            Debug.Log(" Now is changing to hacker scene  ");
            SceneManager.LoadScene(sceneName);

        }
    }
}