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

    protected override void OnCheckStart()
    {
        GameManager.Instance.ClearGame(this);
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(offset + transform.position, size);
    }
}
