using UnityEngine;

public class UIpopup : MonoBehaviour
{
    [SerializeField] Animator interacting;
    [SerializeField] Animator UIpopping;
    [SerializeField] GameObject bubble;
    [SerializeField] bool didInteract;

    private void Start()
    {
        bubble.SetActive(false);
        didInteract = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            didInteract = true;
            interacting.SetBool("interactable", true);
        }
        
    }

    private void Update()
    {
        if (didInteract == true && Input.GetKey(KeyCode.E))
        {
            bubble.SetActive(true);
            UIpopping.SetBool("interactable", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            didInteract = false;
            interacting.SetBool("interactable", false);
            UIpopping.SetBool("interactable", false);
            bubble.SetActive(false);
        }
    }
}
