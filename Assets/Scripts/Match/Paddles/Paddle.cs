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

    private void Init()
    {
        paddleRb = GetComponent<Rigidbody2D>();
    }
    
    private float HitPosition(Vector2 ballPos, Vector2 playerPos, float paddleHeight)
    {
        return (ballPos.y - playerPos.y) / paddleHeight;
    }
    
    private void OnCollisionEnter2D(Collision2D col)
    {
        Vector2 direction;
     
        //gets the hit point
        float collisionPosition = HitPosition(transform.position, col.transform.position, 
            col.collider.bounds.size.y);
     
        //if the ball hit player one
        if (col.gameObject.CompareTag("Player1")) {
            //calculates the direction
            direction = new Vector2(1, collisionPosition).normalized;
        }
        else
        {
            //calculates the direction
            direction = new Vector2(-1, collisionPosition).normalized;
        }
     
        // Sets the velocity with direction * speed
       GetComponent<Rigidbody2D>().velocity = direction * speed * 1.5f;
    }
}
