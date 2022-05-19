using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class InputManager : Singleton<InputManager>
{
    public GraphicRaycaster[] raycaster;
    public GraphicRaycaster controller;
    private Player player;
    private PlayerMove move;

    private bool set;
    private void Start()
    {
        set = true;
        raycaster = FindObjectsOfType<GraphicRaycaster>();
        for (int i = 0; i < raycaster.Length; i++)
        {
            if (raycaster[i] == controller)
            {
                raycaster[i] = null;
                break;
            }
        }

        player = FindObjectOfType<Player>();
        if (player != null)
        {
            move = player.gameObject.GetComponent<PlayerMove>();
        }
        else
            Debug.Log("PlayerNull");
    }

    public void MoveRight(InputAction.CallbackContext ctx)
    {
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
        if (player.CurState == PlayerState.Water)
        {
            ControllerButtonDown();
            ControllerButtonUp();
        }
    }
    public void ControllerButtonDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            PointerEventData pos = new PointerEventData(null);
            pos.position = Input.mousePosition;
            List<RaycastResult> results = new List<RaycastResult>();
            for (int i = 0; i < raycaster.Length; i++)
            {
                if (raycaster[i] != null)
                    raycaster[i].Raycast(pos, results);
            }
            if (results.Count == 0)
            {
                GravityController.Instance.SetGravity(0, pos.position);
            }
            else
                set = false;
        }
    }
    public void ControllerButtonUp()
    {
        if (Input.GetMouseButtonUp(0))
        {
            PointerEventData pos = new PointerEventData(null);
            pos.position = Input.mousePosition;
            List<RaycastResult> results = new List<RaycastResult>();
            for (int i = 0; i < raycaster.Length; i++)
            {
                if (raycaster[i] != null)
                    raycaster[i].Raycast(pos, results);
            }
            if (results.Count == 0 && set)
            {
                GravityController.Instance.SetGravity(1, pos.position);
            }
            set = true;
        }
    }
}
