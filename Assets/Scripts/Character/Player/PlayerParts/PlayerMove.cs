using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMove : PlayerParts<PlayerMove>
{
    private Vector2 dir;

    public void MoveRight(InputAction.CallbackContext ctx)
    {
        dir = ctx.ReadValue<Vector2>();
    }

    private void LateUpdate()
    {
        Tr.Translate(dir * 10 * Time.deltaTime);
    }

}
