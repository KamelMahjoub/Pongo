using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bot : Paddle
{
    private GameObject ball;
    private Rigidbody2D ballRb;
    private string ballTag;
    
    private void Start()
    {
        Init();
    }

    private void FixedUpdate()
    {
        if (DoesBallExist(ballTag))
        {
            GetBall(ballTag);
            Move();
        }
    }
    
    //Initializes the variables/properties.
    private void Init()
    {
        speed = 0.95f;
        ballTag = "Ball"; 
    }
    
    //Checks if a ball gameobject exists.
    private bool DoesBallExist(string tag)
    {
        return GameObject.FindWithTag(tag);
    }

    //Gets the Ball rigidbody.
    private void GetBall(string tag)
    {
        ball = GameObject.FindWithTag(tag);
        ballRb = ball.GetComponent<Rigidbody2D>();
    }

    //Moves the paddle according to the ball rigidbody y position.
    private void Move()
    {
        if (ballRb.velocity.x > 0)
        {
            if (ballRb.position.y > transform.position.y)
            {
                paddleRb.velocity = Vector2.up * speed;
            }
            else if (ballRb.position.y < transform.position.y)
            {
                paddleRb.velocity = Vector2.down * speed;
            } 
        }
        
    }




}
