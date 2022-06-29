using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
   [SerializeField] private float moveSpeed = 10f;

    private void Update()
    {
        ProcessPlayerMovement();
    }

    private void ProcessPlayerMovement()
    {
        float input = Input.GetAxis("Horizontal");
        
        float offset = input * moveSpeed * Time.deltaTime;

        float newPosition = transform.position.x + offset;

        float clampedPosition = Mathf.Clamp(newPosition,-6,6 );
        transform.position = new Vector3(clampedPosition,transform.position.y,transform.position.z);
    }

}
