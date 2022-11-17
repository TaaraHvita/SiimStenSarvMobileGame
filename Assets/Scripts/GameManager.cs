using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int Count;
    public bool LevelComplete = false;
    public TextMeshProUGUI EnemyCounter;
    List<EnemyController> enemies = new List<EnemyController>();


    private void OnEnable()
    {
        EnemyController.OnEnemyKilled += EnemyDefeated;
    }

    private void OnDisable()
    {
        EnemyController.OnEnemyKilled -= EnemyDefeated;
    }

    private void Awake()
    {
        enemies = GameObject.FindObjectsOfType<EnemyController>().ToList();
        UpdateEnemiesLeft();

    }

    void EnemyDefeated(EnemyController enemy)
    {
        if(enemies.Remove(enemy));
        UpdateEnemiesLeft();
    }
    void UpdateEnemiesLeft()
    {
        EnemyCounter.text = $"Enemies Left: {enemies.Count}";
        Debug.Log("Enemy Found");
    }

    void Update()
    {
        if (enemies.Count == 0){
            LevelComplete = true;
            EnemyCounter.text = $"Level Complete!";
        }
        LevelComplete = false;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}