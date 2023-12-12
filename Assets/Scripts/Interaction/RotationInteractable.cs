using UnityEngine;
using System.Collections;
using UnityEngine.Serialization;

public class RotationInteractable : Interactable
{
    [SerializeField] float rotationAngle = 30;
    [SerializeField] float rotationTime = 0.5f;
    [SerializeField][FormerlySerializedAs("xIfFalseZIfTrue")] bool lockXIfFalseZIfTrue;
    Vector3 targetPosition;
    PlayerMovement player;
    Rigidbody rb;
    
    void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
        rb = player.GetComponent<Rigidbody>();
        targetPosition = transform.position;
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
        Vector3 startPos = player.transform.position;
        player.ToggleInput();
        while (time < rotationTime)
        {
            player.transform.rotation = Quaternion.Lerp(startRot, targetRotation, time / rotationTime);
            player.transform.position = Vector3.Lerp(startPos, targetPosition, time / rotationTime);
            time += Time.deltaTime;
            yield return null;
        }
        if (lockXIfFalseZIfTrue)
        {
            rb.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
        }
        else
        {
            rb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezeRotation;
        }
        player.transform.position = targetPosition;
        player.transform.rotation = targetRotation;
        player.ToggleInput();
    }
}
