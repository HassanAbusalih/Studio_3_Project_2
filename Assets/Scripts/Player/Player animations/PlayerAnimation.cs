using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] Animator catMoving;
    [SerializeField] PlayerMovement player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
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
