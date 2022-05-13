using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerObject : EveryObject
{
    [SerializeField] protected Vector3 offset;
    [SerializeField] protected Vector2 size;


    public LayerMask hitLayer;
    public bool isOnce = false;

    #region TriggerSystem
    public virtual bool CheckObject()
    {
        Collider2D tmp = Physics2D.OverlapBox(Tr.position + offset, size, 0, hitLayer);

        return tmp;
    }

    private bool CheckObjectStay()
    {
        Collider2D tmp = Physics2D.OverlapBox(Tr.position + offset, size, 0, hitLayer);
        if (tmp != null)
        {
            OnCheckStay();
        }
        return tmp;
    }

    private bool CheckObjectStart()
    {
        if (!isOnce)
        {
            Collider2D tmp = Physics2D.OverlapBox(Tr.position + offset, size, 0, hitLayer);
            if (tmp != null)
            {
                isOnce = true;
                OnCheckStart();
                return tmp;
            }
        }
        return false;
    }
    private bool CheckObjectExit()
    {
        if (isOnce)
        {
            Collider2D tmp = Physics2D.OverlapBox(Tr.position + offset, size, 0, hitLayer);
            if (tmp == null)
            {
                isOnce = false;
                OnCheckExit();
            }
            return tmp;
        }
        return false;
    }
    #endregion

    protected virtual void OnCheckStart()
    {

    }
    protected virtual void OnCheckStay()
    {

    }
    protected virtual void OnCheckExit()
    {

    }
    protected virtual void FixedUpdate()
    {
        CheckObjectStart();
        CheckObjectStay();
        CheckObjectExit();
    }
}
