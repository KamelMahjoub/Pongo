using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class MatchManager : MonoBehaviour
{
    [Header("MATCH UI")] 
    [SerializeField] 
    private MatchUIManager matchUIManager;
    
    [Header("MATCH BALL")] 
    [SerializeField]
    private GameObject ball;

    [Header("SCRIPTS")]
    [SerializeField] 
    private Ball ballScript;
    [SerializeField] 
    private Player player2Script;
    [SerializeField] 
    private Bot botScript;
    [SerializeField]
    private PowerupManager powerupScript;
    
    [Header("POWERUP MANAGER")]
    [SerializeField] 
    private GameObject powerupManager ;
    
    
    public int playerOnePoints { get; set; }
    public int playerTwoPoints { get; set; }
    
    public bool isGamePaused { get; set; }

    private int playerOneID;
    private int playerTwoID;
    
    private float startingXPosition;
    private float startingYPosition;
    private float initialCountdown;
    private float initialCountdownLimit;
    private float timeLimit;
    
    private bool isCountdownRunning;
    private bool isTimerRunning;
    
    private void Start()
    {
        if (DataManager.Instance != null)
        {
            Init(); 
            matchUIManager.DisableMatchUI();
            Invoke(nameof(SetGameMode),2.8f);
        }
    }

    private void Update()
    {
        StartingCountdown();
        PauseGame();
        
        if (isTimerRunning)
        {
            UpdateTime();
        }
    }


    //Initializes the variables/properties.
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
        isTimerRunning = false;
        isGamePaused = false;
        
        SetPlayerTwo();
        SetPowerups();
    }
    
    //Adds a point to the specified player.
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
    
    //Sets the starting the position that the ball will spawn to.
    public Vector2 StartingPosition()
    {
        return new Vector2(startingXPosition, startingYPosition);
    }

    //Spawns the ball at the specified starting position.
    public void SpawnBall()
    {
        Instantiate(ball, StartingPosition(), ball.transform.rotation);
    }
    
    //Plays a countdown at the start of the match.
    private void StartingCountdown()
    {
        if (isCountdownRunning)
        {
            if (initialCountdown < initialCountdownLimit)
            {
                matchUIManager.EnableMatchUI();
                matchUIManager.ChangeCountdownText("Pong!");
                initialCountdown = initialCountdownLimit;
                isCountdownRunning = false;
                Invoke(nameof(HideCountdownText),0.7f);
                Invoke(nameof(SpawnBall),1f);
            }
            else
            {
                matchUIManager.ChangeCountdownText(GetSeconds(initialCountdown).ToString());
                initialCountdown -= Time.deltaTime;
            }
        }
    }

    //Hides the initial countdown text.
    private void HideCountdownText()
    {
        matchUIManager.HideCountdownText();
    }
    
    //Returns the number of seconds of a given time.
    private int GetSeconds(float time)
    {
        return Mathf.FloorToInt(time % 60);
    }
    
    //Returns the number of minutes of a given time.
    private int GetMinutes(float time)
    {
        return Mathf.FloorToInt(time / 60);
    }
    
    //Gets the goal limit selected in the match menu.
    private int GetGoalsLimit()
    {
        return DataManager.Instance.goals;
    }
    
    //Checks if the mode is goal limited.
    public bool IsGoalLimited()
    { 
        string goalMode = "GoalLimited";
        return DataManager.Instance.matchMode.Equals(goalMode);
    }
    
    //Checks if any of the players has reached the goal limit.
    public bool HasReachedGoalLimit()
    {
        return playerOnePoints == GetGoalsLimit() || playerTwoPoints == GetGoalsLimit();
    }

    //Checks if one of the player has reached the goal limit.
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

    //Checks the result after the timer reaches 0.
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
    
    //Calls the appropriate check result method depending on the match type.
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
    
    //Displays the match result.
    private void DisplayResult(int winnerID)
    {
        matchUIManager.DisableMatchUI();
        matchUIManager.DisplayPostMatchCanvas();
        DestroyBall();
        DestroyPowerup();
        if (winnerID == 0)
        {
            matchUIManager.SetGameResult("Draw!");
        }
        else
        {
            matchUIManager.SetGameResult("Player "+winnerID+" Wins!");
        }
    }

    //Pause the game whe the player uses the "Escape" button.
    private void PauseGame()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            matchUIManager.EnablePauseMenu();
            Time.timeScale = 0;
            isGamePaused = true;

            if (!isCountdownRunning)
            {
                matchUIManager.DisableLine();
            }
            else
            {
                HideCountdownText();
            }
        }
    }

    //Resumes the game.
    public void ResumeGame()
    {
        matchUIManager.DisablePauseMenu();
        UnfreezeGame();
        isGamePaused = false;
        if (!isCountdownRunning)
        {
            matchUIManager.EnableLine();
        }
        else
        {
            matchUIManager.ShowCountdownText();
        }
    }
    
    //Sets the selected game mode on the match interface.
    private void SetGameMode()
    {
        if (IsGoalLimited())
        {
            string mode = "First to "+GetGoalsLimit();
            matchUIManager.SetGameModeText(mode);
        }
        else
        {
            timeLimit = GetTime();
            isTimerRunning = true;
        }
    }
    //Freezes the game time.
    private void FreezeGame()
    {
        Time.timeScale = 0;
        isGamePaused = true;
    }

    //Unfreezes the game time.
    public void UnfreezeGame()
    {
        Time.timeScale = 1;
        isGamePaused = false;
    }

    //Returns the time selected in the match menu.
    private float GetTime()
    {
        int nbSeconds = 60;
        return DataManager.Instance.timeLimit * nbSeconds;
    }
    
    //Checks if the time has ran out , else time will go down one second at a time.
    private void UpdateTime()
    {
        if (timeLimit < 1)
        {
            isTimerRunning = false;
            CheckResult();
        }
        else
        {
            matchUIManager.SetGameModeText(GetMinutes(timeLimit)+" : "+GetSeconds(timeLimit).ToString("D2"));
            timeLimit -= Time.deltaTime;
        }
    }

    //Checks if the player 2 is a human player or computer controlled.
    private bool IsPlayerTwoBot()
    {
        return DataManager.Instance.isBot;
    }
    
    // Sets the proper script for the player 2 whether he is a player or a bot.
    private void SetPlayerTwo()
    {
        if (IsPlayerTwoBot())
        {
            player2Script.enabled = false;
            botScript.enabled = true;
        }
        else
        {
            player2Script.enabled = true;
            botScript.enabled = false;
        }
    }

    //Checks if the powerups are on.
    private bool ArePowerupsOn()
    {
        return DataManager.Instance.canPowerup;
    }

    //Activates the powerups gameobject and scrip if they are on , else it will disable them.
    private void SetPowerups()
    {
        if (ArePowerupsOn())
        {
            powerupManager.SetActive(true);
            powerupScript.enabled = true;
        }
        else
        {
            powerupManager.SetActive(false);
            powerupScript.enabled = false;
        }
    }

    //Checks if a ball exists on the field.
    private bool DoesBallExists()
    {
        return GameObject.FindWithTag("Ball");
    }

    //Returns the ball gameobject.
    private GameObject GetBall()
    {
        return GameObject.FindWithTag("Ball");
    }
    
    //Checks if an extra ball exists on the field.
    private bool DoesExtraBallExists()
    {
        return GameObject.FindWithTag("ExtraBall");
    }

    //Returns the extra ball;
    private GameObject GetExtraBall()
    {
        return GameObject.FindWithTag("ExtraBall");
    }

    //Destroys the ball gameobject if it exists. If powerups are on and an extra ball exists on the field, it will destroy it too.
    private void DestroyBall()
    {
        if (DoesBallExists())
        {
            Destroy(GetBall());
        }

        if (ArePowerupsOn())
        {
            if (DoesExtraBallExists())
            {
                Destroy(GetExtraBall());
            }
        }
    }

    //Return the powerup gameobject.
    private GameObject GetPowerup()
    {
        return GameObject.FindWithTag("Powerup");
    }
    
    //Destroys a powerup if it's on field.
    private void DestroyPowerup()
    {
        if (powerupScript.isPowerupOnField)
        {
            Destroy(GetPowerup());
        }
    }






}