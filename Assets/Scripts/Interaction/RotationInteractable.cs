using UnityEngine;
using System.Collections;

public class RotationInteractable : Interactable
{
    [SerializeField] float rotationAngle = 30;
    [SerializeField] float rotationTime = 0.5f;
    PlayerMovement player;
    
    void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
    }

    protected override void Interact()
    {
        Quaternion rotation = Quaternion.Euler(0, rotationAngle, 0);
        Quaternion targetRotation = player.transform.rotation * rotation;
        StartCoroutine(RotateCamera(targetRotation));
    }

    IEnumerator RotateCamera(Quaternion targetRotation)
    {
        float time = 0;
        Quaternion startRot = player.transform.rotation;
        //player.enabled = false;
        while (time < rotationTime)
        {
            player.transform.rotation = Quaternion.Lerp(startRot, targetRotation, time / rotationTime);
            time += Time.deltaTime;
            yield return null;
        }
        //player.enabled = true;
    }
}
