using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roll : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] bool canHit;
    [SerializeField] float speed;
    //public float speed;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeAll;
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
        if(collision.gameObject.tag == "Player" && canHit)
        {
            rb.constraints = RigidbodyConstraints.None;
            //rb.constraints = RigidbodyConstraints.FreezeRotation;
            rb.AddTorque(transform.right * speed);
        }

        if(collision.gameObject.tag == "Rock")
        {
            rb.constraints = RigidbodyConstraints.FreezeAll;
        }
    }


}