using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMove : MonoBehaviour
{
    private Rigidbody2D rigid;
    private Transform tr;
    private Vector2 dir;
    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        tr = GetComponent<Transform>();
    }
    public void MoveRight(InputAction.CallbackContext ctx)
    {
        dir = ctx.ReadValue<Vector2>();
    }

    private void LateUpdate()
    {
        tr.Translate(dir * 10 * Time.deltaTime);
    }

}
