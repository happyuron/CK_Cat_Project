using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public float gravity;
    private Vector2 gravityDirection;
    public Player player;
    public bool gameClear = false;

    public Vector2 GravityDirection
    {
        get { return gravityDirection; }
        set
        {
            gravityDirection = value;
            if (player.CurState == PlayerState.Water)
            {
                ApplyGravityToObj<ObjByPlayer>();
            }
            else if (player.IsNormalState())
            {
                ApplyGravityToObj<ObjByEffect>();
            }
        }
    }
    public void ClearGame(Goal goal)
    {
        StartCoroutine(GameEnd(goal));
    }

    private IEnumerator GameEnd(Goal goal)
    {
        yield return new WaitForSeconds(goal.WaitSecond);
        if (goal.CheckObject<Player, Pivot>())
        {
            GameManager.Instance.gameClear = true;
            SceneLoader.Instance.LoadScene(StageManager.Instance.NextSceneIndex);
        }
    }


    public void DefaultGravityToObj<T>() where T : ObjByPlayer
    {
        T[] obj = FindObjectsOfType<T>();
        IGravityEfftectedObj gravityEfftectedObj;
        for (int i = 0; i < obj.Length; i++)
        {
            gravityEfftectedObj = obj[i].GetComponent<IGravityEfftectedObj>();
            if (gravityEfftectedObj != null)
            {
                if (gravityEfftectedObj.GetOnlyWater())
                    gravityEfftectedObj.DefaultGravity();
            }
        }
    }

    public void ApplyGravityToObj<T>() where T : ObjByPlayer
    {
        T[] obj = FindObjectsOfType<T>();
        IGravityEfftectedObj gravityEfftectedObj;
        for (int i = 0; i < obj.Length; i++)
        {
            gravityEfftectedObj = obj[i].GetComponent<IGravityEfftectedObj>();
            if (gravityEfftectedObj != null)
            {
                gravityEfftectedObj.SetGravityDirection(gravityDirection);
            }
        }
    }


}
