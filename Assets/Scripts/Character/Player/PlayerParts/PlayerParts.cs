using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParts<T> : CharacterParts<T> where T : CharacterParts<T>
{
    protected Player player;

    protected Animator anim;

    protected Animator eyeAnim;

    protected override void Awake()
    {
        base.Awake();
        player = GetComponent<Player>();
        anim = player.anim;
        eyeAnim = player.eyeAnim;
    }
}
