using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.Animation;
public class Player : Character
{
    #region 변수들
    private Pivot[] pivotList;

    private PlayerMove move;

    private Collider2D collision;

    public GameObject normal;
    public GameObject water;

    public Transform born { get; protected set; }

    [field: SerializeField] public float JumpPower { get; protected set; }
    [field: SerializeField] public float MoveSpeed { get; private set; }
    [SerializeField] public bool isAllowed => !isJumping && !isMoving;
    public PlayerState CurState { get; set; }

    public string eyeAnimValueName = "PlayerWater";
    public string animValueName = "Player";

    public Animator eyeAnim;

    public float DirX { get; set; }
    public bool isChangedRight;

    private bool isJumping => move.isJumping;

    private bool isMoving => move.isMoving;

    #endregion
    protected override void Awake()
    {
        base.Awake();
        move = GetComponent<PlayerMove>();
        collision = GetComponent<Collider2D>();
        pivotList = GetComponentsInChildren<Pivot>();
        born = GetComponentInChildren<SpriteSkin>().rootBone.transform;
        CurState = PlayerState.Idle;
    }

    private void Start()
    {
        GameManager.Instance.player = this;
        ChangeToNormal();
    }
    public void ChangeState()
    {
        if (CurState == PlayerState.Water && isAllowed)
        {
            ChangeToNormal();
        }
        else if (IsNormalState() && isAllowed)
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
        GameManager.Instance.DefaultGravityToObj<ObjByPlayer>();
        CurState = PlayerState.Idle;
        DirX = born.GetComponent<Rigidbody2D>().velocity.x;
        Rigid2D.velocity = born.GetComponent<Rigidbody2D>().velocity;
        MakeEnable(CurState);
        Tr.position = born.transform.position;
    }

    public void PlayerDead()
    {
        if (CurState != PlayerState.Dead)
        {
            if (!IsNormalState())
                AnimationController.SetIntegerAnimation(eyeAnim, eyeAnimValueName, (int)PlayerState.Dead);
            else
                AnimationController.SetIntegerAnimation(anim, animValueName, (int)PlayerState.Dead);
            SoundManager.Instance.PlaySoundShot("CatDeadSound");

            CurState = PlayerState.Dead;
            IsDead = true;
            DirX = 0;
        }
    }
    public void PlayerRevive()
    {
        GameManager.Instance.DefaultGravityToObj<ObjByPlayer>();
        CurState = PlayerState.Idle;
        MakeEnable(CurState);
        IsDead = false;
        StageManager.Instance.LoadPlayer(this);
        AnimationController.SetIntegerAnimation(anim, animValueName, (int)PlayerState.Idle);
    }

    private void MakeEnable(PlayerState state)
    {
        if (IsNormalState())
        {
            normal.SetActive(true);
            water.SetActive(false);
            collision.enabled = true;
            isChangedRight = true;
            Rigid2D.gravityScale = 1;

        }
        else if (state == PlayerState.Water)
        {
            normal.SetActive(false);
            water.SetActive(true);
            collision.enabled = false;
            Rigid2D.gravityScale = 0;

        }
    }

    public bool IsNormalState()
    {
        return CurState == PlayerState.Idle || CurState == PlayerState.Walk || CurState == PlayerState.Jump ? true : false;

    }


}
