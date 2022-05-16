using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGravityEfftectedObj
{
    public Vector2 GetGravityValue();
    public void SetGravityDirection(Vector2 gravityScale);
    public void DefaultGravity();
    public bool GetOnlyWater();
}

public class ObjByEffect : ObjByPlayer
{
    private Object obj;
}
