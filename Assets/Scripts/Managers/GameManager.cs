using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [HideInInspector] public Vector2 gravityDirection => UiManager.Instance.GetGravityValue();


}
