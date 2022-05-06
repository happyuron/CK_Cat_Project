using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.U2D.Animation;
public class Player : Character, IGravityEfftectedObj
{
    private Pivot[] pivotList;

    private Collider2D collision;

    private SpriteSkin skin;

    [field: SerializeField] public float JumpPower { get; private set; }

    public PlayerState CurState { get; private set; }

    public bool IsJumping { get; set; }


    public IReadOnlyCollection<Pivot> PivotList => pivotList;
    protected override void Awake()
    {
        base.Awake();
        collision = GetComponent<Collider2D>();
        pivotList = GetComponentsInChildren<Pivot>();
        skin = GetComponentInChildren<SpriteSkin>();
        CurState = PlayerState.Normal;
    }

    private void Start()
    {
        ChangeToNormal();
    }

    public Vector2 GetGravityValue()
    {

        return new Vector2(0, 0);
    }

    public void ChangeState()
    {
        if (CurState == PlayerState.Water)
        {
            ChangeToNormal();
        }
        else
        {
            ChangeToWater();
        }
    }

    public void ChangeToWater()
    {
        CurState = PlayerStateManager.Instance.ChangePlayerState(CurState);
        skin.enabled = true;
        collision.enabled = false;
        Rigid2D.gravityScale = 0;
        for (int i = 0; i < pivotList.Length; i++)
        {
            pivotList[i].SetUp();
        }
    }

    public void ChangeToNormal()
    {
        CurState = PlayerStateManager.Instance.ChangePlayerState(CurState);
        Tr.position = skin.rootBone.transform.position;
        collision.enabled = true;
        skin.enabled = false;
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
