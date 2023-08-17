using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] Animator catMoving;
    [SerializeField] PlayerMovement player;
    [SerializeField] float horizontal = 0f;
    [SerializeField] bool pressed;
    [SerializeField] bool audioPlayed;
    [SerializeField] AudioSource playerJump;
    [SerializeField] AudioSource playerWalkSFX;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            playerJump.Play();
        }
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
            //playerWalkSFX.Stop();
           

        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            //playerWalkSFX.Stop();
            horizontal = 0.01f;
        }
        catMoving.SetFloat("Horizontal", horizontal);
        catMoving.SetFloat("Speed", horizontal);
        
    }
}
