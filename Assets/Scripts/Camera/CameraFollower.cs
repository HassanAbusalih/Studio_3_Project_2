using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : Resettable
{
    [SerializeField] Transform playerTransform;
    [SerializeField] float followSpeed = 5f;
    [SerializeField] float zOffsetIncrease;
    [SerializeField] float yOffsetIncrease;
    float originalZOffset;
    bool isTriggered = false;
    [SerializeField] LayerMask triggerLayer;
    //Vector3 startRotation;

    private void Start()
    {
        originalZOffset = transform.position.z - playerTransform.position.z;
        //startRotation = playerTransform.rotation.eulerAngles;
    }

    void LateUpdate()
    {
        //Vector3 offset = new Vector3(0, yOffsetIncrease, originalZOffset + zOffsetIncrease);
        //offset = Quaternion.Euler(playerTransform.rotation.eulerAngles - startRotation) * offset;
        //Vector3 desiredPosition = playerTransform.position + offset;
        //Quaternion targetRotation = Quaternion.LookRotation(playerTransform.position - transform.position);
        Vector3 desiredPosition = new Vector3(playerTransform.position.x, playerTransform.position.y + yOffsetIncrease, transform.position.z);
        if (!isTriggered)
        {
            transform.position = Vector3.Lerp(transform.position, desiredPosition, followSpeed * Time.deltaTime);
            //transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, followSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (triggerLayer == (triggerLayer | (1 << other.gameObject.layer)))
        {
            isTriggered = true;
            Vector3 desiredPosition = new Vector3(playerTransform.position.x, playerTransform.position.y, transform.position.z + originalZOffset + zOffsetIncrease);
            transform.position = desiredPosition;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (triggerLayer == (triggerLayer | (1 << other.gameObject.layer)))
        {
            isTriggered = false;
            Vector3 desiredPosition = new Vector3(playerTransform.position.x, playerTransform.position.y , transform.position.z + originalZOffset);
            transform.position = desiredPosition;
        }
    }
    public override void ResetObject()
    {
        Vector3 desiredPosition = new Vector3(playerTransform.position.x, playerTransform.position.y + yOffsetIncrease, transform.position.z + originalZOffset);
        transform.position = desiredPosition;
    }
}


