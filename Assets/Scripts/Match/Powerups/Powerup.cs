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
    
    //Initilializes the scripts
    protected void Init()
    {
        managerScript = GameObject.Find("MatchManager").GetComponent<MatchManager>();
        powerupScript = GameObject.Find("PowerupManager").GetComponent<PowerupManager>();
        scaleManager = GameObject.Find("PowerupManager").GetComponent<PlayerScaleManager>();
    }
    
    //This method will be called on collision with the powerup.
    protected abstract void ActivateEffect();
    
    //On collision with a powerup gameobject ,it will be destroyed and has it's own version of "ActivateEffect" activated. 
    //Another powerup will spawn after x amount of time specified in the method "SpawnPowerup".
    private void OnTriggerEnter2D(Collider2D col)
    {
        Destroy(gameObject);
        ActivateEffect();;
        powerupScript.isPowerupOnField = false;
        powerupScript.SpawnPowerUp();
    }

   

    
    
    
}
