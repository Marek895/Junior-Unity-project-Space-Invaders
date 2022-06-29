using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class UiManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreTXT;
    [SerializeField] private TextMeshProUGUI livesLeftTXT;
    private PlayerController playerController;
    
    private void OnEnable() 
    {
        EnemyHealth.enemyDeath += DisplayScore;
        PlayerController.livesReduce += DisplayLivesLeft;
    }

    private void OnDisable() 
    {
        EnemyHealth.enemyDeath -= DisplayScore;
        PlayerController.livesReduce -= DisplayLivesLeft;
    }
    private void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
        DisplayScore();
        DisplayLivesLeft(playerController.LivesNumber);
    }


    private void DisplayScore()
    {
        scoreTXT.text = "Score: " + GameManager.Instance.playerScore.ToString();
    }
    private void DisplayLivesLeft(int lives)
    {
        livesLeftTXT.text = "Lives left: " + lives.ToString();
    }

}
