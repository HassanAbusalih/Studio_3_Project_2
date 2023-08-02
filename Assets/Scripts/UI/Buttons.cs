using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    [SerializeField] string nextscene;
   
    public void NextScene()
    {
        SceneManager.LoadScene(nextscene);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
