using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pivot : MonoBehaviour
{
    Vector2 defaultPosition;
    private void Awake()
    {
        defaultPosition = transform.localPosition;
    }

    public void ResetPos()
    {
        transform.localPosition = defaultPosition;
    }
}
