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

    private new void Init()
    {
        base.Init();
        shrinkValue = 1f;
    }
    protected override void ActivateEffect()
    {
        ShrinkPlayers();
    }

    private void ShrinkPlayers()
    {
        scaleManager.ChangeScale(shrinkValue);
    }

  
    

}
