using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject[] enemiesLeft;
    //int _enemy;
    int EnemyLeft;
    public bool LevelComplete = false;
    public TextMeshProUGUI EnemyCounter;

    private void Start()
    {
        enemyCounter();
    }


    public void Update()
    {
        if (EnemyLeft == 0)
        {
            LevelComplete = true;
            LevelCompleted();
        }
        else LevelComplete = false;
    }

    public void enemyCounter()
    {
        enemiesLeft = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject _enemy in enemiesLeft)
        {
            EnemyLeft++;
            Debug.Log("Enemy Found");
        }
        EnemyCounter.SetText("Enemies left:" + EnemyLeft);
    }


    void LevelCompleted()
    {
        EnemyCounter.SetText("LEVEL COMPLETE! Find Exit!");
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}