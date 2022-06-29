using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float nextMoveDownTime = 3f;
    [SerializeField] private float moveDownDistance = .7f;
    [SerializeField] private float moveSideToSideDistance = .5f;
    [SerializeField] private float firstMoveDownDelay = 3f;
    [SerializeField] private float distanceBetweenPlayerForEnemyToWin = 1.5f;
    private bool isMovingLeft = false;
    private float xValueToMoveRight;
    private float xValueToMoveLeft;
    private Vector2 rightSideDestinaton;
    private Vector2 leftSideDestination;
    private float currentMovingRate;

    private PlayerMover player;

    private void OnEnable() 
    {
        firstMoveDownDelay += Time.time;
    }
    private void Start() 
    {
        xValueToMoveRight = transform.position.x+moveSideToSideDistance;
        xValueToMoveLeft = transform.position.x-moveSideToSideDistance;

        player = FindObjectOfType<PlayerMover>();
    }
    private void Update()
    {
        DistanceCheck();
        MoveSideToSide();
        if(Time.time >=firstMoveDownDelay )
        {
            MoveDown();
        }
    }

    

    private void DistanceCheck()
    {
        if (Vector2.Distance(transform.position, rightSideDestinaton) <= 0.1)
        {
            isMovingLeft = true;
        }

        else if (Vector2.Distance(transform.position, leftSideDestination) <= 0.1)
        {
            isMovingLeft = false;
        }
    }
    private void MoveSideToSide()
    {
        rightSideDestinaton = new Vector2(xValueToMoveRight, transform.position.y);
        leftSideDestination = new Vector2(xValueToMoveLeft, transform.position.y);

        if(isMovingLeft)
        {
            transform.position = Vector2.Lerp(transform.position,leftSideDestination  , Time.deltaTime);
        }

        else
        {
            transform.position = Vector2.Lerp(transform.position,rightSideDestinaton  , Time.deltaTime);
        }
    }

    private void MoveDown()
    {
        if (Time.time >= currentMovingRate)
        {
            transform.Translate(0, -moveDownDistance, 0);
            currentMovingRate = Time.time + nextMoveDownTime;
        }

        if (transform.position.y <= (player.transform.position.y + distanceBetweenPlayerForEnemyToWin))
        {
            GameManager.Instance.PlayerLose();
        }
            
    }
}
