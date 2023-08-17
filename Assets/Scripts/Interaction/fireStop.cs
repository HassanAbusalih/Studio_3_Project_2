using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireStop : MonoBehaviour
{
    //[SerializeField] float timer;
    [SerializeField] ParticleSystem reduceFire;
    [SerializeField] ParticleSystem reduceFire2;
    [SerializeField] ParticleSystem reduceFire3;
    [SerializeField] ParticleSystem reduceFire4;
    [SerializeField] GameObject resetCollider;
    // Start is called before the first frame update
    void Start()
    {

    }

    private void Update()
    {
        //timer -= Time.deltaTime;
    }
    // Update is called once per frame


    /*private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Fire")
        {
            Debug.Log("FireOut");
            reduceFire.Stop();
            reduceFire2.Stop();
            reduceFire3.Stop();
            reduceFire4.Stop();
            resetCollider.SetActive(false);
        }
    }*/

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Fire")
        {

            reduceFire.Stop();
            reduceFire2.Stop();
            reduceFire3.Stop();
            reduceFire4.Stop();
            resetCollider.SetActive(false);
        }
    }
}

