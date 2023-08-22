using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    [SerializeField] string nextscene;
    public float duration;
    
    public void GameScene()
    {
        StartCoroutine("Starting");
    }
    IEnumerator Starting()
    {
        float timer = 0;
        while (timer < duration)
        {
            timer += Time.unscaledDeltaTime;
            yield return null;
        }
        Time.timeScale = 1;
        SceneManager.LoadScene(nextscene);
    }

    public void Quit()
    {
        StartCoroutine("Quiting");
    }
    IEnumerator Quiting()
    {
        float timer = 0;
        while (timer < duration)
        {
            timer += Time.unscaledDeltaTime;
            yield return null;
        }
        Application.Quit();
    }
}
