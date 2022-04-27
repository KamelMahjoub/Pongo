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

    private void Init()
    {
        shrinkValue = 1f;
    }
    protected override void ActivateEffect()
    { 
        
    }

    private IEnumerator ShrinkPlayersRoutine()
    {
       Vector3 playerOneScale = playerOne.transform.localScale;
       Vector3 playerTwoScale = playerTwo.transform.localScale;
       yield return new WaitForSeconds(7); 
       playerOneScale = SetYScaleValue(shrinkValue);
       playerTwoScale = SetYScaleValue(shrinkValue);
        
       playerOneScale = SetYScaleValue(defaultYScaleValue);
       playerTwoScale = SetYScaleValue(defaultYScaleValue); 
    }
    

}
