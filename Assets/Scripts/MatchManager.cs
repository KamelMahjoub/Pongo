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

    private void Init()
    {
        playerOnePoints = 0;
        playerTwoPoints = 0;
        
        playerOneScore.text = Random.Range(0,1000).ToString();
        playerTwoScore.text = Random.Range(0,1000).ToString();
        
    }
}
