using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Powerup : MonoBehaviour
{
    [Header("Script")] 
    private PowerupManager powerupScript;
    protected MatchManager managerScript;
    protected PlayerScaleManager scaleManager;
    

    private void Awake()
    {
        Init();
    }
    
    protected void Init()
    {
        managerScript = GameObject.Find("MatchManager").GetComponent<MatchManager>();
        powerupScript = GameObject.Find("PowerupManager").GetComponent<PowerupManager>();
        scaleManager = GameObject.Find("PowerupManager").GetComponent<PlayerScaleManager>();
    }
    
    protected abstract void ActivateEffect();
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        Destroy(gameObject);
        ActivateEffect();;
        powerupScript.isPowerupOnField = false;
        powerupScript.SpawnPowerUp();
    }

   

    
    
    
}
