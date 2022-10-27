using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorController : MonoBehaviour
{

    public static CursorController instance;

    public Texture2D selectCursor, defaultCursor;

    public void Awake()
    {
        instance = this;
    }
  

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActiveSelectCursor()
    {
        Cursor.SetCursor(selectCursor, Vector2.zero, CursorMode.Auto);
    }

    public void ActiveDefaultCursor()
    {
        Cursor.SetCursor(defaultCursor, Vector2.zero, CursorMode.Auto);
    }
}
