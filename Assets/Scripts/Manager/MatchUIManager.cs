using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MatchUIManager : MonoBehaviour
{
    [SerializeField]
    private MatchManager managerScript;
    
    [Header("SCOREBOARD COMPONENTS")]
    [SerializeField] 
    private GameObject scoreBoard;
    [SerializeField]
    private TextMeshProUGUI playerOneScore;
    [SerializeField]
    private TextMeshProUGUI playerTwoScore;
    [SerializeField]
    private TextMeshProUGUI gameModeText;
  
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
    
    [Header("PAUSE COMPONENTS")]
    [SerializeField]
    private GameObject pauseMenuCanvas;
    [SerializeField]
    private GameObject quitPanel;
    [SerializeField]
    private GameObject resumeButton;
    [SerializeField]
    private GameObject quitButton;
    
    private string sceneName;
    
    private void Awake()
    {
        Init();
        DisplayScore();
    }

    private void Init()
    {
        managerScript = GetComponent<MatchManager>();
        sceneName = "MainMenu";
    }
    
    //Displays the score of player one
    private void DisplayPlayerOneScore()
    {
        playerOneScore.text = "" + managerScript.playerOnePoints;
    }
    
    //Displays the score of player two
    private void DisplayPlayerTwoScore()
    {
        playerTwoScore.text = "" + managerScript.playerTwoPoints;
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
        managerScript.UnfreezeGame();
    }

    public void EnablePauseMenu()
    {
        pauseMenuCanvas.SetActive(true);
    }

    public void DisablePauseMenu()
    {
        pauseMenuCanvas.SetActive(false);
    }

    public void DisableQuitMenu()
    {
        quitPanel.SetActive(false);
        EnablePauseButtons();
    }

    public void EnableQuitMenu()
    {
        quitPanel.SetActive(true);
        DisablePauseButtons();
    }

    private void DisablePauseButtons()
    {
        resumeButton.SetActive(false);
        quitButton.SetActive(false);
    }

    private void EnablePauseButtons()
    {
        resumeButton.SetActive(true);
        quitButton.SetActive(true);
    }

    public void DisableLine()
    {
        middleLine.SetActive(false);
    }

    public void EnableLine()
    {
        middleLine.SetActive(true);
    }

    public void SetGameModeText(string gameMode)
    {
        gameModeText.text = gameMode;
    }
    
    
    
    
}
