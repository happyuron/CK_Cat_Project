using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thorn : EveryObject
{
    private EveryObject target;

    private void OnCollisionEnter2D(Collision2D other)
    {
        target = other.gameObject.GetComponent<EveryObject>();
        if (target != null && StageManager.Instance.IsPlayer(target))
        {
            Player player = target.GetComponent<Player>() ?? target.GetComponentInParent<Player>();
            PlayerDead(player);
        }
    }

    private void PlayerDead(Player player)
    {
        player.PlayerDead();
    }


}
