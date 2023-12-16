using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This class handles detecting if a player is nearby, and if they are and the player presses a button, it displays the dialogue that the NPC has. 
/// </summary>

public class NPCDialogue : MonoBehaviour
{
    [SerializeField] Image keyPressPanel;
    [SerializeField] GameObject dialogueUI;
    [SerializeField] TextMeshProUGUI dialogueSpeaker;
    [SerializeField] TextMeshProUGUI dialogueLine;
    ImagePanelInfo imagePanelInfo;
    DialogueState dialogueState = DialogueState.NotInRange;
    PlayerDialogue playerDialogue;
    Queue<string> dialogueTextQueue = new();
    Queue<string> dialogueSpeakerQueue = new();
    [SerializeField] DialogueData dialogue;
    Coroutine currentLine;
    public static event Action dialogueStarted;
    public static event Action dialogueEnded;
    float cd;

    private void Start()
    {
        TextMeshProUGUI text = keyPressPanel.GetComponentInChildren<TextMeshProUGUI>();
        imagePanelInfo = new ImagePanelInfo(keyPressPanel.color.a, text, text.color.a);
        playerDialogue = FindObjectOfType<PlayerDialogue>();
    }

    void Update()
    {
        if (dialogueState == DialogueState.NotInRange)
        {
            dialogueUI.SetActive(false);
            dialogueTextQueue.Clear();
            dialogueSpeakerQueue.Clear();
            return;
        }
        cd += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            keyPressPanel.gameObject.SetActive(false);
            if (cd < 0.1f)
            {
                return;
            }
            cd = 0;
            CheckState();
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            EndDialogue();
        }
    }

    void CheckState()
    {
        switch (dialogueState)
        {
            case DialogueState.InRange:
                dialogueStarted?.Invoke();
                dialogueUI.SetActive(true);
                StartDialogue(dialogue);
                break;
            
            case DialogueState.InDialogue:
                if (dialogueTextQueue.Count == 0)
                {
                    EndDialogue();
                    break;
                }
                else
                {
                    if (currentLine != null)
                    {
                        StopCoroutine(currentLine);
                        currentLine = null;
                        dialogueLine.text = dialogueTextQueue.Dequeue();
                    }
                    else
                    {
                        NextLine();
                    }
                }
                break;
        }
    }

    private void EndDialogue()
    {
        if (dialogueTextQueue.Count > 0)
        {
            dialogueSpeakerQueue.Clear();
            dialogueTextQueue.Clear();
        }
        dialogueUI.SetActive(false);
        keyPressPanel.gameObject.SetActive(false);
        dialogueState = DialogueState.InRange;
        dialogueEnded?.Invoke();
    }

    void StartDialogue(DialogueData dialogueData)
    {
        foreach (var line in dialogueData.Lines)
        {
            dialogueSpeakerQueue.Enqueue(line.Speaker);
            dialogueTextQueue.Enqueue(line.Text);
        }
        NextLine();
        dialogueState = DialogueState.InDialogue;
    }

    private IEnumerator AnimateLine(string line, TextMeshProUGUI dialogueLine, float duration)
    {
        if (playerDialogue.AudioSource != null)
        {
            playerDialogue.AudioSource.clip = playerDialogue.Line;
        }
        string[] words = line.Split();
        string currentText = "";
        foreach(string word in words)
        {
            float time = 0;
            if (playerDialogue.Line != null)
            {
                playerDialogue.AudioSource.Play();
            }
            while (time < duration)
            {
                time += Time.unscaledDeltaTime;
                float t = time / duration;
                int alpha = Mathf.RoundToInt(Mathf.Lerp(0, 255, t));
                string hexAlpha = alpha.ToString("X2");
                dialogueLine.text = currentText + $"<alpha=#{hexAlpha}>{word}";
                yield return null;
            }
            currentText += word + " ";
        }
        dialogueLine.text = dialogueTextQueue.Dequeue();
        currentLine = null;
    }

    private void NextLine()
    {
        if (dialogueTextQueue.TryPeek(out string result))
        {
            dialogueSpeaker.text = dialogueSpeakerQueue.Dequeue();
            if (currentLine != null)
            {
                StopCoroutine(currentLine);
            }
            currentLine = StartCoroutine(AnimateLine(result, dialogueLine, playerDialogue.WordFadeTime));
        }
    }

    IEnumerator FadePanel(Image panel, float duration, bool fadeIn)
    {
        TextMeshProUGUI text = panel.GetComponentInChildren<TextMeshProUGUI>();

        float time = 0;
        float startAlpha = fadeIn ? 0 : imagePanelInfo.imageAlpha;
        float endAlpha = fadeIn ? imagePanelInfo.imageAlpha : 0;
        float textStartAlpha = fadeIn ? 0 : imagePanelInfo.textAlpha;
        float textEndAlpha = fadeIn ? imagePanelInfo.textAlpha : 0;

        while (time < duration)
        {
            time += Time.unscaledDeltaTime;
            float t = time / duration;
            float imageAlpha = Mathf.Lerp(startAlpha, endAlpha, t);
            float textAlpha = Mathf.Lerp(textStartAlpha, textEndAlpha, t);

            panel.color = new Color(panel.color.r, panel.color.g, panel.color.b, imageAlpha);
            text.color = new Color(text.color.r, text.color.g, text.color.b, textAlpha);

            yield return null;
        }
        panel.color = new Color(panel.color.r, panel.color.g, panel.color.b, endAlpha);
        text.color = new Color(text.color.r, text.color.g, text.color.b, textEndAlpha);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out PlayerDialogue _))
        {
            dialogueState = DialogueState.InRange;
            if (!keyPressPanel.gameObject.activeSelf)
            {
                keyPressPanel.gameObject.SetActive(true);
            }
            StartCoroutine(FadePanel(keyPressPanel, playerDialogue.KeyPanelFadeTime, true));
            Debug.Log("Player in range");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent(out PlayerDialogue _))
        {
            dialogueState = DialogueState.NotInRange;
            if (keyPressPanel.color.a > 0)
            {
                StartCoroutine(FadePanel(keyPressPanel, playerDialogue.KeyPanelFadeTime, false));
            }
            Debug.Log("Player out of range");
        }
    }
}

public enum DialogueState
{
    NotInRange,
    InRange,
    InDialogue,
}

public class ImagePanelInfo
{
    public float imageAlpha;
    public TextMeshProUGUI text;
    public float textAlpha;
    public ImagePanelInfo(float imageAlpha, TextMeshProUGUI text, float textAlpha)
    {
        this.text = text;
        this.imageAlpha = imageAlpha;
        this.textAlpha = textAlpha;
    }
}