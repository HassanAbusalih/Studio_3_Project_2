using UnityEngine;

/// <summary>
/// This script represents the environmental hazards in the game. When the player enters its trigger collider, the game is reset.
/// </summary>
public class ResetTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerMovement>() != null && enabled)
        {
            // Implement fading in and out at some point
            Checkpoint.ResetGame.Invoke();
        }
    }
}
