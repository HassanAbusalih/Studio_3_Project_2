using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    [SerializeField] string nextscene;
    public float duration;
   
    

    public void GameScene()
    {
        StartCoroutine("Starting");
        //SceneManager.LoadScene("Main");
        //Time.timeScale = 1;
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
        //Application.Quit();
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
