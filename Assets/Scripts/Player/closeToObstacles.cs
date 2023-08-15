using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.PostProcessing;

public class closeToObstacles : MonoBehaviour
{
    [SerializeField] PostProcessVolume volume;
    [SerializeField] bool increase;
    [SerializeField] float currentValue;
    Vignette fireClose;
    // Start is called before the first frame update
    void Start()
    {
        fireClose = volume.profile.GetSetting<Vignette>();
        fireClose.intensity.value = 0f;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            fireClose.intensity.value = 1f;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
