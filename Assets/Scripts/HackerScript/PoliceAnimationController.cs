using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceAnimationController : MonoBehaviour
{
    public Animator policeAnim;

    public void policeNotice()
    {
        policeAnim.SetTrigger("PoliceNotice");
        Debug.Log("policenotice");
    }

    
}
