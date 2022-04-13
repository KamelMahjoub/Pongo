using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;
    public bool isBot { get; set;}
    public bool canPowerup { get; set;}
    public int goals { get; set;}
    public int timeLimit { get; set;}
    public string matchMode { get; set;}
    
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
