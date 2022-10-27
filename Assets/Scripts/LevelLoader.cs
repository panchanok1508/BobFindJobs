using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class LevelLoader : MonoBehaviour
{
    public GameObject loadingScreen;
    public Slider slider;

    public void LoadLevel (int sceneIndex)

    {

        StartCoroutine(LoadAsynchronously(sceneIndex));

        Debug.Log("Change");


    }
        
    IEnumerator LoadAsynchronously (int sceneIndex)
    {

        slider.value = 0;
        loadingScreen.SetActive(true);

        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        operation.allowSceneActivation = false;
        float progress = 0;


        while (!operation.isDone)
        {
            progress = Mathf.MoveTowards(progress, operation.progress, Time.deltaTime);
            slider.value = progress;
            if(progress >= 0.9f)
            {
                slider.value = 1;

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    operation.allowSceneActivation = true;
                    Debug.Log(progress);
                }
       
            }


            yield return progress ;
            Debug.Log("GOOD");


        }



    }
}
