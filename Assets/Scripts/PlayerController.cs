using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static event Action<int> livesReduce;

    [SerializeField] private int livesNumber = 3;
    
    public int LivesNumber {get { return livesNumber; }}
    private int livesLeft;
    
    private void Start() 
    {
        livesLeft = livesNumber;
    }
    private void OnTriggerEnter2D(Collider2D other)
        
    
    {
        if(other.gameObject.tag == "EnemyBullet")
        { 
            Destroy(other.gameObject);
            livesLeft--;
            livesReduce?.Invoke(livesLeft);
        }

            
        if (livesLeft <=0)
        {
            GameManager.Instance.PlayerLose();
        }
    }

}
