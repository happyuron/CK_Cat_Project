using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPosition : TriggerObject
{
    [SerializeField] private Transform startPos;

    protected override void Awake()
    {
        base.Awake();
        if (startPos == null)
            startPos = GetComponentInChildren<Transform>();
    }

    protected override void OnCheckStart(Collider2D collider)
    {
        StageManager.Instance.SavePos(startPos);
    }

    protected override void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        base.OnDrawGizmos();

    }
}
