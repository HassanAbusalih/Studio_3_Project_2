using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateUIPopUp : MonoBehaviour
{
    [SerializeField] GameObject PopUpImage;
    [SerializeField] GameObject PopUpImage2;
    [SerializeField] bool IsButtonPressed;
    [SerializeField] bool Entered;

    private void OnTriggerEnter(Collider other)
    {
        Entered = true;
        if(IsButtonPressed == false)
        {
            PopUpImage.SetActive(true);
            PopUpImage2.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        PopUpImage.SetActive(false);
        PopUpImage2.SetActive(false);
        Entered = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && Entered == true)
        {
            IsButtonPressed = true;
        }
    }
}
