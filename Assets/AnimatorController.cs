using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    // SittingHuman1 Animator is the one that has the throwFood animation and must always be sitting on the right side of the bench.
    Animator animator;
    [SerializeField] PlayerMovement player;
    [SerializeField] float playerRange = 20f;
    public bool throwingFood;
    public bool isSitting;
    public bool isTalking;
    public float talkingTimer = 0f;
    private float talkingInterval = 10f;

    void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        if (PlayerInRange() && !gameObject.CompareTag("Hostile"))
        {
            
            if (Input.GetKeyDown(KeyCode.E))
            {
                
                animator.SetBool("throwFood", true);
                throwingFood = animator.GetBool("throwFood");
            }
            else
            {
                animator.SetBool("throwFood", false);
            }
        }
        talkingTimer += Time.deltaTime;
        if (talkingTimer >= talkingInterval)
        {            
            talkingTimer = -10f;           
            StartTalking();            
        }
    }

    bool PlayerInRange()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < playerRange)
        {
            return true;
        }
        return false;
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

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, playerRange);
    }
}