using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIpopup : MonoBehaviour
{
    [SerializeField] Animator interacting;
    [SerializeField] GameObject bubble;
    bool didInteract;
    // Start is called before the first frame update
    private void Start()
    {
        bubble.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            bubble.SetActive(true);
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
            bubble.SetActive(false);
        }
    }
}
