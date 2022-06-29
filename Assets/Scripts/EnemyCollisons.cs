using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollisons : MonoBehaviour
{
    private EnemyHealth enemyHealth;

    private void Start() 
    {
        enemyHealth = GetComponent<EnemyHealth>();
    }
    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.tag == "PlayerBullet")
        {
            other.gameObject.SetActive(false);
            enemyHealth.ReduceHealthPoints();
            Destroy(other.gameObject);
        }
    }
}
