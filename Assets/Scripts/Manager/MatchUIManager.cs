using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MatchUIManager : MonoBehaviour
{
    [SerializeField]
    private MatchManager _managerScript;
    
    [Header("SCOREBOARD COMPONENTS")]
    [SerializeField] 
    private GameObject scoreBoard;
    [SerializeField]
    private TextMeshProUGUI playerOneScore;
    [SerializeField]
    private TextMeshProUGUI playerTwoScore;
  
    [Header("PLAYER COMPONENTS")]
    [SerializeField]
    private GameObject playerOne;
    [SerializeField]
    private GameObject playerTwo;
  
    [Header("FIELD COMPONENT")]
    [SerializeField] 
    private GameObject middleLine;
    
    [Header("COUNTDOWN COMPONENTS")]
    [SerializeField]
    private GameObject countdownPanel;
    [SerializeField]
    private TextMeshProUGUI countdownText;
    
    [Header("POST MATCH COMPONENTS")]
    [SerializeField]
    private GameObject postMatchPanel;
    [SerializeField]
    private TextMeshProUGUI gameResultText;

    private string sceneName;
    


    private void Awake()
    {
        Init();
        DisplayScore();
    }

    private void Init()
    {
        _managerScript = GetComponent<MatchManager>();
        sceneName = "MainMenu";
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
        countdownText.text = textToDisplay;
    }

    public void HideCountdownText()
    {
        countdownPanel.SetActive(false);
    }

    public void DisplayPostMatchCanvas()
    {
        postMatchPanel.SetActive(true);
    }

    public void SetGameResult(string text)
    {
        gameResultText.SetText(text);
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene(sceneName);
    }




}
