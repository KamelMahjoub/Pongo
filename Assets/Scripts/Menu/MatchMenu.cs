using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MatchMenu : MonoBehaviour
{
    private enum GoalsToWin
    {
        Five = 5,
        Ten = 10,
        Twenty = 20,
    }
    private enum MatchTime
    {
        Three = 3,
        Five = 5,
        Seven = 7
    }

    private enum MatchMode
    {
        GoalLimited,
        TimeLimited
    }
    
    private enum Powerups
    {
        On,
        Off
    }
    
    [Header("MATCH MODE HIGHLIGHTS")]
    [SerializeField]
    private GameObject vsPlayerHighlight;
    [SerializeField]
    private GameObject vsBotHighlight;
    
    [Header("MATCH TYPE HIGHLIGHTS")]
    [SerializeField]
    private GameObject goalHighlight;
    [SerializeField]
    private GameObject timeHighlight;
    
    [Header("MATCH TYPE PANELS")]
    [SerializeField]
    private GameObject goalPanel;
    [SerializeField]
    private GameObject timePanel;
    
    [Header("GOALS HIGHLIGHTS")]
    [SerializeField]
    private GameObject firstGoalLine;
    [SerializeField]
    private GameObject secondGoalLine;
    [SerializeField]
    private GameObject thirdGoalLine;
    
    [Header("TIME HIGHLIGHTS")]
    [SerializeField]
    private GameObject firstTimeLine;
    [SerializeField]
    private GameObject secondTimeLine;
    [SerializeField]
    private GameObject thirdTimeLine;

    [Header("POWERUP TIME")] 
    [SerializeField]
    private TextMeshPro powerupText;
    
    [Header("VARIABLES")]
    private bool isBot;
    private bool canPowerup;
    private int goals;
    private int time;
    private string mode;
   

    private void OnEnable()
    {
        Init();
    }

  

    private void Init()
    {
        SetPowerups();
        SetMatchAgainstPlayer();
        SetGoalsMode();
    }
    
    
//Sets the match mode against the player
    public void SetMatchAgainstPlayer()
    {
        vsPlayerHighlight.SetActive(true);
        vsBotHighlight.SetActive(false);
        isBot = false;
    }
//Sets the match mode against the bot
    public void SetMatchAgainstBot()
    {
        vsBotHighlight.SetActive(true);
        vsPlayerHighlight.SetActive(false);
        isBot = true;
    }
//Sets the match type to be goals limited
    public void SetGoalsMode()
    {
        goalHighlight.SetActive(true);
        timeHighlight.SetActive(false);
        goalPanel.SetActive(true);
        timePanel.SetActive(false);
        SelectFirstGoalLimit();
        mode = MatchMode.GoalLimited.ToString();

    }
//Sets the match type to be time limited
    public void SetTimeMode()
    {
        timeHighlight.SetActive(true);
        goalHighlight.SetActive(false);
        goalPanel.SetActive(false);
        timePanel.SetActive(true);
        mode = MatchMode.TimeLimited.ToString();
    }
//Sets the goal limit to the first value
    public void SelectFirstGoalLimit()
    {
        firstGoalLine.SetActive(true);
        secondGoalLine.SetActive(false);
        thirdGoalLine.SetActive(false);
        goals = (int)GoalsToWin.Five;
    } 
//Sets the goal limit to the second value
    public void SelectSecondGoalLimit()
    {
        firstGoalLine.SetActive(false);
        secondGoalLine.SetActive(true);
        thirdGoalLine.SetActive(false);
        goals = (int)GoalsToWin.Ten;
    }
//Sets the goal limit to the third value
    public void SelectThirdGoalLimit()
    {
        firstGoalLine.SetActive(false);
        secondGoalLine.SetActive(false);
        thirdGoalLine.SetActive(true);
        goals = (int)GoalsToWin.Twenty;
    }
    
//Sets the time limit to the first value
    public void SelectFirstTimeLimit()
    {
        firstTimeLine.SetActive(true);
        secondTimeLine.SetActive(false);
        thirdTimeLine.SetActive(false);
        time = (int)MatchTime.Three;
    } 
//Sets the time limit to the second value
    public void SelectSecondTimeLimit()
    {
        firstTimeLine.SetActive(false);
        secondTimeLine.SetActive(true);
        thirdTimeLine.SetActive(false);
        time = (int)MatchTime.Five;
    } 
//Sets the time limit to the third value
    public void SelectThirdTimeLimit()
    {
        firstTimeLine.SetActive(false);
        secondTimeLine.SetActive(false);
        thirdTimeLine.SetActive(true);
        time = (int)MatchTime.Seven;
    }
//Sets the powerup to active or inactive 
    public void SetPowerups()
    {
        if (canPowerup)
        {
            powerupText.SetText(Powerups.Off.ToString());
            canPowerup = false;
        }
        else
        {
            powerupText.SetText(Powerups.On.ToString());
            canPowerup = true;
        }
    }



    public void Play()
    {
        if (isBot)
        {
            Debug.Log("Match Mode : VS BOT");
        }
        else
        {
            Debug.Log("Match Mode : VS Player");
        }

        if (mode.Equals("GoalLimited"))
        {
            Debug.Log("First To : "+goals);
        }
        
        if (mode.Equals("TimeLimited"))
        {
            Debug.Log("Time Limit : "+time);
        }

        Debug.Log("Powerups : "+canPowerup);
    }
    
    
    



}
