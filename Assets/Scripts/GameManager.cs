using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    int[] enemiesLeft;
    int _enemy;
    int EnemyLeft;
    public bool LevelComplete = false;
    public TextMeshProUGUI EnemyCounter;

    private void Start()
    {
        foreach (int _enemy in enemiesLeft)
        {
            GameObject.FindGameObjectWithTag("Enemy");
            EnemyLeft++;
            Debug.Log("Enemy Found");
            //SetText
            EnemyCounter.SetText("Enemies left:" + enemiesLeft);

        }    
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

    void LevelCompleted()
    {
        EnemyCounter.SetText("LEVEL COMPLETE! Find Exit!");
    }
}
