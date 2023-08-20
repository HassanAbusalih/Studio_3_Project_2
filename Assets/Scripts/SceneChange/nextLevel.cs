using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class nextLevel : MonoBehaviour
{
    [SerializeField] string nextLevelName;
    [SerializeField] RawImage fadeImage;
    [SerializeField] float fadeDuration = 1.0f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            
            StartCoroutine(FadeIn());
        }
    }
    IEnumerator FadeIn()
    {
        float elapsedTime = 0.0f;
        Color initialColor = fadeImage.color;

        while (elapsedTime < fadeDuration)
        {
            float normalizedTime = elapsedTime / fadeDuration;
            fadeImage.color = Color.Lerp(initialColor, Color.black, normalizedTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        fadeImage.color = Color.black;
        SceneManager.LoadScene(nextLevelName);
    }
    public void  nextLevelScene()
    {
        SceneManager.LoadScene(nextLevelName);
    }
}
