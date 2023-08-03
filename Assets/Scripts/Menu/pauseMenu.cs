using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseMenu : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject pausePopUp;

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
        }
    }
    public void Resume()
    {
        Time.timeScale = 1.0f;
        pausePopUp.SetActive(false);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void Exit()
    {
        Application.Quit();
    }
    // Update is called once per frame
}
