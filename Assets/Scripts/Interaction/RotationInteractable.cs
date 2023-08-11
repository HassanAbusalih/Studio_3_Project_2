using UnityEngine;
using System.Collections;

public class RotationInteractable : Interactable
{
    [SerializeField] float rotationAngle = 30;
    [SerializeField] float cameraRotationTime = 0.5f;
    CameraFollower cameraFollower;
    PlayerMovement player;
    
    void Start()
    {
        cameraFollower = FindObjectOfType<CameraFollower>();
        player = FindObjectOfType<PlayerMovement>();
    }

    public override void Interact()
    {
        Quaternion rotation = Quaternion.Euler(0, rotationAngle, 0);
        player.transform.rotation *= rotation;
        Vector3 rotatedCameraOffset = rotation * (cameraFollower.transform.position - player.transform.position);
        Vector3 targetPos = player.transform.position + rotatedCameraOffset;
        StartCoroutine(RotateCamera(targetPos));
    }

    IEnumerator RotateCamera(Vector3 targetPos)
    {
        float time = 0;
        Vector3 startPos = cameraFollower.transform.position;
        cameraFollower.enabled = false;
        while (time < cameraRotationTime)
        {
            cameraFollower.transform.position = Vector3.Lerp(startPos, targetPos, time / cameraRotationTime);
            cameraFollower.transform.LookAt(player.transform.position);
            time += Time.deltaTime;
            yield return null;
        }
        cameraFollower.enabled = true;
    }
}
