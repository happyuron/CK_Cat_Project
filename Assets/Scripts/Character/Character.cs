using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public static class AnimationController
{
    public static void SetIntegerAnimation(Animator anim, string name, int index)
    {
        anim.SetInteger(name, index);
    }
}

public enum CharacterAnim
{
    Idle, Move, Jump, Dead
}

public class Character : EveryObject
{
    public Rigidbody2D Rigid2D { get; protected set; }
    protected Animator anim;

    private bool isDead;

    public bool IsDead
    {
        get { return isDead; }
        set
        {
            isDead = value;
            // if (anim != null)
            //     anim.SetInteger("", (int)CharacterAnim.Dead);
        }
    }
    protected override void Awake()
    {
        base.Awake();
        Rigid2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
}
