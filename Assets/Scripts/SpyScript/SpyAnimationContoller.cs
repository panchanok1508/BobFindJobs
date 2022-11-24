using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sound
{
    public class SpyAnimationContoller : MonoBehaviour
    {
        public Animator spyAnim;

        public void spyMove()
        {
            spyAnim.SetTrigger("Move");
            SoundEffectManager.instace.Play(SoundEffectManager.SoundName.spyAnimation);
        }

        public void spyGameOver()
        {
            spyAnim.SetTrigger("spyGameOver");

        }



    }
}
