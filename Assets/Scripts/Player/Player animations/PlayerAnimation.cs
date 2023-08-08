using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] Animator catMoving;
    [SerializeField] PlayerMovement player;
    [SerializeField]float horizontal = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.A))
        {
            horizontal = -1f;
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            horizontal = -0.01f;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            horizontal = 1f;
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
