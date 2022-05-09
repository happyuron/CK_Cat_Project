using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : EveryObject
{
    [field: SerializeField] public float WaitSecond { get; private set; }
    [SerializeField] private Vector3 offset;

    [SerializeField] private Vector2 size;
    private bool isOnce;
    public LayerMask hitLayer;


    public bool CheckPlayer()
    {
        bool checkPlayer = false;
        Collider2D tmp = Physics2D.OverlapBox(Tr.position + offset, size, 0, hitLayer);

        if (tmp != null)
            checkPlayer = true;

        if (tmp != null && !isOnce)
        {
            StartCoroutine(GameManager.Instance.GameEnd(this));
            isOnce = true;
            return true;
        }
        else if (tmp == null && isOnce)
        {
            StopCoroutine(GameManager.Instance.GameEnd(this));
            isOnce = false;

        }

        return checkPlayer;
    }

    private void FixedUpdate()
    {
        CheckPlayer();
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(offset + transform.position, size);
    }
}
