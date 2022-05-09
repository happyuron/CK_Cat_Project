using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class InputManager : Singleton<InputManager>
{
    public List<GraphicRaycaster> raycaster;
    public GraphicRaycaster controller;
    Player player;
    PlayerMove move;
    private void Start()
    {
        player = FindObjectOfType<Player>();
        if (player != null)
        {
            move = player.gameObject.GetComponent<PlayerMove>();
        }
    }

    public void MoveRight(InputAction.CallbackContext ctx)
    {
        Debug.Log("Move");
        move.MoveRight(ctx.ReadValue<Vector2>());
    }
    public void Jump(InputAction.CallbackContext ctx)
    {
        if (ctx.ReadValueAsButton())
        {
            move.Jump();
        }
    }
    public void ChangeState(InputAction.CallbackContext ctx)
    {
        if (ctx.ReadValueAsButton())
        {
            player.ChangeState();
        }
    }

    private void Update()
    {
        ControllerButtonDown();
        ControllerButtonUp();
    }
    public void ControllerButtonDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            PointerEventData pos = new PointerEventData(null);
            pos.position = Input.mousePosition;
            List<RaycastResult> results = new List<RaycastResult>();
            for (int i = 0; i < raycaster.Count; i++)
            {
                raycaster[i].Raycast(pos, results);
            }
            if (results.Count == 0)
            {
                controller.Raycast(pos, results);
                UiManager.Instance.SetGravityValue(0, results[0].screenPosition);
            }
        }
    }
    public void ControllerButtonUp()
    {
        if (Input.GetMouseButtonUp(0))
        {
            PointerEventData pos = new PointerEventData(null);
            pos.position = Input.mousePosition;
            List<RaycastResult> results = new List<RaycastResult>();
            for (int i = 0; i < raycaster.Count; i++)
            {
                raycaster[i].Raycast(pos, results);
            }
            if (results.Count == 0)
            {
                controller.Raycast(pos, results);
                UiManager.Instance.SetGravityValue(1, results[0].screenPosition);
            }
        }
    }
}
