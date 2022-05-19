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

    private GameObject deadParticleCNG;
    private ParticleSystem deadParticle;

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

    protected override void Awake()
    {
        base.Awake();
        deadParticleCNG = Resources.Load<GameObject>("Prefebs/Particle");
        deadParticle = Instantiate(deadParticleCNG, transform).gameObject.GetComponent<ParticleSystem>();
    }

    public void PlayDeadParticle()
    {
        if (player.IsNormalState())
            deadParticle.transform.position = player.Tr.position;
        else
        {
            deadParticle.transform.position = player.born.position;
        }
        deadParticle.Play();
    }


    public void ClearGame(Goal goal)
    {
        if (StageManager.Instance.NextSceneIndex != 0)
            StartCoroutine(GameEnd(goal));
        else
        {
            gameClear = true;
            UiManager.Instance.HideAllSetMenu();
            UiManager.Instance.PopUpClearUi();

        }
    }

    private IEnumerator GameEnd(Goal goal)
    {
        yield return new WaitForSeconds(goal.WaitSecond);
        if (goal.CheckObject<Player, Pivot>())
        {
            gameClear = true;
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
