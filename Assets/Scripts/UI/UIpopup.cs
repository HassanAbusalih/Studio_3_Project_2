using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIpopup : MonoBehaviour
{
    [SerializeField] Animator interacting;
    bool didInteract;
    // Start is called before the first frame update

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            interacting.SetBool("interactable", true);
            didInteract = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            interacting.SetBool("interactable", false);
            didInteract = false;
        }
    }
}
