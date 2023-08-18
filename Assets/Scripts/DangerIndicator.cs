using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class DangerIndicator : MonoBehaviour
{
    [SerializeField] PostProcessVolume volume;
    Vignette vignette;
    PlayerMovement player;
    bool inArea;
    Vector3 startPos;
    float maxDistance;
    private void Start()
    {
        vignette = volume.profile.GetSetting<Vignette>();
        player = FindObjectOfType<PlayerMovement>();
    }

    private void Update()
    {
        if (!inArea) {return;}
        vignette.intensity.value = 1 - Vector3.Distance(player.transform.position, transform.position) / maxDistance;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player.gameObject)
        {
            inArea = true;
            startPos = player.transform.position;
            maxDistance = Vector3.Distance(transform.position, startPos);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player.gameObject)
        {
            inArea = true;
            vignette.intensity.value = 0;
        }
    }
}
