using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Ball : MonoBehaviour
{

    private Rigidbody2D ballRb;

    private float speed;

    private void Awake()
    {
       Init();
    }

    private void Start()
    {
       LaunchBall(); 
    }

    private void Init()
    {
        ballRb = GetComponent<Rigidbody2D>();
        speed = 9f; 
    }
    
    private void LaunchBall()
    {
        float startingPosition = 1;

        ballRb.velocity = new Vector2(Random.Range(-startingPosition, startingPosition),
            Random.Range(-startingPosition, startingPosition)) * speed;
    }
}
