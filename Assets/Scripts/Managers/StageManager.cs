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
        obj.Tr.position = StartPos;
    }
}
