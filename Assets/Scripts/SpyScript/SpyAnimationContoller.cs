using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpyAnimationContoller : MonoBehaviour
{
    public Animator spyAnim;

    public void spyMove()
    {
        spyAnim.SetTrigger("Move");
        Debug.Log("spymove");
    }

    public void spyGameOver()
    {
        spyAnim.SetTrigger("spyGameOver");
        Debug.Log("spygameover");
    }

    

}
