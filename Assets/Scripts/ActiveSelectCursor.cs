using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveSelectCursor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void OnMouseEnter()
    {
        CursorController.instance.ActiveSelectCursor();
    }


    public void OnMouseExit()
    {
        CursorController.instance.ActiveDefaultCursor();
    }

}
