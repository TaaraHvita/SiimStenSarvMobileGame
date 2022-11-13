using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using TMPro;
using UnityEngine.SceneManagement;

public class DrivingLevelController : MonoBehaviour
{
    public GameObject GameOverMenu;
    public float speed = 2;
    bool GameOver = false;

    
    void Awake()
    {
        Time.timeScale = 1f; //on game start set time scale to 1.
    }

    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }

    public void EndGame()
    {
        if (GameOver == false)
        {
            GameOver = true;
            Debug.Log("Game Over");
            EnableGameOverMenu();
            Time.timeScale = 0f; //pause the simulation
        }
        
    }

    public void EnableGameOverMenu()
    {
        GameOverMenu.SetActive(true);
    }

    public void RestartButton()
    {
        Restart();
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        GameOver = false;
    }
}
