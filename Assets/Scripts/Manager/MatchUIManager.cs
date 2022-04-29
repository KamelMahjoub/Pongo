using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MatchUIManager : MonoBehaviour
{
    [SerializeField] private MatchManager managerScript;

    [Header("SCOREBOARD COMPONENTS")] [SerializeField]
    private GameObject scoreBoard;

    [SerializeField] private TextMeshProUGUI playerOneScore;
    [SerializeField] private TextMeshProUGUI playerTwoScore;
    [SerializeField] private TextMeshProUGUI gameModeText;

    [Header("PLAYER COMPONENTS")] [SerializeField]
    private GameObject playerOne;

    [SerializeField] private GameObject playerTwo;

    [Header("FIELD COMPONENT")] [SerializeField]
    private GameObject middleLine;

    [Header("COUNTDOWN COMPONENTS")] [SerializeField]
    private GameObject countdownPanel;

    [SerializeField] private TextMeshProUGUI countdownText;

    [Header("POST MATCH COMPONENTS")] [SerializeField]
    private GameObject postMatchPanel;

    [SerializeField] private TextMeshProUGUI gameResultText;

    [Header("PAUSE COMPONENTS")] [SerializeField]
    private GameObject pauseMenuCanvas;

    [SerializeField] private GameObject quitPanel;
    [SerializeField] private GameObject resumeButton;
    [SerializeField] private GameObject quitButton;

    private string menuScene;

    private void Awake()
    {
        Init();
        DisplayScore();
    }

    private void Init()
    {
        managerScript = GetComponent<MatchManager>();
        menuScene = "MainMenu";
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

    //Changes the countdown text value.
    public void ChangeCountdownText(String textToDisplay)
    {
        countdownText.text = textToDisplay;
    }

    //Hides the countdown text.
    public void HideCountdownText()
    {
        countdownPanel.SetActive(false);
    }
    
    //Displays the countdown text.
    public void ShowCountdownText()
    {
        countdownPanel.SetActive(true);
    }

    //Displays the post match menu.
    public void DisplayPostMatchCanvas()
    {
        postMatchPanel.SetActive(true);
    }

    //Sets the value of the game result text.
    public void SetGameResult(string text)
    {
        gameResultText.SetText(text);
    }

    //Moves the player back to the main menu.
    public void GoToMainMenu()
    {
        SceneManager.LoadScene(menuScene);
        if (managerScript.isGamePaused)
        {
            managerScript.UnfreezeGame();
        }
    }

    //Displays the pause menu.
    public void EnablePauseMenu()
    {
        pauseMenuCanvas.SetActive(true);
    }

    //Hides the pause menu.
    public void DisablePauseMenu()
    {
        pauseMenuCanvas.SetActive(false);
    }

    //Hides the quit menu.
    public void DisableQuitMenu()
    {
        quitPanel.SetActive(false);
        EnablePauseButtons();
    }

    //Displays the quit menu.
    public void EnableQuitMenu()
    {
        quitPanel.SetActive(true);
        DisablePauseButtons();
    }

    //Hides the pause menu buttons.
    private void DisablePauseButtons()
    {
        resumeButton.SetActive(false);
        quitButton.SetActive(false);
    }

    //Displays the pause menu buttons.
    private void EnablePauseButtons()
    {
        resumeButton.SetActive(true);
        quitButton.SetActive(true);
    }

    //Hides the line effect on the settings panel buttons.
    public void DisableLine()
    {
        middleLine.SetActive(false);
    }

    //Displays the line effect on the settings panel buttons.
    public void EnableLine()
    {
        middleLine.SetActive(true);
    }

    //Sets the value of the game mode text.
    public void SetGameModeText(string gameMode)
    {
        gameModeText.text = gameMode;
    }
}