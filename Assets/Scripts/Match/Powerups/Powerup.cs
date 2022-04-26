using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Powerup : MonoBehaviour
{
    private PowerupManager powerupScript;
    
    protected abstract void ActivateEffect();
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        Destroy(gameObject);
        ActivateEffect();;
        powerupScript.IsPowerupOnField = false;
    }
}
