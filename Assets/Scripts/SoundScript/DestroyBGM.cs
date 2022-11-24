using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBGM : MonoBehaviour
{
    public void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}
