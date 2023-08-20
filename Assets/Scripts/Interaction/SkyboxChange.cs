using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxChange : MonoBehaviour
{
    public Color newColor = Color.red; 
    public float colorChangeDuration; 
    public Light Sun;
    [SerializeField] AudioSource fireSFX;
    bool colorChanged;

    private Color initialColor;
    private Color targetColor;
    private float colorChangeStartTime;


    private void Start()
    {
        initialColor = Sun.color;
        targetColor = newColor;
    }

    private void Update()
    {
        if (colorChanged && Sun.color != targetColor) 
        {
            float elapsed = Time.time - colorChangeStartTime;

            float t = Mathf.Clamp01(elapsed / colorChangeDuration);

            Color lerpedColor = Color.Lerp(initialColor, targetColor, t);

            Sun.color = lerpedColor;
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(!colorChanged)
        {
            colorChangeStartTime = Time.time;
            colorChanged = true;
            fireSFX.Play();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(0, 0, 0.5f, 0.2f);
        BoxCollider collider = GetComponent<BoxCollider>();
        Gizmos.DrawCube(transform.position, collider.size);
    }

}
