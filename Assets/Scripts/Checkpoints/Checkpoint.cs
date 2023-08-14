using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class represents a checkpoint in the game. It has a list of resettables, and a public static event. When that event is invoked, it calls the ResetObject method in
/// every resettable in its list.
/// </summary>

public class Checkpoint : MonoBehaviour
{
    [SerializeField] List<Resettable> resettables = new();
    public static Vector3 CurrentCheckpoint { get; private set; } = Vector3.zero;
    public static Action ResetGame;

    private void OnEnable()
    {
        Resettable player = FindObjectOfType<PlayerMovement>();
        if (!resettables.Contains(player))
        {
            resettables.Add(player);
        }
        ResetGame += ReturnToCheckpoint;
    }

    private void OnDisable()
    {
        ResetGame -= ReturnToCheckpoint;
    }

    void ReturnToCheckpoint()
    {
        if (CurrentCheckpoint != transform.position) { return; }
        foreach (Resettable resettable in resettables)
        {
            if (resettable != null)
            {
                resettable.ResetObject();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (CurrentCheckpoint != transform.position && other.gameObject.GetComponent<PlayerMovement>() != null)
        {
            CurrentCheckpoint = transform.position;
        }
    }
}