using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script manages the stealth sequences in the game. A timer ticks up when the player is seen by an enemy, and ticks down when they are not in sight.
/// If the player is caught, the game is reset back to the last checkpoint. 
/// Stealth sequences start when the player enters the trigger collider, and stop when they exit. Due to this, the GameObject's
/// trigger collider should be large enough to encompass the entire stealth area. It is possible to have multiple StealthManagers, however.
/// </summary>

public class StealthManager : MonoBehaviour
{
    [SerializeField] List<EnemySight> enemies = new();
    [SerializeField] float timeForDetection = 5;
    float currentTime;
    PlayerMovement player;
    bool inArea;

    void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
    }


    void Update()
    {
        if (inArea && CheckForPlayer())
        {
            currentTime += Time.deltaTime;
            if (currentTime >= timeForDetection)
            {
                CatchPlayer();
            }
        }
        else
        {
            currentTime -= Time.deltaTime;
            if (currentTime < 0)
            {
                currentTime = 0;
            }
        }
    }

    void CatchPlayer()
    {
        // Should probably have an animation here
        Checkpoint.ResetGame();
    }

    bool CheckForPlayer()
    {
        foreach (EnemySight enemy in enemies)
        {
            if (enemy.PlayerInSight(player))
            {
                return true;
            }
        }
        return false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player.gameObject)
        {
            inArea = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player.gameObject)
        {
            inArea = false;
        }
    }
}
