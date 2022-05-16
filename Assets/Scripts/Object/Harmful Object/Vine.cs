using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vine : TriggerObject
{

    protected override void OnCheckStart(Collider2D collider)
    {
        Pivot tmp = collider.gameObject.GetComponent<Pivot>();
        if (tmp != null)
        {
            Debug.Log("Hit");
            GameManager.Instance.player.PlayerDead();
        }
    }


}
