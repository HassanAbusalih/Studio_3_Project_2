using UnityEngine;

/// <summary>
/// This script inherits from Interactable, and sets a bool in the animator to be true when its Interact method is called. The name of the bool is a serialized field.
/// </summary>

public class AnimatedInteractable : Interactable
{
    Animator animator;
    [SerializeField] string animatorBoolName;

    private void Start()
    {
        interactionHandler = FindObjectOfType<InteractionHandler>();
        if (!TryGetComponent(out animator))
        {
            Debug.LogError($"{gameObject.name} has no Animator.");
        }
        if (animatorBoolName == null) 
        {
            Debug.LogError("No bool name.");
        }
    }

    public override void Interact()
    {
        if (animator == null || animatorBoolName == null) { return; }
        animator.SetBool(animatorBoolName, true);
    }
}
