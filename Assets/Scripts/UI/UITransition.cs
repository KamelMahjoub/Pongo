using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITransition : MonoBehaviour
{

    private new Animator camera;
    private string animateString;

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        camera = transform.GetComponent<Animator>();
        animateString = "Animate";
    }

    //Changes the display to position 2 to display the menus
    public void GoToPositionTwo()
    {
        camera.SetFloat(animateString, 1);
    }

    //Changes the display to position 1 to display the main menu
    public void GoToPositionOne()
    {
        camera.SetFloat(animateString, 0);
    }

}
