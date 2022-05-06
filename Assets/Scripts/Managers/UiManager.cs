using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class UiManager : Singleton<UiManager>
{
    public Image gravityController;
    public Vector2 GetMousePos()
    {
        Vector2 tmp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return tmp;
    }

    
}