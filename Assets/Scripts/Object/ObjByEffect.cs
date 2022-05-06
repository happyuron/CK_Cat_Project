using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGravityEfftectedObj
{
    public Vector2 GetGravityValue();
    public void SetGravityDirection(Vector2 gravityScale);
}

public class ObjByEffect : MonoBehaviour, IGravityEfftectedObj
{
    public Transform Tr { get; protected set; }

    public Rigidbody2D Rigid2D { get; protected set; }

    public ConstantForce2D Force2D { get; protected set; }

    private Vector2 gravityValue;

    protected virtual void Awake()
    {
        Tr = GetComponent<Transform>();
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
        gravityValue = new Vector2(gravityScale.x * 9.81f, gravityScale.y);
        Force2D.force = new Vector2(gravityValue.x, 0);
        Rigid2D.gravityScale = gravityValue.y * -1;
    }
    public virtual void DefaultGravity()
    {
        Force2D.force = new Vector2(0, 0);
        Rigid2D.gravityScale = 1;
    }
}
