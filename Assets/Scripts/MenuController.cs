using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuController : MonoBehaviour
{
    [SerializeField] private  TextMeshProUGUI scoreTXT;
    [SerializeField] private  TextMeshProUGUI YouWinLoseTXT;

    private void Start() 
    {
        if( GameManager.Instance == null) return;
        
        scoreTXT.text = "Your Score: " + GameManager.Instance.playerScore.ToString();
        YouWinLoseTXT.text = GameManager.Instance.gameResult;
    }
    public void LoadGame()
    {
        SceneManager.LoadScene("Game");
        
        if (GameManager.Instance == null) return;

        GameManager.Instance.playerScore = 0;
        GameManager.Instance.gameResult = null;
        
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
