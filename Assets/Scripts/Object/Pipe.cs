using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : EveryObject
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
    private bool IsPlayer()
    {
        if (targetTr.gameObject.layer == LayerMask.NameToLayer("Pivot"))
            return true;
        return false;
    }


    private void FixedUpdate()
    {
        if (CheckDistance() && IsPlayer())
        {
            player.ChangeState();
            player.Tr.position = exit.transform.position;
            player.ChangeState();
        }
        else if (CheckDistance())
        {
            targetTr.position = exit.transform.position;
        }
    }


}
