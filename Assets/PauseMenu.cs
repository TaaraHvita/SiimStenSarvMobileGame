using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GamePaused = false;
    public GameObject pauseMenuUI;
    public GameObject GameUI;
    public GameObject PauseButton;

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        GameUI.SetActive(true);
        PauseButton.SetActive(true);
        Time.timeScale = 1f;
        GamePaused = false;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        GameUI.SetActive(false);
        PauseButton.SetActive(false);
        Time.timeScale = 0f;
        GamePaused = true;
    }

    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f;
    }
}
