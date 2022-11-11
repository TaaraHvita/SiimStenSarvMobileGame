using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    GameObject[] enemy;
    public int EnemyLeft;
    public bool LevelComplete = false;
    public TextMeshProUGUI EnemyCounter;

    private void Start()
    {
        
    }
    public void Update()
    {
        enemy = GameObject.FindGameObjectsWithTag("Enemy");
        //SetText
        EnemyCounter.SetText("Enemies left:" + EnemyLeft);

        if (EnemyLeft <= 0)
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
