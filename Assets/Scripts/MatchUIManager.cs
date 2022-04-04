using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MatchUIManager : MonoBehaviour
{
    [SerializeField]
    private MatchManager _managerScript;
    
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


    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        _managerScript = GetComponent<MatchManager>();
    }
    
    //Displays the score of player one
    private void DisplayPlayerOneScore()
    {
        playerOneScore.text = "" + _managerScript.playerOnePoints;
    }
    
    //Displays the score of player two
    private void DisplayPlayerTwoScore()
    {
        playerTwoScore.text = "" + _managerScript.playerTwoPoints;
    }
    
    //Displays both players scores
    public void DisplayScore()
    {                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                       
        DisplayPlayerOneScore();
        DisplayPlayerTwoScore();
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

    public void ChangeCountdownText(String textToDisplay)
    {
        startingCountdownText.text = textToDisplay;
    }




}
