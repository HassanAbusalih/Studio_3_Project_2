using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraControl : MonoBehaviour
{
    [SerializeField] CameraFollower cameraZoom;
    [SerializeField] LayerMask triggerLayer;
    [SerializeField] float zChange;
    [SerializeField] float yChange;
    [SerializeField] float xChange;
    bool entered;

    private void OnTriggerEnter(Collider other)
    {
        if (triggerLayer == (triggerLayer | (1 << other.gameObject.layer)) && entered == false)
        {
            cameraZoom.ZoomOut(zChange,yChange,xChange);
            entered = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (triggerLayer == (triggerLayer | (1 << other.gameObject.layer)) && entered == true)
        {
            cameraZoom.ZoomIn(zChange, yChange, xChange);
            entered = false;
        }
    }
}