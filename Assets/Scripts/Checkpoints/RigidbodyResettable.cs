using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidbodyResettable : Resettable
{
    Vector3 startPos;
    Quaternion startRot;
    Rigidbody rb;

    void Start()
    {
        startPos = transform.position;
        startRot = transform.rotation;
        rb = GetComponent<Rigidbody>();
    }

    public override void ResetObject()
    {
        transform.position = startPos;
        transform.rotation = startRot;
        rb.isKinematic = true;
    }
}
