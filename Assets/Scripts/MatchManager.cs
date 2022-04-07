using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class MatchManager : MonoBehaviour
{
    [Header("Match UI")]
    [SerializeField] 
    private MatchUIManager _matchUIManager;
    
    
    [Header("Match Ball")]
    [SerializeField] 
    private GameObject ball;
    [SerializeField] 
    private Ball ballScript;

    public int playerOnePoints { get; set; }
    public int playerTwoPoints { get; set; }

    private int playerOneID;
    
    private float startingXPosition;
    private float startingYPosition;
    private float initialCountdown;
    

    private void Awake()
    {
        Init();
      //  _matchUIManager.DisableMatchUI();
    }

    private void Start()
    {
       StartCoroutine(SpawnBallRoutine());
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
                StartCoroutine(HideCountdownTextRoutine());
                _matchUIManager.EnableMatchUI();
            }
        }
    }
    
    IEnumerator HideCountdownTextRoutine()
    {
        yield return new WaitForSeconds(0.7f);
        _matchUIManager.HideCountdownText();
    }
    IEnumerator SpawnBallRoutine()
    {
        yield return new WaitForSeconds(4f);
        SpawnBall();
    }
    
    private int GetSeconds(float time)
    {
        return Mathf.FloorToInt(time % 60);
    }


    



}
