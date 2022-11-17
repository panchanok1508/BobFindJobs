using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sound
{
    public class PoliceAnimationController : MonoBehaviour
    {
        public Animator policeAnim;

        public void policeNotice()
        {
            policeAnim.SetTrigger("PoliceNotice");
            Debug.Log("policenotice");
            SoundEffectManager.instace.Play(SoundEffectManager.SoundName.policewakeup);
        }


    }
}
