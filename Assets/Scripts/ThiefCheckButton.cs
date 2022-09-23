using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ThiefCheckButton : MonoBehaviour
{

    [SerializeField] private Button thief = null;


    private void Awake()
    { 
    
        thief.onClick.AddListener(ParameterOnClick);
 
    }


    private void ParameterOnClick()
    {
 
        Debug.Log("Button Thief was pressed!");
    }

    public void ThiefWasClicked(string sceneName)
    {
        if (thief == null)
        {
            Debug.Log(" It's doesn't work ");
        }
        else
        {
            Debug.Log(" Now is changing to scene  ");
            SceneManager.LoadScene(sceneName);

        }
    }
}