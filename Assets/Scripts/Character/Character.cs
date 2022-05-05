using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public Rigidbody2D Rigid2D { get; protected set; }
    public Transform Tr { get; protected set; }

    private void Awake()
    {
        Rigid2D = GetComponent<Rigidbody2D>();
        Tr = GetComponent<Transform>();
    }

}
