using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stretch : Powerup
{
    private float stretchValue;
    
    void Awake()
    {
        Init();
    }

    private new void Init()
    {
        base.Init();
        stretchValue = 2.2f;
    }
    
    protected override void ActivateEffect()
    {
        ShrinkPlayers();
    }

    private void ShrinkPlayers()
    {
        scaleManager.ChangeScale(stretchValue);
    }

}
