using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
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
            Debug.Log(ballRb.velocity);
            
                if (ballRb.position.y > transform.position.y)
                {
                    paddleRb.AddForce(Vector2.up * speed ); 
                }
                else if (ballRb.position.y < transform.position.y)
                {
                    paddleRb.AddForce(Vector2.down * speed);
                }
        }
    }


    private void Init()
    {
        speed = 55;
        ballTag = "Ball"; 
    }
    
    private bool DoesBallExist(string tag)
    {
        return GameObject.FindWithTag(tag);
    }

    private void GetBall(string tag)
    {
        ball = GameObject.FindWithTag(tag);
        ballRb = ball.GetComponent<Rigidbody2D>();
    }





}