using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour

{
    [SerializeField] private GameObject bulletPrefab;
    
    private float bulletOffset = .7f;
    private GameObject spawnAtRuntime;
    private GameObject bulletClone;

    private void Start() 
    {
        spawnAtRuntime= GameObject.FindGameObjectWithTag("SpawnAtRuntime");
    }
  
    private void Update()
    {
        Shoot();
    }

    private void Shoot()
    {
        float bulletOffsetPosition = transform.position.y + bulletOffset;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            bulletClone = Instantiate( bulletPrefab,  new Vector3(transform.position.x, bulletOffsetPosition, transform.position.z), Quaternion.identity, spawnAtRuntime.transform);
            Destroy(bulletClone, 2);
        }
    }
}
