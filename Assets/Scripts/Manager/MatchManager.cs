using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class MatchManager : MonoBehaviour
{
    [Header("Match UI")] [SerializeField] 
    private MatchUIManager _matchUIManager;
    
    [Header("Match Ball")] [SerializeField]
    private GameObject ball;

    [SerializeField] 
    private Ball ballScript;

    public int playerOnePoints { get; set; }
    public int playerTwoPoints { get; set; }

    private int playerOneID;
    private int playerTwoID;
    
    private float startingXPosition;
    private float startingYPosition;
    private float initialCountdown;


    private void Awake()
    {
        Init(); 
        _matchUIManager.DisableMatchUI();
    }

    private void Start()
    {
        if (DataManager.Instance != null)
        {
            Invoke(nameof(SpawnBall),4f);
            Invoke(nameof(DisplayMatchUi), 3f);
        }
    }

    private void Update()
    {
        StartingCountdown();
    }


    //Initializes the variables/properties
    private void Init()
    {
        _matchUIManager = GetComponent<MatchUIManager>();

        playerOnePoints = 0;
        playerTwoPoints = 0;

        playerOneID = 1;
        playerTwoID = 2;
        
        initialCountdown = 4;

        startingXPosition = 0;
        startingYPosition = 0;
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
        _matchUIManager.DisplayScore();
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

    private void StartingCountdown()
    {
        bool isTimerRunning = true;

        if (isTimerRunning)
        {
            if (initialCountdown > 1)
            {
                _matchUIManager.ChangeCountdownText(GetSeconds(initialCountdown).ToString());
                initialCountdown -= Time.deltaTime;
            }
            else
            {
                _matchUIManager.ChangeCountdownText("Pong!");
                isTimerRunning = false;
                initialCountdown = 1;
                Invoke(nameof(HideCountdownText),0.7f);
            }
        }
    }
    
    private void HideCountdownText()
    {
        _matchUIManager.HideCountdownText();
    }

    private void DisplayMatchUi()
    {
        _matchUIManager.EnableMatchUI();
    }
   
    private int GetSeconds(float time)
    {
        return Mathf.FloorToInt(time % 60);
    }

    public void CheckResult()
    {
        if (IsGoalLimited())
        {
          CheckGoalModeResult();
        }
        else
        {
           CheckTimeModeResult(); 
        }
    }

    private void CheckGoalModeResult()
    {
        if (playerOnePoints == GetGoalsLimit())
        {
            DisplayResult(playerOneID);
        }
        else
        if (playerTwoPoints == GetGoalsLimit())
        {
            DisplayResult(playerTwoID);
        }
    }

    private void CheckTimeModeResult()
    {
        int drawID = 0;

        if (playerOnePoints == playerTwoPoints)
        {
            DisplayResult(drawID);
        }
        else if (playerOnePoints > playerTwoPoints)
        {
            DisplayResult(playerOneID);
        }
        else
        {
            DisplayResult(playerTwoID);
        }
    }
    
    
    private void DisplayResult(int winnerID)
    {
        _matchUIManager.DisableMatchUI();
        _matchUIManager.DisplayPostMatchCanvas();
        if (winnerID == 0)
        {
            _matchUIManager.SetGameResult("Draw!");
        }
        else
        {
            _matchUIManager.SetGameResult("Player "+winnerID+" Wins!");
        }
    }

    private int GetGoalsLimit()
    {
        return DataManager.Instance.goals;
    }
    
    public bool IsGoalLimited()
    { 
        string goalMode = "GoalLimited";
        return DataManager.Instance.matchMode.Equals(goalMode);
    }
    
    public bool HasReachedGoalLimit()
    {
        return playerOnePoints == GetGoalsLimit() || playerTwoPoints == GetGoalsLimit();
    }

  
        



}