using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    private Vector2 gravityDirection;
    public Vector2 GravityDirection
    {
        get { return gravityDirection; }
        set
        {
            gravityDirection = UiManager.Instance.GetGravityValue();
            ApplyGravityToObj<ObjByEffect>();
        }
    }

    [HideInInspector] public float gravityX => Physics2D.gravity.x;
    public void ApplyGravityToObj<T>() where T : ObjByEffect
    {
        T[] obj = FindObjectsOfType<T>();
        IGravityEfftectedObj gravityEfftectedObj;
        for (int i = 0; i < obj.Length; i++)
        {
            gravityEfftectedObj = obj[i].GetComponent<IGravityEfftectedObj>();
            if (gravityEfftectedObj != null)
            {
                gravityEfftectedObj.SetGravityDirection(gravityDirection);
            }
        }
    }


}
