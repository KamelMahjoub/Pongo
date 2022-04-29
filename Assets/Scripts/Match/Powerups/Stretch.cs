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

    //Calls the powerup class init method and initilializs the stretchvalue;
    private new void Init()
    {
        base.Init();
        stretchValue = 2.2f;
    }
    
    //Enlarges the players.
    protected override void ActivateEffect()
    {
        ShrinkPlayers();
    }

    //Changes the y scale value of the players with the specified stretch value. 
    private void ShrinkPlayers()
    {
        scaleManager.ChangeScale(stretchValue);
    }

}
