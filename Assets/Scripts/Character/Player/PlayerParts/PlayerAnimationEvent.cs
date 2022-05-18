using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationEvent : PlayerParts<PlayerAnimationEvent>
{
    protected override void Awake()
    {
        player = GetComponentInParent<Player>();
        anim = player.anim;
        eyeAnim = player.eyeAnim;
    }
    public void Revive()
    {
        player.PlayerRevive();
    }

    public void PlaySound(string name)
    {
        SoundManager.Instance.PlaySoundShot(name);
    }
}
