using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowObj : MonoBehaviour
{
    public GameObject Next;
    public GameObject bob;

    public void ShowNextButton()
    {
        if (Next != null)
        {
            bool isActive = Next.activeSelf;

            Next.SetActive(!isActive);
        }
        else
        {
            Next.SetActive(false);     
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
