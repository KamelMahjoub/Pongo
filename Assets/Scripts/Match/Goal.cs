using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    [Header("Manager")]
    [SerializeField]
    private MatchManager matchManager;

    private int playerOneID;
    private int playerTwoID;

    private string playerOneGoal;

    private void Awake()
    {
        Init();
    }


    //Initializes the variables/properties
    private void Init()
    {
        playerOneID = 1;
        playerTwoID = 2;
        playerOneGoal = "Player1Goal";
    }

    //Whenever the ball collides with a goal, adds a point to the scorer and spawns another ball
    private void OnTriggerEnter2D(Collider2D col)
    {
        matchManager.AddPoint(gameObject.name == playerOneGoal ? playerTwoID : playerOneID);
        
        Destroy(col.gameObject);
        
        if (matchManager.IsGoalLimited()&& matchManager.HasReachedGoalLimit())
        {
            matchManager.CheckResult();
        }
        else
        {
            if (col.tag.Equals("Ball"))
            {
                matchManager.SpawnBall(); 
            }
        }
    }
}
