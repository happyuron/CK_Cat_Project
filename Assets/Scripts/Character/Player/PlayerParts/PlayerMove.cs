using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMove : PlayerParts<PlayerMove>
{
    private Vector2 dir;

    [field: SerializeField] public float MoveSpeed { get; private set; }

    private float jumpPower => player.JumpPower;

    public bool isJumping;
    public bool isMoving;
    public void MoveRight(Vector2 value)
    {

        if (player.IsNormalState())
        {
            isMoving = value.x != 0 ? true : false;
            dir = value;
        }
    }

    public void Jump()
    {
        if (player.IsNormalState() && !isJumping)
        {
            player.Rigid2D.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            isJumping = true;
        }
    }

    public void FallingCheck()
    {
        if (isJumping && player.Rigid2D.velocity.y == 0)
            isJumping = false;
    }

    private void LateUpdate()
    {
        Tr.Translate(dir * MoveSpeed * Time.deltaTime);
        FallingCheck();
    }

}
