using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class MatchManager : MonoBehaviour
{
    [Header("MATCH UI")] [SerializeField] 
    private MatchUIManager matchUIManager;
    
    [Header("MATCH BALL")] [SerializeField]
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
    private float initialCountdownLimit;
    
    private bool isCountdownRunning;
    

    private void Start()
    {
        if (DataManager.Instance != null)
        {
            Init(); 
            matchUIManager.DisableMatchUI();
        }
    }

    private void Update()
    {
        StartingCountdown();
        PauseGame();
    }


    //Initializes the variables/properties
    private void Init()
    {
        matchUIManager = GetComponent<MatchUIManager>();

        playerOnePoints = 0;
        playerTwoPoints = 0;

        playerOneID = 1;
        playerTwoID = 2;
        
        initialCountdown = 4;
        initialCountdownLimit = 1;

        startingXPosition = 0;
        startingYPosition = 0;

        isCountdownRunning = true;
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
        matchUIManager.DisplayScore();
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
        if (isCountdownRunning)
        {
            if (initialCountdown < initialCountdownLimit)
            {
                DisplayMatchUi();
                matchUIManager.ChangeCountdownText("Pong!");
                Invoke(nameof(HideCountdownText),0.7f);
                initialCountdown = initialCountdownLimit;
                Invoke(nameof(SpawnBall),1f);
                isCountdownRunning = false;
            }
            else
            {
                matchUIManager.ChangeCountdownText(GetSeconds(initialCountdown).ToString());
                initialCountdown -= Time.deltaTime;
            }
        }
    }
    
    private void HideCountdownText()
    {
        matchUIManager.HideCountdownText();
    }
    
    private void DisplayMatchUi()
    {
        matchUIManager.EnableMatchUI();
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
        matchUIManager.DisableMatchUI();
        matchUIManager.DisplayPostMatchCanvas();
        if (winnerID == 0)
        {
            matchUIManager.SetGameResult("Draw!");
        }
        else
        {
            matchUIManager.SetGameResult("Player "+winnerID+" Wins!");
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

    private void PauseGame()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            matchUIManager.EnablePauseMenu();
            Time.timeScale = 0;

            if (!isCountdownRunning)
            {
                matchUIManager.DisableLine();
            }
        }
    }

    public void ResumeGame()
    {
        matchUIManager.DisablePauseMenu();
        Time.timeScale = 1;
        if (!isCountdownRunning)
        {
            matchUIManager.EnabelLine();
        }
    }

    public void CheckTimescale()
    {
        if (Time.timeScale < 1)
            Time.timeScale = 1;
    }
    
    

  
        



}