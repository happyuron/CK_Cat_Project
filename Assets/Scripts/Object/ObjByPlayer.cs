using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjByPlayer : EveryObject, IGravityEfftectedObj
{

    [field: SerializeField] public bool OnlyWater { get; protected set; }
    public Rigidbody2D Rigid2D { get; protected set; }

    public ConstantForce2D Force2D { get; protected set; }

    protected Vector2 gravityValue;
    private float gravity => GameManager.Instance.gravity;

    protected override void Awake()
    {
        base.Awake();
        Rigid2D = GetComponent<Rigidbody2D>();
        Force2D = GetComponent<ConstantForce2D>();
        if (Force2D == null)
        {
            Force2D = gameObject.AddComponent<ConstantForce2D>();
        }
    }

    public virtual Vector2 GetGravityValue()
    {
        return gravityValue;
    }
    public virtual void SetGravityDirection(Vector2 gravityScale)
    {
        gravityValue = new Vector2(gravityScale.x * 9.81f, gravityScale.y) * gravity;
        Force2D.force = new Vector2(gravityValue.x, 0);
        Rigid2D.gravityScale = gravityValue.y * -1;
    }
    public virtual void DefaultGravity()
    {
        Force2D.force = new Vector2(0, 0);
        Rigid2D.gravityScale = 1;
    }
    public virtual bool GetOnlyWater()
    {
        return OnlyWater;
    }
}
