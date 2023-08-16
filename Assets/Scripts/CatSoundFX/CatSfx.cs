using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Audio/CatSfx")]
public class CatSfx : ScriptableObject
{
    [Header("Meow Clips")]
    public AudioClip[] m_MeowClips;

    /// <summary>
    /// Get a random meow clip.
    /// </summary>
    public AudioClip GetRandomMeow()
    {
        if (m_MeowClips.Length == 0)
        {
            return null;
        }

        int randomIndex = Random.Range(0, m_MeowClips.Length);
        return m_MeowClips[randomIndex];
    }
}
