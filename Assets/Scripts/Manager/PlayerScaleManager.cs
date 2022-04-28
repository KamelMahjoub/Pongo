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
    private void Init()
    {
        defaultXScaleValue = 0.2f;
        defaultYScaleValue = 1.5f;
        defaultZScaleValue = 1;  
    }
    
    private Vector3 SetYScaleValue(float yValue)
    {
        return new Vector3(defaultXScaleValue, yValue, defaultZScaleValue);
    }

    public void ChangeScale(float yValue)
    {
        playerOne.transform.localScale = SetYScaleValue(yValue);
        playerTwo.transform.localScale = SetYScaleValue(yValue);
    }

    public void ResetScale()
    {
        playerOne.transform.localScale = SetYScaleValue(defaultYScaleValue);
        playerTwo.transform.localScale = SetYScaleValue(defaultYScaleValue);  
    }

   
    
    
}
