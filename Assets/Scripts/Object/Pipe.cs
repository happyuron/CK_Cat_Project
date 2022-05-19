using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : TriggerObject
{

    [SerializeField] private Collider2D entrance;
    [SerializeField] private Collider2D exit;
    private Transform targetTr;

    private Player player;
    public float minDistance;

    private void Start()
    {
        player = GameManager.Instance.player;
        targetTr = GameManager.Instance.player.born.transform;
    }

    private bool CheckDistance()
    {
        if (Mathf.Abs(entrance.transform.position.x - targetTr.position.x) <= minDistance &&
            Mathf.Abs(entrance.transform.position.y - targetTr.position.y) <= minDistance)
        {
            return true;
        }

        return false;
    }


    private bool IsPivot()
    {
        if (targetTr.gameObject.layer == LayerMask.NameToLayer("Pivot"))
            return true;
        return false;
    }
    protected override void OnCheckStart(Collider2D tmp)
    {
        if (IsPivot())
        {
            player.ChangeState();
            player.Tr.position = exit.bounds.center;
            player.Rigid2D.velocity = Vector2.zero;
            player.ChangeState();
        }
        else
        {
            targetTr.position = exit.bounds.center;
        }
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }
}
