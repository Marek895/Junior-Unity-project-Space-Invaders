using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCounter : MonoBehaviour
{
    private void OnEnable() 
    {
        EnemyHealth.enemyDeath += CountAliveEnemies;
    }

    private void OnDisable() 
    {
        EnemyHealth.enemyDeath -= CountAliveEnemies;
    }

    private void CountAliveEnemies()
    {
        int enemyCount = 0;

        foreach (Transform enemy in transform)
        {
            if (enemy.gameObject.activeSelf)
            {
                enemyCount++;
            }

        }

        if (enemyCount <= 0)
        {
            GameManager.Instance.PlayerWin();
        }
        
    }

}
