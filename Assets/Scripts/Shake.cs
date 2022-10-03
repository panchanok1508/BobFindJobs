using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour
{
    public Animator bombAnim;
    

    public void BombShake()
    {
        bombAnim.SetTrigger("shake");
        Debug.Log("shaky");
    }

    
}
