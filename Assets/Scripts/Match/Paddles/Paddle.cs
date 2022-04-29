using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public float speed;
    public Rigidbody2D paddleRb;

    private void Start()
    {
        Init();
    }

    //Initialized both player's rigidbody component.
    private void Init()
    {
        paddleRb = GetComponent<Rigidbody2D>();
    }
}
