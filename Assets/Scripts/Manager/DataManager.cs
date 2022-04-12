using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;

    private bool isBot { get; set;}
    private bool canPowerup { get; set;}
    public int goals {get; set;}
    private int timeLimit { get; set;}
    private string matchMode { get; set;}
    
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }


    









}
