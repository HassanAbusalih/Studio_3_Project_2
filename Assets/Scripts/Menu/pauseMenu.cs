using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseMenu : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject pausePopUp;
    [SerializeField] AudioSource bgSound;
    public float duration;
    public string nextscene;

    private void Start()
    {
        pausePopUp.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Time.timeScale = 0f;
            pausePopUp.SetActive(true);
            bgSound.volume = 0f;
        }
    }
    public void Close()
    {
        StartCoroutine(Closing());
        //pauseMenuPanel.SetActive(false);
        //Time.timeScale = 1;
    }
    IEnumerator Closing()
    {
        float timer = 0;
        while (timer < duration)
        {
            timer += Time.unscaledDeltaTime;
            yield return null;
        }
        Time.timeScale = 1;
        pausePopUp.SetActive(false);
    }

    public void MainMenu()
    {
        StartCoroutine("MainMenuScene");
        //Time.timeScale = 1;
        //SceneManager.LoadScene("Main Menu");
    }
    IEnumerator MainMenuScene()
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
    // Update is called once per frame
}
