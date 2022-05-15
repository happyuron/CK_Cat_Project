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

    public virtual bool CheckObject<T1, T2>() where T1 : MonoBehaviour where T2 : MonoBehaviour
    {
        Collider2D tmp = Physics2D.OverlapBox(Tr.position + offset, size, 0, hitLayer);
        T1 objT1 = tmp.GetComponent<T1>();
        T2 objT2 = tmp.GetComponent<T2>();
        return objT1 || objT2;
    }

    public virtual T CheckObject<T>() where T : MonoBehaviour
    {
        Collider2D tmp = Physics2D.OverlapBox(Tr.position + offset, size, 0, hitLayer);
        T obj = tmp.GetComponent<T>();
        return obj;
    }

    private bool CheckObjectStay()
    {
        Collider2D tmp = Physics2D.OverlapBox(Tr.position + offset, size, 0, hitLayer);
        if (tmp != null && !isOnce)
        {
            OnCheckStart();
            isOnce = true;
        }
        else if (tmp == null && isOnce)
        {
            OnCheckExit();
            isOnce = false;
        }
        else if (tmp != null)
        {
            OnCheckStay();
        }
        return tmp;
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
        CheckObjectStay();
    }
    protected virtual void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(offset + transform.position, size);
    }
}
