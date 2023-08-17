using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraControl : MonoBehaviour
{
    [SerializeField] CameraFollower cameraZoom;
    [SerializeField] LayerMask triggerLayer;
    [SerializeField] float depthIncrease;
    [SerializeField] float heightIncrease;
    bool entered;

    private void OnTriggerEnter(Collider other)
    {
        if (triggerLayer == (triggerLayer | (1 << other.gameObject.layer)) && entered == false)
        {
            cameraZoom.ZoomOut(depthIncrease);
            cameraZoom.ZoomUp(heightIncrease);
            entered = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (triggerLayer == (triggerLayer | (1 << other.gameObject.layer)) && entered == true)
        {
            cameraZoom.ZoomIn(depthIncrease);
            cameraZoom.ZoomDown(heightIncrease);
            entered = false;
        }
    }
}