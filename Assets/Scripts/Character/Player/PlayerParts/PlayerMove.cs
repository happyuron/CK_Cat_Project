using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMove : PlayerParts<PlayerMove>
{
    private Rigidbody2D rigid;
    private Vector2 dir;
    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        Tr = GetComponent<Transform>();
    }
    public void MoveRight(InputAction.CallbackContext ctx)
    {
        dir = ctx.ReadValue<Vector2>();
    }

    private void LateUpdate()
    {
        Tr.Translate(dir * 10 * Time.deltaTime);
    }

}
