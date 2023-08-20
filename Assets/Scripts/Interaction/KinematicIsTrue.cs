using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KinematicIsTrue : MonoBehaviour
{
    [SerializeField] Rigidbody gameobjecyRigidBody;

    void Update()
    {
        gameobjecyRigidBody.isKinematic = false;
    }
}
