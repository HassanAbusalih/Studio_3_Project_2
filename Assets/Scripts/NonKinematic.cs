using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NonKinematic : MonoBehaviour
{
    [SerializeField] Rigidbody[] rigidbodies;

    private void Start()
    {
        foreach (var rigidbody in rigidbodies)
        {
            rigidbody.AddComponent<RigidbodyResettable>();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerMovement>() == null) { return; }
        foreach (var rigidbody in rigidbodies)
        {
            rigidbody.isKinematic = false;
        }
    }
}
