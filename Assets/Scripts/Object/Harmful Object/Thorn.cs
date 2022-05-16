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
            StartCoroutine(PlayerDead(player));
        }
    }

    private IEnumerator PlayerDead(Player player)
    {
        player.PlayerDead();
        yield return new WaitForSeconds(1.0f);
        player.PlayerRevive();
        StageManager.Instance.LoadPlayer(target);
        StopAllCoroutines();
    }


}
