using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.U2D.Animation;
public class Player : Character
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

    public void ChangeState(InputAction.CallbackContext ctx)
    {
        if (ctx.ReadValueAsButton())
        {
            CurState = PlayerStateManager.Instance.ChangePlayerState(CurState);
            if (CurState == PlayerState.Normal)
            {
                ChangeToNormal();
            }
            else
            {
                ChangeToWater();
            }
        }
    }

    public void ChangeToWater()
    {
        skin.enabled = true;
        collision.enabled = false;
        for (int i = 0; i < pivotList.Length; i++)
        {
            pivotList[i].gameObject.SetActive(true);
        }
    }

    public void ChangeToNormal()
    {
        Tr.position = skin.rootBone.transform.position;
        collision.enabled = true;
        skin.enabled = false;
        for (int i = 0; i < pivotList.Length; i++)
        {
            pivotList[i].gameObject.SetActive(false);
            pivotList[i].ResetPos();
        }
    }

    public bool IsNormalState()
    {
        if (CurState == PlayerState.Normal)
            return true;
        else
            return false;

    }


}
