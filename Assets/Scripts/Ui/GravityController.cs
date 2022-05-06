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
        Debug.Log($"{index}번째의 위치 : " + pos);
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
        gravityDirection = gravityDirection.normalized;
        Debug.Log("중력 방향 세팅완료, 중력방향 : " + gravityDirection);
        GameManager.Instance.GravityDirection = gravityDirection;
        Debug.Log($"{gameObject.name}에서 GravityDirection 설정");
    }

    public Vector2 GetGravity()
    {
        Debug.Log($"{gameObject.name}의 중력의 방향 : " + gravityDirection);
        return gravityDirection;
    }
}
