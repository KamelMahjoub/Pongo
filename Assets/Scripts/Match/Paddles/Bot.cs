using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bot : Paddle
{
    private GameObject ball;

    private void Start()
    {
        speed = 5;
    }
    private void Update()
    {

        if (CheckIfBallExists())
        {
            Rigidbody2D ballRb = GameObject.Find("Ball(Clone)").GetComponent<Rigidbody2D>();

            if (ballRb.velocity.x > 0f)
            {
                if (ballRb.position.y > transform.position.y)
                {
                    paddleRb.velocity = Move(Vector2.up);
                }
                else if (ballRb.position.y < transform.position.y)
                {
                   paddleRb.velocity = Move(Vector2.down);
                }
            }
            else
            {
                paddleRb.velocity = Move(transform.position.y > 0f ? Vector2.down : Vector2.up);
            }
        }
    }


    private bool CheckIfBallExists()
    {
        return GameObject.Find("Ball(Clone)");
    }




    private Vector2 Move(Vector2 direction)
    {
        return new Vector2(paddleRb.velocity.x, direction.y * speed );
    }
    
    
}
