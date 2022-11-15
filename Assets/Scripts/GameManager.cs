using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
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

        Enemy = GameObject.FindGameObjectsWithTag("Enemy");
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
