using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thorn : TriggerObject
{
    protected override void OnCheckStart()
    {
        if (CheckObject<Player, Pivot>())
        {
            StageManager.Instance.LoadPlayerPos(CheckObject<EveryObject>());
        }
    }


}
