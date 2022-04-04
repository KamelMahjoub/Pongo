using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class MatchManager : MonoBehaviour
{
    [Header("Scoreboard Components")]
    [SerializeField]
    private TextMeshProUGUI playerOneScore;
    [SerializeField]
    private TextMeshProUGUI playerTwoScore;
    
    [Header("Match Ball")]
    [SerializeField] 
    private GameObject ball;
    [SerializeField] 
    private Ball ballScript;

    private int playerOnePoints;
    private int playerTwoPoints;

    private int playerOneID =1;

    private float startingXPosition;
    private float startingYPosition;
    

    private void Awake()
    {
        Init();
    }

    private void Start()
    {
        SpawnBall();
    }

    //Initializes the variables/properties
    private void Init()
    {
        playerOnePoints = 0;
        playerTwoPoints = 0;

        startingXPosition = 0;
        startingYPosition = 0;

        DisplayScore();
    }

    //Adds a point to the specified player
    public void AddPoint(int playerNb)
    {
        if (playerNb == playerOneID)
        {
            playerOnePoints++;
        }
        else
        {
            playerTwoPoints++; 
        }
        DisplayScore();
    }

    //Displays the score of player one
    private void DisplayPlayerOneScore()
    {
        playerOneScore.text = "" + playerOnePoints;
    }
    
    //Displays the score of player two
    private void DisplayPlayerTwoScore()
    {
        playerTwoScore.text = "" + playerTwoPoints;
    }

    //Displays both players scores
    private void DisplayScore()
    {
        DisplayPlayerOneScore();
        DisplayPlayerTwoScore();
    }

    //Sets the starting the position that the ball will spawn to
    private Vector2 StartingPosition()
    {
        return new Vector2(startingXPosition, startingYPosition);
    }

    //Spawns the ball at the specified starting position
    public void SpawnBall()
    {
        Instantiate(ball, StartingPosition(), ball.transform.rotation);
    }

  

}
