using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletsMovement : MonoBehaviour
{
    [SerializeField] private float bulletSpeed = 10f;
    void Update()
    {
        if(this.tag == "PlayerBullet" )
        {
            MoveBullet(bulletSpeed);
        }

        else
        {
            MoveBullet(-bulletSpeed);
        }
        
    }

    private void MoveBullet(float bulletSpeed)
    {
        transform.Translate(0, bulletSpeed * Time.deltaTime, 0);
    }
}
