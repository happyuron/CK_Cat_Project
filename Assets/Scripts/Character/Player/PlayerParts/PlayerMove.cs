using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMove : PlayerParts<PlayerMove>
{
    private Vector2 dir;

    private float jumpPower => player.JumpPower;

    private bool isJumping => player.IsJumping;
    public void MoveRight(InputAction.CallbackContext ctx)
    {
        if (player.IsNormalState())
        {
            dir = ctx.ReadValue<Vector2>();
        }
    }

    public void Jump(InputAction.CallbackContext ctx)
    {
        if (ctx.ReadValueAsButton() && player.IsNormalState() && !isJumping)
        {
            player.Rigid2D.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            player.IsJumping = true;
        }
    }
    public void FallingCheck()
    {
        if (isJumping && player.Rigid2D.velocity.y == 0)
            player.IsJumping = false;
    }

    private void LateUpdate()
    {
        Tr.Translate(dir * 10 * Time.deltaTime);
        FallingCheck();
    }

}
