using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roll : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] bool canHit;
    [SerializeField] float speed;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeAll;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player" && canHit)
        {
            rb.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationY;
            rb.AddTorque(transform.right * speed);
        }

        if(collision.gameObject.tag == "Rock")
        {
            rb.constraints = RigidbodyConstraints.FreezeAll;
            canHit = false;
        }
    }


}