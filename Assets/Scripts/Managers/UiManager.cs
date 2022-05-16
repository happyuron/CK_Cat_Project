using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class UiManager : Singleton<UiManager>
{
    public GravityController gravityController;
    public Vector2 GetMousePos()
    {
        Vector2 tmp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return tmp;
    }

    public void SetGravityValue(int index, Vector2 pos)
    {
        gravityController.SetGravity(index, pos);
    }

    public Vector2 GetGravityValue()
    {
        return gravityController.GetGravity();
    }

}