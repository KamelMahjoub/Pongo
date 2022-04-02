using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class MatchManager : MonoBehaviour
{
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

    private void Update()
    {
        
    }

    private void Init()
    {
        playerOnePoints = 0;
        playerTwoPoints = 0;

        DisplayScore();
    }


    public void AddPoint(int playerNb)
    {
        if(playerNb==1)
            playerOnePoints++;
        else
            playerTwoPoints++;
        
        DisplayScore();
    }

    
    private void DisplayPlayerOneScore()
    {
        playerOneScore.text = "" + playerOnePoints;
    }
    
    private void DisplayPlayerTwoScore()
    {
        playerTwoScore.text = "" + playerTwoPoints;
    }

    private void DisplayScore()
    {
        DisplayPlayerOneScore();
        DisplayPlayerTwoScore();
    }

}
