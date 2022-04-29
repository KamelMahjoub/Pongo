using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shrink : Powerup
{
    private float shrinkValue;
    
    void Awake()
    {
        Init();
    }

    //Calls the powerup class init method and initilializs the shrinkvalue;
    private new void Init()
    {
        base.Init();
        shrinkValue = 1f;
    }
    
    //Shrinks the players.
    protected override void ActivateEffect()
    {
        ShrinkPlayers();
    }

    //Changes the y scale value of the players with the specified shrink value. 
    private void ShrinkPlayers()
    {
        scaleManager.ChangeScale(shrinkValue);
    }

  
    

}
