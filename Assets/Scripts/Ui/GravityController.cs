using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityController : MonoBehaviour
{
    private Vector2 firstPos;
    private Vector2 secondPos;

    private Vector2 gravityDirection;
    public void SetGravity(int index, Vector2 pos)
    {
        if (index == 0)
        {
            firstPos = pos;

        }
        else if (index == 1)
        {
            secondPos = pos;
            SetGravityDirection();
        }
    }

    private void SetGravityDirection()
    {
        gravityDirection = secondPos - firstPos;
        gravityDirection = gravityDirection.normalized * 9.81f;
    }

    public Vector2 GetGravity()
    {
        return gravityDirection;
    }
}
