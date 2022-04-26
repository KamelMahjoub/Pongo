using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Powerup : MonoBehaviour
{
    [Header("Script")]
    [SerializeField]
    private PowerupManager powerupScript;


    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        powerupScript = GameObject.Find("MatchManager").GetComponent<PowerupManager>();
    }


    protected abstract void ActivateEffect();
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        Destroy(gameObject);
        ActivateEffect();;
        powerupScript.IsPowerupOnField = false;
        Debug.Log("Triggered");
    }
    
    
}
