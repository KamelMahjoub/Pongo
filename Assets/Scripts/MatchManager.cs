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
    private TextMeshProUGUI playerOneScore;
    [SerializeField]
    private TextMeshProUGUI playerTwoScore;

    private int playerOnePoints;
    private int playerTwoPoints;
    

    private void Awake()
    {
        Init();
    }

    //Initializes the variables/properties
    private void Init()
    {
        playerOnePoints = 0;
        playerTwoPoints = 0;

        DisplayScore();
    }

    //Adds a point to the specified player
    public void AddPoint(int playerNb)
    {
        if(playerNb==1)
            playerOnePoints++;
        else
            playerTwoPoints++;
        
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

}
