using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sound
{
    public class LockpickAnimationController : MonoBehaviour
    {
        public Animator lockpickAnim;

        public void lockpickMove()
        {
            lockpickAnim.SetTrigger("LockpickMove");
            Debug.Log("lockpickmove");
        }

        public void lockpickBroke()
        {
            lockpickAnim.SetTrigger("LockpickBroke");
            Debug.Log("lockpickbroke");
        }


    }
}
