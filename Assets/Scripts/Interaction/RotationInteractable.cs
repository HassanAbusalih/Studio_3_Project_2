using UnityEngine;
using System.Collections;

public class RotationInteractable : Interactable
{
    [SerializeField] float rotationAngle = 30;
    [SerializeField] float cameraRotationTime = 0.5f;
    CameraFollower cameraFollower;
    PlayerMovement player;

    public override void Interact()
    {
        Quaternion rotation = new Quaternion();
        rotation.eulerAngles = new Vector3(0, 30, 0);
        player.transform.Rotate(rotation.eulerAngles);
        Vector3 camOffset = cameraFollower.transform.position - player.transform.position;
        camOffset = rotation * camOffset;
        StartCoroutine(RotateCamera(camOffset));
    }

    IEnumerator RotateCamera(Vector3 target)
    {
        float time = 0;
        Vector3 startPos = cameraFollower.transform.position;
        cameraFollower.enabled = false;
        while(time < cameraRotationTime)
        {
            cameraFollower.transform.position = Vector3.Lerp(startPos, target, time / cameraRotationTime);
            cameraFollower.transform.LookAt(player.transform.position);
            yield return null;
        }
        cameraFollower.enabled = true;
    }

    void Start()
    {
        cameraFollower = FindObjectOfType<CameraFollower>();
        player = FindObjectOfType<PlayerMovement>();
    }
}
