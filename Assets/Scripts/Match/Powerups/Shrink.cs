using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shrink : Powerup
{
    protected override void ActivateEffect()
    {
        Debug.Log("Shrink Effect");
    }
/*
    private void OnTriggerEnter2D(Collider2D col)
    {
        Destroy(gameObject);
        ActivateEffect();;
        Debug.Log("Triggered");
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("aaaaaaaaaa");
    }
    */
}
