using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.Animation;
public class Player : Character
{
    private Pivot[] pivotList;

    private PlayerMove move;

    private Collider2D collision;

    public SpriteSkin Skin { get; protected set; }

    [field: SerializeField] public float JumpPower { get; private set; }

    public PlayerState CurState { get; private set; }

    private bool isJumping => move.isJumping;

    private bool isMoving => move.isMoving;

    [SerializeField] public bool isAllowed => !isJumping && !isMoving;

    protected override void Awake()
    {
        base.Awake();
        move = GetComponent<PlayerMove>();
        collision = GetComponent<Collider2D>();
        pivotList = GetComponentsInChildren<Pivot>();
        Skin = GetComponentInChildren<SpriteSkin>();
        CurState = PlayerState.Normal;
    }

    private void Start()
    {
        ChangeToNormal();
    }
    public void ChangeState()
    {
        if (CurState == PlayerState.Water && isAllowed)
        {
            ChangeToNormal();
        }
        else if (CurState == PlayerState.Normal && isAllowed)
        {
            ChangeToWater();
        }
    }

    public void ChangeToWater()
    {
        CurState = PlayerState.Water;
        Skin.enabled = true;
        collision.enabled = false;
        Rigid2D.gravityScale = 0;
        for (int i = 0; i < pivotList.Length; i++)
        {
            pivotList[i].SetUp();
        }
    }

    public void ChangeToNormal()
    {
        CurState = PlayerState.Normal;
        Tr.position = Skin.rootBone.transform.position;
        collision.enabled = true;
        Skin.enabled = false;
        Rigid2D.gravityScale = 1;
        for (int i = 0; i < pivotList.Length; i++)
        {
            pivotList[i].ResetPos();
        }
    }

    public bool IsNormalState()
    {
        return CurState == PlayerState.Normal ? true : false;

    }


}
