using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    GameObject[] Enemy;
    public int EnemyLeft;
    public bool LevelComplete = false;
    public TextMeshProUGUI EnemyCounter;

    private void Start()
    {
        if (GameObject.FindGameObjectWithTag("Enemy"))
        {
            EnemyLeft++;
        }
        else
        {
            EnemyLeft--;
        }

        Enemy = GameObject.FindGameObjectsWithTag("Enemy");

        for (int i = 0; i < 0; i++)
        {
            EnemyLeft++;
        }
    }
    public void Update()
    {

        //SetText
        EnemyCounter.SetText("Enemies left:" + EnemyLeft);

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
