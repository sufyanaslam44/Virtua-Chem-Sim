using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
public class MainMenu : MonoBehaviour
{

    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LitmusPaper()
    {
        SceneManager.LoadSceneAsync(4);
    }
    public void BackToManu()
    {
        SceneManager.LoadSceneAsync(0);
    }
    public void Titration()
    {
        SceneManager.LoadSceneAsync(2);
    }
    public void ExperimentList()
    {
        SceneManager.LoadSceneAsync(3);
    }
}
