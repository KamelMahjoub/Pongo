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

    //Initializes the values/properties.
    private void Init()
    {
        scaleManager = GameObject.Find("PowerupManager").GetComponent<PlayerScaleManager>();
        nbPowerups = powerupArray.Length;
        isPowerupOnField = false;
    }
    
    //Returns a random number between 0 and the specified number of powerups -1 .
    private int GetRandomPowerupIndex()
    {
        return Random.Range(0, nbPowerups);
    }

    //Returs a random X value between [-5,-0.5] and [0.5,5].
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
    
    //returs a random vector2 between the random x position and a random y position between [-3,3].
    private Vector2 GetRandomPosition()
    {
        float yPosition = 3;
        return new Vector2(GetRandomXPosition(), Random.Range(-yPosition, yPosition));
    }

    //CHeks if there are a powerup on field , else instantiates a random powerup from the powerup array.
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

    //Spawns a powerup on the field after 8 seconds.
    public void SpawnPowerUp()
    {
        int spawnDelay = 8;
        Invoke(nameof(CreatePowerUp),spawnDelay);
    }
    





}