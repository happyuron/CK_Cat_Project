using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : TriggerObject
{
    [field: SerializeField] public float WaitSecond { get; private set; }

    public bool upDownMove;
    public float velocity;
    protected float curVelocity;

    private SpriteRenderer spriteRenderer;

    protected float up;
    protected float down;


    protected override void Awake()
    {
        base.Awake();
        spriteRenderer = GetComponent<SpriteRenderer>();
        up = Tr.position.y + 0.2f;
        down = Tr.position.y - 0.2f;
        curVelocity = velocity;
    }

    protected virtual void GameClear()
    {
        if (!GameManager.Instance.gameClear)
        {
            spriteRenderer.enabled = false;
            SoundManager.Instance.PlaySoundShot("GameClear");
        }
    }

    protected override void OnCheckStart(Collider2D collider)
    {
        if (GameManager.Instance.player.CurState != PlayerState.Dead)
        {
            GameClear();
            GameManager.Instance.ClearGame(this);
        }
    }
    protected void Move()
    {
        if (CheckDistance())
            curVelocity += Time.deltaTime;

    }

    protected bool CheckDistance()
    {
        if (Tr.position.y <= up || Tr.position.y >= down)
        {
            curVelocity *= -1;
            return true;
        }

        return false;
    }



    protected override void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        base.OnDrawGizmos();
    }

}
