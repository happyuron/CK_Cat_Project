using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageManager : Singleton<StageManager>
{
    public int NextSceneIndex;
    public Vector2 StartPos { get; private set; }

    public StartPosition[] SavePoint { get; private set; }


    protected override void Awake()
    {
        base.Awake();
        if (NextSceneIndex == 0)
        {
            if (SceneManager.GetSceneAt(SceneManager.GetActiveScene().buildIndex + 1) == null)
                NextSceneIndex = 0;
            else
                NextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;

        }

    }

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
