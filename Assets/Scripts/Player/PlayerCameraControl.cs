using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraControl : MonoBehaviour
{
    [SerializeField] CameraFollower cameraZoom;
    [SerializeField] LayerMask triggerLayer;
    [SerializeField] float depthIncrease;
    [SerializeField] float heightIncrease;
    [SerializeField] float positionIncrease;
    bool entered;

    private void OnTriggerEnter(Collider other)
    {
        if (triggerLayer == (triggerLayer | (1 << other.gameObject.layer)) && entered == false)
        {
            cameraZoom.ZoomOut(depthIncrease,heightIncrease,positionIncrease);
            entered = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (triggerLayer == (triggerLayer | (1 << other.gameObject.layer)) && entered == true)
        {
            cameraZoom.ZoomIn(depthIncrease, heightIncrease, positionIncrease);
            entered = false;
        }
    }
}