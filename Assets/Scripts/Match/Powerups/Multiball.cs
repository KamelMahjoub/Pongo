using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Multiball : Powerup
{
    [SerializeField]
    private Ball extraBall;
    
    //Instantiates an extraball on collision.
    protected override void ActivateEffect()
    {
        Instantiate(extraBall, managerScript.StartingPosition(), extraBall.transform.rotation);
    }
}
