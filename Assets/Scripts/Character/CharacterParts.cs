using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterParts<T> : MonoBehaviour where T : MonoBehaviour
{
    public Transform Tr { get; protected set; }

    protected virtual void Awake()
    {
        Tr = GetComponent<Transform>();
    }
}
