using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IGravityEfftectedObj
{
    public Vector2 GetGravityValue();

}

public class Character : MonoBehaviour
{
    public Rigidbody2D Rigid2D { get; protected set; }
    public Transform Tr { get; protected set; }

    protected virtual void Awake()
    {
        Rigid2D = GetComponent<Rigidbody2D>();
        Tr = GetComponent<Transform>();
    }

}
