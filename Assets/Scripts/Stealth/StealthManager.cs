using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.UI;

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
    [SerializeField] Image stealthIndicator;
    [SerializeField] Image background;
    float currentTime;
    PlayerMovement player;
    bool inArea;

    void Start()
    {
        stealthIndicator.type = Image.Type.Filled;
        player = FindObjectOfType<PlayerMovement>();
        gameObject.layer = 2;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(0, 0, 0.5f, 0.2f);
        BoxCollider chaseCollider = GetComponent<BoxCollider>();
        Gizmos.DrawCube(transform.position, chaseCollider.size);
    }

        void Update()
    {
        if (inArea && CheckForPlayer())
        {
            currentTime += Time.deltaTime;
            if (currentTime > timeForDetection)
            {
                currentTime = timeForDetection;
            }
            if (stealthIndicator != null)
            {
                stealthIndicator.fillAmount = currentTime / timeForDetection;
            }
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
            if (stealthIndicator.enabled)
            {
                stealthIndicator.fillAmount = currentTime / timeForDetection;
            }
        }
    }

    void CatchPlayer()
    {
        // Should probably have an animation here
        currentTime = 0;
        if (stealthIndicator != null)
        {
            stealthIndicator.fillAmount = currentTime / timeForDetection;
        }
        Checkpoint.ResetGame();
    }

    bool CheckForPlayer()
    {
        LayerMask mask = ~((1 << LayerMask.NameToLayer("camera zoom out")) | (1 << LayerMask.NameToLayer("camera zoom in")) | (1 << gameObject.layer));
        foreach (EnemySight enemy in enemies)
        {
            if (enemy.PlayerInSight(player, mask))
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
            if (stealthIndicator != null && background != null)
            {
                stealthIndicator.gameObject.SetActive(true);
                background.gameObject.SetActive(true);
                stealthIndicator.fillAmount = currentTime / timeForDetection;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player.gameObject)
        {
            inArea = false;
            if (stealthIndicator != null && background != null)
            {
                stealthIndicator.gameObject.SetActive(false);
                background.gameObject.SetActive(false);
            }
        }
    }
}
