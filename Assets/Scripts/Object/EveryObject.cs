using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EveryObject : MonoBehaviour
{
    public Transform Tr { get; protected set; }

    protected virtual void Awake()
    {
        Tr = GetComponent<Transform>();
    }

    protected T AddComponent<T>() where T : MonoBehaviour
    {
        T tmp = gameObject.AddComponent<T>();
        return tmp;
    }
}
