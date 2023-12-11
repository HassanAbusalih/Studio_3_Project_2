using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    // SittingHuman1 Animator is the one that has the throwFood animation and must always be sitting on the right side of the bench.


    Animator animator;
    public bool throwingFood;
    public bool isSitting;
    public bool isTalking;

    public float talkingTimer = 0f;
    private float talkingInterval = 10f;



    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("e"))
        {
            animator.SetBool("throwFood", true);
            throwingFood = animator.GetBool("throwFood");
        }

        else
        {
            animator.SetBool("throwFood", false);
        }

        talkingTimer += Time.deltaTime;

        if (talkingTimer >= talkingInterval)
        {
            
            talkingTimer = -10f;

            
            StartTalking();
            
        }
    }

    void StartTalking()
    {
        
        animator.SetBool("isTalking", true);

        
        StartCoroutine(StopTalkingAfterDelay(10f));
        
    }

    IEnumerator StopTalkingAfterDelay(float delay)
    {
        
        yield return new WaitForSeconds(delay);

        animator.SetBool("isTalking", false);
        
    }
}
