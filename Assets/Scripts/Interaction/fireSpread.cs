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
    

    //[SerializeField] ParticleSystem[] particles;
    // Start is called before the first frame update
    void Start()
    {
        fire.Pause();
        fire2.Pause();
        fire3.Pause();
        fire4.Pause();
        fire5.Pause();
        fire6.Pause();
        
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            fire.Play();
            fire2.Play();
            fire3.Play();
            fire4.Play();
            fire5.Play();
            fire6.Play();
            
        }
    }
}
