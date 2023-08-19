using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireSpread : MonoBehaviour
{
    [SerializeField] ParticleSystem fire;
    [SerializeField] ParticleSystem fire2;
    [SerializeField] ParticleSystem fire3;
    [SerializeField] ParticleSystem fire4;
    [SerializeField] ParticleSystem fire5;
    [SerializeField] ParticleSystem fire6;
    [SerializeField] ParticleSystem fire7;
    [SerializeField] ParticleSystem fire8;
    [SerializeField] GameObject finalFire;
    //[SerializeField] ParticleSystem fire9;
    [SerializeField] float timer = 5f;
   // [SerializeField] bool isBurnt;
    //[SerializeField] Rigidbody treerb;
    

    //[SerializeField] ParticleSystem[] particles;
    // Start is called before the first frame update
    void Start()
    {
        finalFire.SetActive(false);
        fire.Pause();
        fire2.Pause();
        fire3.Pause();
        fire4.Pause();
        fire5.Pause();
        fire6.Pause();
        fire7.Pause();
        fire8.Pause();
        //isBurnt = false;
    }

    void Update()
    {
        timer -= Time.deltaTime;
    }
    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player" || other.gameObject.tag == "Branch")
        {
            if(timer <= 0f)
            {
                fire.Play();
                fire2.Play();
                fire3.Play();
                fire4.Play();
                fire5.Play();
                fire6.Play();
                fire7.Play();
                fire8.Play();
                finalFire.SetActive(true);
                //fire9.Play();
                //isBurnt = true;

            }
            
            /*if(isBurnt == true)
            {
                treerb.isKinematic = false;
            }*/
        }
    }
}
