using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : Resettable
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float jumpForce = 10f;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] Rigidbody rb;
    [SerializeField] KeyCode jump;
    [SerializeField] bool canJump;
    

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {

        float moveHorizontal = Input.GetAxis("Horizontal");
        Vector3 moveDirection = new Vector3(moveHorizontal, 0f, 0f).normalized;
        rb.velocity = new Vector3(moveDirection.x * moveSpeed, rb.velocity.y, 0f);
        if ( canJump == true && Input.GetKeyDown(jump))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (groundLayer == (groundLayer | (1 << other.gameObject.layer)))
        {
            
            canJump = true; 
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (groundLayer == (groundLayer | (1 << other.gameObject.layer)))
        {

            canJump = false;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (groundLayer == (groundLayer | (1 << other.gameObject.layer)))
        {

            canJump = true;
        }
    }

    public override void ResetObject()
    {
        this.gameObject.transform.position = new Vector3(Checkpoint.CurrentCheckpoint.x, Checkpoint.CurrentCheckpoint.y, Checkpoint.CurrentCheckpoint.z);
    }
}
