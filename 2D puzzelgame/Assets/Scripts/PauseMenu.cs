using UnityEngine.SceneManagement;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    [SerializeField] KeyCode pauseKey;
    public static bool isPaused;
    private void Start()
    {
        pauseMenu.SetActive(false);
    }
    private void Update()
    {
        if (Input.GetKeyDown(pauseKey))
        {
            if (isPaused)
            {
                Resumegame();
            }
            else
            {
                PauseGame();
            }
        }
    }
    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }
    public void Resumegame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }
    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
