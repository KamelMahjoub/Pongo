using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITransition : MonoBehaviour
{

    private Animator camera;

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        camera = transform.GetComponent<Animator>();
    }

    //Changes the display to position 2 to display the menus
    public void GoToPositionTwo()
    {
        camera.SetFloat("Animate", 1);
    }

    //Changes the display to position 1 to display the main menu
    public void GoToPositionOne()
    {
        camera.SetFloat("Animate", 0);
    }

}
