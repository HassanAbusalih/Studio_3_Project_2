using UnityEngine;

/// <summary>
/// This script is used for the enemies in the game that can detect the player in stealth sequences. 
/// </summary>

public class EnemySight : MonoBehaviour
{
    [SerializeField] float maxAngle = 60;
    
    /// <summary>
    /// Makes a raycast from the enemy's position to the player.
    /// </summary>
    /// <param name="player">The PlayerMovement script attached to the player GameObject.</param>
    /// <returns>True if the raycast hits the player's GameObject, false otherwise.</returns>
    public bool PlayerInSight(PlayerMovement player)
    {
        Vector3 direction = player.transform.position - transform.position;
        //if (Vector3.Angle(transform.forward, direction) > maxAngle)
        //{
          //  return false;
        //}
        RaycastHit hit;
        if (Physics.Raycast(transform.position, direction, out hit))
        {
            if (hit.collider.gameObject == player.gameObject)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        return false;
    }
}
