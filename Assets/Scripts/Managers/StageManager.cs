using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : Singleton<StageManager>
{
    public Transform StartPos { get; private set; }

    private Transform force;

    protected override void Awake()
    {
        base.Awake();

    }
}
