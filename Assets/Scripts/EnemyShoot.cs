using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
   [SerializeField] private GameObject bulletPrefab;
   [SerializeField] private LayerMask layerMask;
   [SerializeField] private float fireRateMin = 2.5f;
   [SerializeField] private float fireRateMax = 10f;
    
    private float bulletOffset = -.5f;
    private float fireRate;
    private float nextFire;
    private GameObject spawnAtRuntime;
    private GameObject bulletClone;
    private RaycastHit2D raycastHit2D;

    private void OnEnable() 
    {
        fireRate = Random.Range(fireRateMin,fireRateMax);
        fireRate += Time.time;
    }
    private void Start() 
    {
        spawnAtRuntime = GameObject.FindGameObjectWithTag("SpawnAtRuntime");
    }
  
    private void Update()
    {
        CHeckForAnAllyInFront();
        
        if (Time.time >= fireRate && raycastHit2D.collider == null  )
        {
            Shoot();
            
        }
    }
    

    private void CHeckForAnAllyInFront()
    {
        raycastHit2D = Physics2D.Raycast(transform.position, -Vector2.up,Mathf.Infinity, layerMask);
    }

    private void Shoot()
    {
        fireRate = Random.Range(fireRateMin,fireRateMax);
       
        if (Time.time>=nextFire )
        {
            float bulletOffsetPosition = transform.position.y + bulletOffset;
            bulletClone = Instantiate( bulletPrefab,  new Vector3(transform.position.x, bulletOffsetPosition, transform.position.z), Quaternion.identity, spawnAtRuntime.transform);
            nextFire = Time.time + fireRate;
            Destroy(bulletClone, 5f);
        }
    }
}
