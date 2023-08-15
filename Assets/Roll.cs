using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roll : MonoBehaviour
{
    Rigidbody rb;
    //public float speed;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        /*if(Input.GetKeyDown(KeyCode.Space))
        {
            //rb.AddForce(transform.forward, ForceMode.Impulse);
            rb.AddTorque(transform.right);
        }*/
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            rb.AddTorque(transform.right);
        }
    }
}