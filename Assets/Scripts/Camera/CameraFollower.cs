using UnityEngine;

public class CameraFollower : Resettable
{
    [SerializeField] Transform playerTransform;
    [SerializeField] float followSpeed = 5f;
    [SerializeField] float zOffsetIncrease;
    [SerializeField] float yOffsetIncrease;
    [SerializeField] float xOffsetIncrease;
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
        Vector3 offset = new Vector3(xOffsetIncrease, yOffsetIncrease, originalZOffset + zOffsetIncrease);
        offset = Quaternion.Euler(playerTransform.rotation.eulerAngles - startRotation) * offset;
        Vector3 desiredRotation = playerTransform.position + offset;
        Quaternion targetRotation = Quaternion.LookRotation(playerTransform.position - transform.position);
        transform.position = Vector3.Lerp(transform.position, desiredRotation, followSpeed * Time.deltaTime);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, followSpeed * Time.deltaTime);
        
    }

    public void ZoomOut(float zIncrease, float yIncrease, float xIncrease)
    {
        zOffsetIncrease = zOffsetIncrease + zIncrease;
        yOffsetIncrease = yOffsetIncrease + yIncrease;
        xOffsetIncrease = xOffsetIncrease + xIncrease;
    }

    public void ZoomIn(float zDecrease, float yDecrease , float xDecrease)
    {
        zOffsetIncrease = zOffsetIncrease - zDecrease;
        yOffsetIncrease = yOffsetIncrease - yDecrease;
        xOffsetIncrease = xOffsetIncrease - xDecrease;

    }

    public override void ResetObject()
    {
        Vector3 desiredPosition = new Vector3(playerTransform.position.x, playerTransform.position.y, transform.position.z );
        transform.position = desiredPosition;
    }
}


