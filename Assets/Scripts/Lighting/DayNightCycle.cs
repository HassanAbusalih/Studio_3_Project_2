using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    [Header("Settings")]
    [Tooltip("Duration of an hour in real-time seconds.")]
    public float m_HourDurationInSeconds = 60f; // Default: 1 hour is 60 seconds

    private float m_RotationSpeed;

    void Start()
    {
        // Calculate rotation speed based on the specified hour duration
        m_RotationSpeed = 360f / (24f * m_HourDurationInSeconds);
    }

    void Update()
    {
        // Rotate the light (around X axis for this example)
        transform.Rotate(Vector3.right, m_RotationSpeed * Time.deltaTime);
    }
}
