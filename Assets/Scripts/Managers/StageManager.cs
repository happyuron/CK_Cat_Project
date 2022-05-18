using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageManager : Singleton<StageManager>
{
    public Vector2 StartPos { get; private set; }


    public AudioClip mainBGM;



    public bool showSettingButton = true;
    public int NextSceneIndex;

    private void Start()
    {
        if (SoundManager.Instance.GetAudioClip() != mainBGM)
        {
            SoundManager.Instance.audioSource.clip = mainBGM;
            SoundManager.Instance.PlayMainSound();
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
    public bool IsPlayer(EveryObject obj)
    {
        Player player = obj.GetComponent<Player>() ?? obj.GetComponentInParent<Player>();
        if (player == null)
            return false;
        return true;
    }
    public void LoadPlayer(EveryObject obj)
    {
        Player player = obj.GetComponent<Player>() ?? obj.GetComponentInParent<Player>();

        player.Rigid2D.velocity = Vector2.zero;
        if (player.CurState == PlayerState.Water)
        {
            player.ChangeState();
            player.Rigid2D.velocity = Vector2.zero;
            player.Tr.position = StartPos;
            player.ChangeState();
        }
        else if (player.IsNormalState())
        {
            player.Tr.position = StartPos;
        }

    }
}
