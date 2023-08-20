using System.Collections;
using UnityEngine;

public class AudioFader : MonoBehaviour
{
    public void StartFade(AudioSource track1, AudioSource track2, float track1TargetVolume, float track2TargetVolume, float transitionTime)
    {
        StopAllCoroutines();
        StartCoroutine(FadeAudio(track1, track2, track1TargetVolume, track2TargetVolume, transitionTime));
    }
    
    IEnumerator FadeAudio(AudioSource track1, AudioSource track2, float track1TargetVolume, float track2TargetVolume, float transitionTime)
    {
        float time = 0;
        float startVolume1 = track1.volume;
        float startVolume2 = track2.volume;
        while (time < transitionTime)
        {
            time += Time.deltaTime;
            track1.volume = Mathf.Lerp(startVolume1, track1TargetVolume, time / transitionTime);
            track2.volume = Mathf.Lerp(startVolume2, track2TargetVolume, time / transitionTime);
            yield return null;
        }
        track1.volume = track1TargetVolume;
        track2.volume = track2TargetVolume;
    }
}
