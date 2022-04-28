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
        powerupScript = GameObject.Find("MatchManager").GetComponent<PowerupManager>();
        managerScript = GameObject.Find("MatchManager").GetComponent<MatchManager>();
        scaleManager = GameObject.Find("MatchManager").GetComponent<PlayerScaleManager>();
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
