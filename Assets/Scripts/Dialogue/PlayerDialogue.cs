using TMPro;
using UnityEngine;

/// <summary>
/// This class is attached to the player, and is used to detect when the player comes within range for dialogue with an NPC.
/// </summary>
public class PlayerDialogue : MonoBehaviour
{
    [SerializeField][Range(0, 0.5f)] float wordFadeTime = 0.15f;
    [SerializeField][Range(0, 1)] float keyPanelFadeTime = 0.5f;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip line;
    public float KeyPanelFadeTime { get => keyPanelFadeTime; }
    public float WordFadeTime { get => wordFadeTime; }
    public AudioSource AudioSource { get => audioSource; }
    public AudioClip Line { get => line; }
}
