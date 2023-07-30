using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    CharacterController controller;
    [SerializeField] float speed = 5.0f;
    [SerializeField] float gravity = 1.0f;
    [SerializeField] float jumpHeight = 15.0f;
    float yVelocity;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        Vector3 direction = new Vector3(horizontal, 0, 0).normalized;
        Vector3 velocity = direction * speed;

        if (controller.isGrounded)
        {
            if (Input.GetButtonDown("Jump"))
            {
                yVelocity = jumpHeight;
            }
        }

        if (yVelocity < 0 && controller.isGrounded)
        {
            yVelocity = -2f; // To ensure the character doesn't stick to the ground when moving down slopes.
        }

        yVelocity -= gravity;
        velocity.y = yVelocity;

        controller.Move(velocity * Time.deltaTime);
    }

}
