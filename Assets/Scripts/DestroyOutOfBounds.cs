using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    
    [Header("Manager")]
    [SerializeField]
    private MatchManager _matchManager;
    
    private float topBound;
    private float bottomBound;
    private float leftBound;
    private float rightBound;
    
    private int playerOneID;
    private int playerTwoID;

    private void Awake()
    {
        Init();
    }

    private void Update()
    {
        DestroyBall();
    }

    //Initializes the variables/properties
    private void Init()
    {
        _matchManager = GameObject.Find("MatchManager").GetComponent<MatchManager>();
        topBound = 8f;
        bottomBound = -8f;
        leftBound = -10f;
        rightBound = 10;
        
        playerOneID = 1;
        playerTwoID = 2;
    }
    //Checks if the position of the ball is outside the specified values
    private void DestroyBall()
    {
        Vector2 ballPosition = transform.position;

        if (ballPosition.x < leftBound || ballPosition.x > rightBound|| ballPosition.y > topBound || ballPosition.y < bottomBound)
        {
            if (ballPosition.x < leftBound)
            {
                _matchManager.AddPoint(playerTwoID);
            }
            else
            if (ballPosition.x > rightBound)
            {
                _matchManager.AddPoint(playerOneID);
            }
            Destroy(gameObject);
            _matchManager.SpawnBall();
        }
    }

}
