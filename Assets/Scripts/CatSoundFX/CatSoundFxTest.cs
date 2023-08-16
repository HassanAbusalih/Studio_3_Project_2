using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatSoundsEffectsTest : MonoBehaviour
{
    [SerializeField]
    private CatSfx m_CatSfxSO = null;
    [SerializeField]
    private AudioSource m_AudioSource = null;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayRandomMeow();
        }
    }

    public void PlayRandomMeow()
    {
        AudioClip clip = m_CatSfxSO.GetRandomMeow();
        if (clip && m_CatSfxSO)
        {
            m_AudioSource.PlayOneShot(clip);
        }
    }
}
