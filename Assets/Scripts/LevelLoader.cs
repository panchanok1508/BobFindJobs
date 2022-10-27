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
            //progress = Mathf.MoveTowards(progress, operation.progress, Time.deltaTime);
            progress = Mathf.Clamp01(operation.progress / .9f);

            slider.value = progress;
            //Debug.Log("Progress 1 : "+progress);

            if (progress >= 0.9f)
            {
                slider.value = 1;

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    operation.allowSceneActivation = true;
                    //Debug.Log("Progress 2 : "+progress);
                }

            }


            yield return progress ;

        }

     

    }
}
