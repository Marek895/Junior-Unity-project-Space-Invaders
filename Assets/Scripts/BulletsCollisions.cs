using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletsCollisions : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.transform.tag == "EnemyBullet")
        {
            Destroy(this.gameObject);
            Destroy(other.gameObject);
        }
    }
}
