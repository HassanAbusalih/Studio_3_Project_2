using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class treeFall : MonoBehaviour
{
    [SerializeField] Animator fallingDown;
    [SerializeField] GameObject fireClear;
    // Start is called before the first frame update
    void Start()
    {
        fallingDown.SetBool("caughtFire", false);
    }


    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Fire")
        {
            fallingDown.SetBool("caughtFire", true);
            //fireClear.SetActive(false);
        }
    }

    void Update()
    {
       
    }
}
