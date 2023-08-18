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
    Vector3 startRotation;
    bool allowInput = true;

    private void Awake()
    {
        startRotation = transform.rotation.eulerAngles;
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        float moveHorizontal = 0f;
        if (!allowInput) {return;}
        if (Input.GetKey(KeyCode.D))
        {
            moveHorizontal = 1f;
        }
        if (Input.GetKey(KeyCode.A))
        {
            moveHorizontal = -1f;
        }
        Vector3 moveDirection = new Vector3(moveHorizontal, 0f, 0f).normalized;
        Quaternion targetRotation = Quaternion.Euler(transform.rotation.eulerAngles - startRotation);
        moveDirection = targetRotation * moveDirection;
        rb.velocity = new Vector3(moveDirection.x * moveSpeed, rb.velocity.y, moveDirection.z * moveSpeed);
        if ( canJump == true && Input.GetKeyDown(jump))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    public void ToggleInput()
    {
        allowInput = !allowInput;
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
