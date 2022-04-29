using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScaleManager : MonoBehaviour
{
    [SerializeField] 
    protected GameObject playerOne;
    [SerializeField]
    protected GameObject playerTwo;
    
    private float defaultXScaleValue;
    private float defaultYScaleValue;
    private float defaultZScaleValue;


    private void Awake()
    {
        Init();
    }
    
    //Initializes the default scale value of the paddles.
    private void Init()
    {
        defaultXScaleValue = 0.2f;
        defaultYScaleValue = 1.5f;
        defaultZScaleValue = 1;  
    }
    
    //Changes the Y Scale value of a vector3.
    private Vector3 SetYScaleValue(float yValue)
    {
        return new Vector3(defaultXScaleValue, yValue, defaultZScaleValue);
    }

    //Changes the Y scale value of both players.
    public void ChangeScale(float yValue)
    {
        playerOne.transform.localScale = SetYScaleValue(yValue);
        playerTwo.transform.localScale = SetYScaleValue(yValue);
    }
    
    //Changes the Y scale value of both players to the default Y scale value.
    private void SetDefaultScale()
    {
        playerOne.transform.localScale = SetYScaleValue(defaultYScaleValue);
        playerTwo.transform.localScale = SetYScaleValue(defaultYScaleValue); 
    }

    //Checks if the Y scale value of the players is different than the default value.
    private bool CheckScale()
    {
        return playerOne.transform.localScale.y != defaultYScaleValue;
    }
    
    //Resets the Y scale value of the value if it's different from the default value.
    public void ResetScale()
    {
        if (CheckScale())
        {
            SetDefaultScale();
        }
    }
   
    
    
}
