using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void startGame()
    {
        SceneManager.LoadScene("StartCutSceneGame");
        


    }
    public void QuitGame()
    {
        Application.Quit();

    }
    public void Tutorial()
    {
        SceneManager.LoadScene("Tutorial");
        
    }
}
