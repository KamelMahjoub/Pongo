using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Powerup : MonoBehaviour
{
    [Header("Script")] 
    private PowerupManager powerupScript;
    protected MatchManager managerScript;

    [SerializeField] 
    protected GameObject playerOne;
    [SerializeField]
    protected GameObject playerTwo;

    private float defaultXScaleValue;
    protected float defaultYScaleValue;
    private float defaultZScaleValue;


    private void Start()
    {
        SetPLayers();
    }

    private void Awake()
    {
        Init();
    }

    protected void SetPLayers()
    {  
        playerOne = GameObject.FindWithTag("Player1");
        playerTwo = GameObject.FindWithTag("Player2");
    }

    private void Init()
    {
        powerupScript = GameObject.Find("MatchManager").GetComponent<PowerupManager>();
        managerScript = GameObject.Find("MatchManager").GetComponent<MatchManager>();

        defaultXScaleValue = 0.2f;
        defaultYScaleValue = 1.5f;
        defaultZScaleValue = 1;
    }


    protected abstract void ActivateEffect();
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        Destroy(gameObject);
        ActivateEffect();;
        powerupScript.isPowerupOnField = false;
        powerupScript.SpawnPowerUp();
    }

    protected Vector3 SetYScaleValue(float yValue)
    {
        return new Vector3(defaultXScaleValue, yValue, defaultZScaleValue);
    }
    
    
    
}
