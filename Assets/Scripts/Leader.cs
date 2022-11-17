using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leader : MonoBehaviour
{
    private GameObject player;
    GameObject[] enemys;
    GameObject[] ais;

    public int leaderHealth = 30;

    public int totalEnemy = 0;
    public int totalAI = 0;
    
    public int avgHealth;
    public int startTotalHealth;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        enemys = GameObject.FindGameObjectsWithTag("Enemy");
        ais = GameObject.FindGameObjectsWithTag("AI");

        foreach (GameObject enemy in enemys)
        {
            totalEnemy += 1;
            
        }

        foreach (GameObject ai in ais)
        {
            totalAI += 1;
        }
        startTotalHealth = totalEnemy * 10;
    }

    
    void Update()
    {
 
        foreach (GameObject enemy in enemys)
        {
            avgHealth = enemy.GetComponent<Enemy>().health * totalEnemy;

            if (avgHealth <= startTotalHealth / 1.33333333333333f && avgHealth > startTotalHealth / 2 || totalAI == 1)
            {
                enemy.GetComponent<Enemy>().state = Enemy.enumState.Section1;
            }
            
            else if (avgHealth <= startTotalHealth / 2 && avgHealth > startTotalHealth / 3 || totalAI == 2)
            {
                enemy.GetComponent<Enemy>().state = Enemy.enumState.Section2;
            }

            else if (avgHealth <= startTotalHealth / 3 || totalAI == 3)
            {
                enemy.GetComponent<Enemy>().state = Enemy.enumState.Section3;
            }
        }
    }
}
