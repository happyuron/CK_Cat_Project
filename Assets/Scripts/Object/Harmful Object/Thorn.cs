using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thorn : TriggerObject
{
    private EveryObject target;
    protected override void OnCheckStart()
    {
        target = CheckObject<Player>();
        target = CheckObject<Pivot>() ?? target;
        if (target != null)
        {
            StartCoroutine(PlayerDead());
        }
    }

    private IEnumerator PlayerDead()
    {
        yield return new WaitForSeconds(1.0f);
        StageManager.Instance.LoadPlayerPos(target);
    }


}
