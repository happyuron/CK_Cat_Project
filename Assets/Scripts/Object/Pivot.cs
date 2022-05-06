using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pivot : MonoBehaviour
{
    private Vector2 defaultPosition;

    private Collider2D collder;

    private Rigidbody2D rigid;
    private Quaternion defaultAngleZ;
    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        defaultPosition = transform.localPosition;
        defaultAngleZ = transform.rotation;
        collder = GetComponent<Collider2D>();
    }

    public void ResetPos()
    {
        collder.enabled = false;
        transform.localPosition = defaultPosition;
        transform.rotation = defaultAngleZ;
    }
    public void SetUp()
    {
        rigid.velocity = new Vector2(0, 0);
        transform.localPosition = defaultPosition;
        collder.enabled = true;
    }
}
