using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{

    [SerializeField]
    private MatchManager matchManager;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (gameObject.name == "Player1Goal")
        {
            matchManager.AddPoint(2);
        }
        else
        {
            matchManager.AddPoint(1);
        }
    }
}
