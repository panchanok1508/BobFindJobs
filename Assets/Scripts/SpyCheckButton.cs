using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SpyCheckButton : MonoBehaviour
{

    [SerializeField] private Button spy = null;


    private void Awake()
    { 
    
        spy.onClick.AddListener(ParameterOnClick);
 
    }


    private void ParameterOnClick()
    {
 
        Debug.Log("Button Spy was pressed!");
    }

    public void SpyWasClicked(string sceneName)
    {
        if (spy == null)
        {
            Debug.Log(" It's doesn't work ");
        }
        else
        {
            Debug.Log(" Now is changing to spy scene  ");
            SceneManager.LoadScene(sceneName);

        }
    }
}