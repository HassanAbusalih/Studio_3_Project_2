using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraControl : MonoBehaviour
{
    [SerializeField] CameraFollower cameraZoom;
    [SerializeField] LayerMask triggerLayer;
    [SerializeField] float zoomLevel;

    private void OnTriggerEnter(Collider other)
    {
        if (triggerLayer == (triggerLayer | (1 << other.gameObject.layer)))
        {
            cameraZoom.ZoomOut(zoomLevel);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (triggerLayer == (triggerLayer | (1 << other.gameObject.layer)))
        {
            cameraZoom.ZoomIn(zoomLevel);
        }
    }
}