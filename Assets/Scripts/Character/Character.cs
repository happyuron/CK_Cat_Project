using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Character : EveryObject
{
    public Rigidbody2D Rigid2D { get; protected set; }

    protected override void Awake()
    {
        base.Awake();
        Rigid2D = GetComponent<Rigidbody2D>();
    }
}
