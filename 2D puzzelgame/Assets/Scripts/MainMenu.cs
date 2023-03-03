using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void startGame()
    {
        SceneManager.LoadScene("StartCutSceneGame");
        PauseMenu.isPaused = false;


    }
    public void QuitGame()
    {
        Application.Quit();

    }
    public void Tutorial()
    {
        SceneManager.LoadScene("Tutorial");
        PauseMenu.isPaused = false;
    }
}
