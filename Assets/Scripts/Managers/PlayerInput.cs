using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerInput : Singleton<PlayerInput>
{
    public InputAction Action { get; private set; }
    protected override void Awake()
    {
        base.Awake();
        Action = GetComponent<InputAction>();
    }



}
