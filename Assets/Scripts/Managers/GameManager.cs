using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public float gravity;
    private Vector2 gravityDirection;
    public Player player;

    public Vector2 GravityDirection
    {
        get { return gravityDirection; }
        set
        {
            gravityDirection = GravityController.Instance.GetGravity();
            if (player.CurState == PlayerState.Water)
            {
                ApplyGravityToObj<ObjByPlayer>();
            }
            else if (player.CurState == PlayerState.Normal)
            {
                ApplyGravityToObj<ObjByEffect>();
            }
        }
    }
    protected override void Awake()
    {
        base.Awake();
    }

    protected void Start()
    {
        player = FindObjectOfType<Player>();
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
            Time.timeScale = 0;
            SceneLoader.LoadScene(StageManager.Instance.NextSceneIndex);
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
