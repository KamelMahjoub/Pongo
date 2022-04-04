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
    private GameObject scoreBoard;
    [SerializeField]
    private TextMeshProUGUI playerOneScore;
    [SerializeField]
    private TextMeshProUGUI playerTwoScore;
  
    [Header("Player Components")]
    [SerializeField]
    private GameObject playerOne;
    [SerializeField]
    private GameObject playerTwo;
  
    [Header("Field Components")]
    [SerializeField] 
    private GameObject middleLine;
    
    [Header("Countdown Components")]
    [SerializeField]
    private TextMeshProUGUI startingCountdownText;

    [Header("Match Ball")]
    [SerializeField] 
    private GameObject ball;
    [SerializeField] 
    private Ball ballScript;
    

    private int playerOnePoints;
    private int playerTwoPoints;
    private int playerOneID = 1;
    
    private float startingXPosition;
    private float startingYPosition;
    private float initialCountdown;
    

    private void Awake()
    {
        Init();
        DisableMatchUI();
    }
    

    //Initializes the variables/properties
    private void Init()
    {
        playerOnePoints = 0;
        playerTwoPoints = 0;

        initialCountdown = 3;

        startingXPosition = 0;
        startingYPosition = 0;

        DisplayScore();
    }

    private void Update()
    {
        InitialCountdown();
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

    private void InitialCountdown()
    {
        bool isTimerRunning = true;
        if (isTimerRunning)
        {
            if (initialCountdown > 0)
            {
                startingCountdownText.text = initialCountdown.ToString();
                initialCountdown -= Time.deltaTime;
            }
            else
            {
                startingCountdownText.text = "Pong!";
                initialCountdown = 0;
                isTimerRunning = false;
                EnableMatchUI();
            }
        }
    }

    //Disables the player gameobjects aswell as as the scoreboard and middle line. 
    public void DisableMatchUI()
    {
        playerOne.SetActive(false);
        playerTwo.SetActive(false);
        scoreBoard.SetActive(false);
        middleLine.SetActive(false);
    }
    
    //Enables the player gameobjects aswell as as the scoreboard and middle line. 
    public void EnableMatchUI()
    {
        playerOne.SetActive(true);
        playerTwo.SetActive(true);
        scoreBoard.SetActive(true);
        middleLine.SetActive(true);
    }
    
    

  

}
