using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerMove : PlayerParts<PlayerMove>
{

    private Rigidbody2D Rigid2D => player.Rigid2D;
    private float jumpPower => player.JumpPower;
    private float dirX => player.DirX;
    private SpriteRenderer spriteRenderer;
    private float moveSpeed => player.MoveSpeed;
    [SerializeField] private LayerMask hitLayer;
    [SerializeField] private Vector3 offset;
    [SerializeField] private Vector3 size;


    public bool isJumping;
    public bool isMoving;

    protected override void Awake()
    {
        base.Awake();
        spriteRenderer = player.normal.GetComponent<SpriteRenderer>();
    }
    public void MoveRight(Vector2 value)
    {

        if (player.IsNormalState())
        {
            isMoving = value.x != 0 ? true : false;
            if (isMoving && !isJumping)
                AnimationController.SetIntegerAnimation(anim, player.animValueName, (int)PlayerState.Walk);
            else if (!isMoving && !isJumping)
                AnimationController.SetIntegerAnimation(anim, player.animValueName, (int)PlayerState.Idle);


            player.DirX = value.x * moveSpeed;
            if (dirX > 0)
                spriteRenderer.flipX = false;
            else if (dirX < 0)
                spriteRenderer.flipX = true;

        }
    }

    public void Jump()
    {
        if (player.IsNormalState() && !isJumping)
        {
            AnimationController.SetIntegerAnimation(player.anim, player.animValueName, (int)PlayerState.Jump);
            SoundManager.Instance.PlaySoundShot("JumpSound");
            Rigid2D.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            isJumping = true;
        }
    }

    public void FallingCheck()
    {
        if (player.Rigid2D.velocity.y <= 0 && GroundCheck())
        {
            if (isJumping)
            {
                isJumping = false;
                AnimationController.SetIntegerAnimation(player.anim, player.animValueName, (int)PlayerState.Idle);
            }
            if (!isMoving && player.isChangedRight)
            {
                player.isChangedRight = false;
                player.DirX = 0;
            }
            else if (isMoving && player.isChangedRight)
                player.isChangedRight = false;
        }
    }

    public virtual bool GroundCheck()
    {
        Collider2D tmp = Physics2D.OverlapBox(Tr.position + offset, size, 0, hitLayer);
        return tmp;
    }
    private void LateUpdate()
    {
        FallingCheck();
        Rigid2D.velocity = new Vector2(dirX, Rigid2D.velocity.y);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position + offset, size);
    }
}
