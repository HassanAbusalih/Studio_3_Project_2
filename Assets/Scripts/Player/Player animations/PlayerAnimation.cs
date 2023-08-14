using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] Animator catMoving;
    [SerializeField] PlayerMovement player;
    [SerializeField]float horizontal = 0f;
    [SerializeField] bool pressed;

    void Update()
    {
        if (Input.GetKey(KeyCode.A) && pressed == false)
        {
            horizontal = -1f;
            pressed = true;
        }
        else
        {
            pressed = false;
        }

        if (Input.GetKey(KeyCode.D) && pressed == false)
        {
            horizontal = 1f;
            pressed = true;
        }
        else
        {
            pressed = false;
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            horizontal = -0.01f;
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            horizontal = 0.01f;
        }
        catMoving.SetFloat("Horizontal", horizontal);
        catMoving.SetFloat("Speed", horizontal);
        /*if (Input.GetButtonDown("Jump"))
        {
            catMoving.SetBool("Jump", true);
        }
        else
        {
            catMoving.SetBool("Jump", false);
        }*/
    }
}
