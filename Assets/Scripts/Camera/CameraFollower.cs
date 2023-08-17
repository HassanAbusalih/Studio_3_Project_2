using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : Resettable
{
    [SerializeField] Transform playerTransform;
    [SerializeField] float followSpeed = 5f;
    [SerializeField] float zOffsetIncrease;
    [SerializeField] float yOffsetIncrease;
    [SerializeField] bool zoom;
    float originalZOffset;
    Vector3 startRotation;

    private void Start()
    {
        originalZOffset = transform.position.z - playerTransform.position.z;
        startRotation = playerTransform.rotation.eulerAngles;
    }

    void FixedUpdate()
    {
        Vector3 offset = new Vector3(0, yOffsetIncrease, originalZOffset);
        offset = Quaternion.Euler(playerTransform.rotation.eulerAngles - startRotation) * offset;
        Vector3 desiredRotation = playerTransform.position + offset;
        Quaternion targetRotation = Quaternion.LookRotation(playerTransform.position - transform.position);
        Vector3 desiredPosition = new Vector3(playerTransform.position.x, playerTransform.position.y + yOffsetIncrease, playerTransform.position.z + zOffsetIncrease);
        if (zoom == true)
        {
            transform.position = Vector3.Lerp(transform.position, desiredPosition, followSpeed * Time.deltaTime);
            zoom = false;
            Debug.Log("in");
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, desiredRotation, followSpeed * Time.deltaTime);
        }

        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, followSpeed * Time.deltaTime);
        
    }

    public void ZoomOut(float increase)
    {
        Debug.Log(increase);
        zOffsetIncrease = zOffsetIncrease + increase;
        zoom = true;
    }

    public void ZoomUp(float increase)
    {
        yOffsetIncrease = yOffsetIncrease + increase;
        zoom = true;
    }
    public void ZoomDown(float increase)
    {
        yOffsetIncrease = yOffsetIncrease - increase;
        zoom = true;
    }
    public void ZoomIn(float decrease)
    {
        zOffsetIncrease = zOffsetIncrease - decrease;
        zoom = true;
    }

    public override void ResetObject()
    {
        Vector3 desiredPosition = new Vector3(playerTransform.position.x, playerTransform.position.y, transform.position.z );
        transform.position = desiredPosition;
    }
}


