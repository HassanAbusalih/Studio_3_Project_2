using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HostileAnimatorController : MonoBehaviour
{
    Animator animator;
    [SerializeField] PlayerMovement player;
    [SerializeField] float playerRange = 20f;
    [SerializeField] float playerCloseRange = 2.5f;
    public float loopDelay = 2f;


    void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        if (PlayerInRange() && gameObject.CompareTag("Hostile"))
        {
            
            actHostile();
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

    bool PlayerInCloseRange()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < playerCloseRange)
        {
            return true;
        }
        return false;
    }

    void actHostile()
    {
        Debug.Log("Hostility!");
        if (PlayerInCloseRange())
        {
            animator.SetBool("isAnnoyed", false);
            animator.SetBool("isKicking", true);
            

        }

        else
        {
            animator.SetBool("isAnnoyed", true);
            animator.SetBool("isKicking", false);
        }

    }

    


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, playerRange);
    }
}

