using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowObj : MonoBehaviour
{
    public GameObject Next;

    public void ShowNextButton()
    {
        if (Next != null)
        {
            bool isActive = Next.activeSelf;

            Next.SetActive(!isActive);
        }
    }
}
