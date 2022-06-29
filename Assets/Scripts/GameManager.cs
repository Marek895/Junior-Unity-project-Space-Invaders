using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {get; private set;}

    public int playerScore;
    public string gameResult;
    
    private void Awake() 
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        else
        {
            Destroy(gameObject);
        }
    }


    public void PlayerWin()
    {
        gameResult = "You Win";
        SceneManager.LoadScene("GameOver");
    }

    public void PlayerLose()
    {
        gameResult = "You Lose";
        SceneManager.LoadScene("GameOver");
    }
    

}
