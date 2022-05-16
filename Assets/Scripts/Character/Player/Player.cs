using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.Animation;
public class Player : Character
{

    private Pivot[] pivotList;

    private PlayerMove move;

    private Collider2D collision;

    public GameObject normal;
    public GameObject water;

    public Transform born { get; protected set; }

    [field: SerializeField] public float JumpPower { get; protected set; }
    [field: SerializeField] public float MoveSpeed { get; private set; }

    public float DirX { get; set; }
    public bool isChangedRight;
    public PlayerState CurState { get; protected set; }

    private bool isJumping => move.isJumping;

    private bool isMoving => move.isMoving;

    [SerializeField] public bool isAllowed => !isJumping && !isMoving;

    protected override void Awake()
    {
        base.Awake();
        move = GetComponent<PlayerMove>();
        collision = GetComponent<Collider2D>();
        pivotList = GetComponentsInChildren<Pivot>();
        born = GetComponentInChildren<SpriteSkin>().rootBone.transform;
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

    protected void ChangeToWater()
    {
        CurState = PlayerState.Water;
        MakeEnable(CurState);
        Rigid2D.gravityScale = 0;
        for (int i = 0; i < pivotList.Length; i++)
        {
            pivotList[i].SetUp();
            pivotList[i].GetComponent<Rigidbody2D>().velocity = Rigid2D.velocity;
        }
    }

    protected void ChangeToNormal()
    {
        CurState = PlayerState.Normal;
        DirX = born.GetComponent<Rigidbody2D>().velocity.x;
        Rigid2D.velocity = born.GetComponent<Rigidbody2D>().velocity;
        MakeEnable(CurState);
        GameManager.Instance.DefaultGravityToObj<ObjByPlayer>();
        Tr.position = born.transform.position;
        Rigid2D.gravityScale = 1;
        for (int i = 0; i < pivotList.Length; i++)
        {
            pivotList[i].ResetPos();
        }
    }


    private void MakeEnable(PlayerState state)
    {
        if (state == PlayerState.Normal)
        {
            normal.SetActive(true);
            water.SetActive(false);
            collision.enabled = true;
            isChangedRight = true;
        }
        else if (state == PlayerState.Water)
        {
            normal.SetActive(false);
            water.SetActive(true);
            collision.enabled = false;

        }
    }

    public bool IsNormalState()
    {
        return CurState == PlayerState.Normal ? true : false;

    }


}
