using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : TriggerObject
{
    [field: SerializeField] public float WaitSecond { get; private set; }

    protected override void Awake()
    {
        base.Awake();
    }

    protected override void OnCheckStart(Collider2D collider)
    {
        GameManager.Instance.ClearGame(this);
    }

    protected override void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        base.OnDrawGizmos();
    }

}
