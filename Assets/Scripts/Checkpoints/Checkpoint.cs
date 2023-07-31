using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class represents a checkpoint in the game. It has a list of resetables, and a public static event. When that event is invoked, it calls the ResetObject method in
/// every resetable in its list.
/// </summary>

public class Checkpoint : MonoBehaviour
{
    [SerializeField] List<Resetable> resetables = new();
    public static Vector3 currentCheckpoint = Vector3.zero;
    public static Action ResetGame;

    private void OnEnable()
    {
        ResetGame += ReturnToCheckpoint;
    }

    private void OnDisable()
    {
        ResetGame -= ReturnToCheckpoint;
    }

    void ReturnToCheckpoint()
    {
        if (currentCheckpoint != transform.position) { return; }
        foreach (Resetable resetable in resetables)
        {
            if (resetable != null)
            {
                resetable.ResetObject();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (currentCheckpoint != transform.position && other.gameObject.GetComponent<PlayerMovement>() != null)
        {
            currentCheckpoint = transform.position;
        }
    }
}