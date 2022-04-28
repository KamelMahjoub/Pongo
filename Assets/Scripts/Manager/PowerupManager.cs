using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;


public class PowerupManager : MonoBehaviour
{
    [Header("POWERUPS LIST")]
    [SerializeField] 
    private GameObject[] powerupArray;

    private PlayerScaleManager scaleManager;
    
    private int nbPowerups;
    
    public bool isPowerupOnField;
    
    private void Awake()
    {
        Init();
    }

    private void Start()
    {
        SpawnPowerUp();
    }

    private void Init()
    {
        scaleManager = GameObject.Find("MatchManager").GetComponent<PlayerScaleManager>();
        nbPowerups = powerupArray.Length;
        isPowerupOnField = false;
    }


    private int GetRandomPowerupIndex()
    {
        return Random.Range(0, nbPowerups);
    }

    private float GetRandomXPosition()
    {
        float xMinPosition = 0.5f;
        float xMaxPosition = 5;
        float xPosition;

        do
        {
            xPosition = Random.Range(-xMaxPosition, xMaxPosition);
        } while (xPosition > -xMinPosition && xPosition < xMinPosition);

        return xPosition;
    }
    
    private Vector2 GetRandomPosition()
    {
        float yPosition = 3;
        return new Vector2(GetRandomXPosition(), Random.Range(-yPosition, yPosition));
    }


    private void CreatePowerUp()
    {
        if (!isPowerupOnField)
        {
            Instantiate(powerupArray[GetRandomPowerupIndex()], GetRandomPosition(),
                powerupArray[GetRandomPowerupIndex()].transform.rotation);
            
            scaleManager.ResetScale();

            isPowerupOnField = true;
        }
    }

    public void SpawnPowerUp()
    {
        int spawnDelay = 8;
        Invoke(nameof(CreatePowerUp),spawnDelay);
    }





}