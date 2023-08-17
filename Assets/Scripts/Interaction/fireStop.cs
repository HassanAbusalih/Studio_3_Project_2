using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireStop : MonoBehaviour
{
    //[SerializeField] float timer;
    [SerializeField] ParticleSystem reduceFire;
    // Start is called before the first frame update
    void Start()
    {

    }

    private void Update()
    {
        //timer -= Time.deltaTime;
    }
    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Fire")
        {

            reduceFire.Stop();

        }
    }
}

