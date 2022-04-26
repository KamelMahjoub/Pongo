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

    private int nbPowerups;

    public bool IsPowerupOnField {get; set; }


    private void Awake()
    {
        Init();
    }

    private void Start()
    {
        StartCoroutine(SpawnPowerUpRoutine());
    }

    private void Init()
    {
        nbPowerups = powerupArray.Length;
        IsPowerupOnField = false;
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


    private IEnumerator SpawnPowerUpRoutine()
    {
        if (!IsPowerupOnField)
        {
            int spawnInterval = 5;
            yield return new WaitForSeconds(spawnInterval);

            Instantiate(powerupArray[GetRandomPowerupIndex()], GetRandomPosition(),
                powerupArray[GetRandomPowerupIndex()].transform.rotation);

            IsPowerupOnField = true;  
        }
    }
}