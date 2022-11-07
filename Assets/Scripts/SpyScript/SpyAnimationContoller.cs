using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpyAnimationContoller : MonoBehaviour
{
    public Animator spyAnim;
    public bool isDone;

    public void spyMove()
    {
        spyAnim.SetTrigger("Move");
        isDone = true;
    }

    public void spyGameOver()
    {
        spyAnim.SetTrigger("spyGameOver");
        
    }

    

}
