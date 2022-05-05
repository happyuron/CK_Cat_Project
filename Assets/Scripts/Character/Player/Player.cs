using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class Player : Character
{
    PlayerState curState;

    protected override void Awake()
    {
        base.Awake();
        curState = PlayerState.Normal;
    }


    public void ChangeState(InputAction.CallbackContext ctx)
    {
        PlayerStateManager.Instance.ChangePlayerState(curState);
    }


}
