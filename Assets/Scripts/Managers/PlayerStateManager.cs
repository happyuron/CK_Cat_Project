using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState
{
    Normal, Water
}

public class PlayerStateManager : Singleton<PlayerStateManager>
{
    public PlayerState ChangePlayerState(PlayerState state)
    {
        int nextIndex = (int)state + 1;
        PlayerState nextState = (PlayerState)nextIndex;
        if (nextIndex > 1)
        {
            nextState = 0;
            nextIndex = 0;
        }
        Debug.Log(nextIndex);
        return nextState;
    }
}
