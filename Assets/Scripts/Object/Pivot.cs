using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pivot : ObjByPlayer
{
    private Vector2 defaultPosition;

    private Collider2D collder;

    private Quaternion dafalutAngle;
    protected override void Awake()
    {
        base.Awake();
        defaultPosition = Tr.localPosition;
        dafalutAngle = Tr.rotation;
        collder = GetComponent<Collider2D>();
    }

    public void ResetPos()
    {
        DefaultGravity();
        collder.enabled = false;
        Tr.localPosition = defaultPosition;
        Tr.rotation = dafalutAngle;
    }
    public void SetUp()
    {
        Rigid2D.velocity = new Vector2(0, 0);
        Tr.localPosition = defaultPosition;
        Tr.rotation = dafalutAngle;
        collder.enabled = true;
    }
}
