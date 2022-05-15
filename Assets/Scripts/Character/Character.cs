using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CharacterAnim
{
    Idle, Move, Jump, Dead
}

public class Character : EveryObject
{
    public Rigidbody2D Rigid2D { get; protected set; }
    protected Animator anim;

    public bool IsDead
    {
        get { return IsDead; }
        set
        {
            IsDead = value;
            // if (anim != null)
            //     anim.SetInteger("", (int)CharacterAnim.Dead);
        }
    }
    protected override void Awake()
    {
        base.Awake();
        Rigid2D = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
    }
}
