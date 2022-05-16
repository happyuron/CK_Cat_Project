using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : Singleton<StageManager>
{
    public Vector2 StartPos { get; private set; }

    public StartPosition[] SavePoint { get; private set; }



    public void SavePos(Transform tr)
    {
        StartPos = tr.position;
    }

    public void LoadPos(EveryObject obj)
    {
        if (obj != null)
        {
            obj.Tr.position = StartPos;
        }
    }
    public void LoadPlayerPos(EveryObject obj)
    {
        Player player = obj.GetComponent<Player>() ?? obj.GetComponentInParent<Player>();
        player.Rigid2D.velocity = Vector2.zero;
        if (!player.IsNormalState())
        {
            player.ChangeState();
            player.Rigid2D.velocity = Vector2.zero;
            player.Tr.position = StartPos;
            player.ChangeState();
        }
        else
        {
            player.Tr.position = StartPos;
        }

    }
}
