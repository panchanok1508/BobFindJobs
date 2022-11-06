using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowObj : MonoBehaviour
{

    public GameObject next;
    public GameObject bob;
   

 

    public void ShowNextButton()
    {
        if (next != null)
        {
            bool isActive = next.activeSelf;

            next.SetActive(!isActive);
        }
        else
        {
            next.SetActive(false);
        }
    }

    public void HideImage()
    {

        if (bob == null)
        {
            bool isActive = bob.activeSelf;

            bob.SetActive(!isActive);
        }
    }


 

}
