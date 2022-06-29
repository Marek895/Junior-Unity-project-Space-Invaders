using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public static event Action enemyDeath;
    [SerializeField] private int maxHealthPoints = 2;
    [SerializeField] private int scoreForKill = 50;
  
    private int currentHealtPoints;
    private bool isDead = false;
   
    private void Start()
    {
        currentHealtPoints = maxHealthPoints;
    }

    public void ReduceHealthPoints()
    {
        currentHealtPoints--;
        if(currentHealtPoints <= 0 && !isDead )
        {
            OnEnemyDeath();
        }
    }

    private void OnEnemyDeath()
    {   
        isDead = true;
        gameObject.SetActive(false);
        GameManager.Instance.playerScore += scoreForKill;
        enemyDeath?.Invoke();
    }

}
