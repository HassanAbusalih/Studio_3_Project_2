using UnityEngine;

public class AudioTransition : MonoBehaviour
{
    [SerializeField] AudioSource track1;
    [SerializeField] AudioSource track2;
    [SerializeField] float track1TargetVolume;
    [SerializeField] float track2TargetVolume;
    [SerializeField] float transitionTime;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out AudioFader audioFader))
        {
            audioFader.StartFade(track1, track2, track1TargetVolume, track2TargetVolume, transitionTime);
        }
    }
}
