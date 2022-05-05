using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParts<T> : CharacterParts<T> where T : CharacterParts<T>
{
    Player player;

    protected override void Awake()
    {
        base.Awake();
        player = GetComponent<Player>();
    }
}
