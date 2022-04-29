using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Animations;
using Random = UnityEngine.Random;

public class Ball : MonoBehaviour
{
    [Header("Variables")]
    [SerializeField]
    private float speed;
    
    [Header("Components")]
    private Rigidbody2D ballRb;

    private int internalCooldown;
    private float lastYPosition;

    private void Awake()
    {
       Init();
    }
    
    private void Start()
    {
       LaunchBall();
       InvokeRepeating("GetLastPosition",5,1);
       InvokeRepeating("CheckBallPosition",5,2f);
    }

    private void Update()
    {
        PushBall();
    }


    //Initializes the variables/properties
    private void Init()
    {
        ballRb = GetComponent<Rigidbody2D>();
        speed = 5f;
        internalCooldown = 0;
    }
    
    //Launches the ball in a random position
    private void LaunchBall()
    {
        ballRb.velocity = RandomStartingPosition() * speed;
    }

    //Generates a random vector2 position that the ball will be launched to 
    private Vector2 RandomStartingPosition()
    {
        float axisPosition = RandomAxisPosition();
        float startingXPosition = 1;
        float startingYPosition = RandomYPosition();
        
        //if the axis position is > 0 , then the ball will go to the right; else it will go to the left.
        if (axisPosition > 0)
        {
            return new Vector2(startingXPosition, startingYPosition);
        }
        else
        {
            return new Vector2(-startingXPosition, startingYPosition);
        }
    }

    // Generates a random value between -1 and 1
    private float RandomAxisPosition()
    {
        float startingAxisPosition = 1;
        return Random.Range(-startingAxisPosition, startingAxisPosition);
    }

    //Generates a random Y axis position 
    private float RandomYPosition()
    {
        float yPosition = 0.2f;
        return Random.Range(-yPosition, yPosition);
    }

    //a public AddForce method to enforce encapsulation on the private rigidbody component
    public void AddForce(Vector2 force)
    {
        ballRb.AddForce(force , ForceMode2D.Impulse);
    }

    //Checks if the ball position has changes, else adds +1 to the internal cooldown value;
    private void CheckBallPosition()
    {
        float currentYPosition = ballRb.position.y;
        if (currentYPosition != lastYPosition)
        {
            internalCooldown = 0;
        }
        else
        {
            internalCooldown ++;
        }
    }
    
    //Returns the y position of the ball from the last frame.
    private void GetLastPosition()
    {
        lastYPosition = ballRb.position.y;
    }
    
    // If the internal cooldown has reached it's limit , pushes the ball a little bit to avoid the ball being stuck or ha having the same trajectory for a long time.
    private void PushBall()
    {
        int cooldownLimit = 5;
        int pushPower = 20;
        float xAxis = 0;
        float yAxis = ballRb.velocity.y;

        if (internalCooldown == cooldownLimit)
        {
            if (ballRb.velocity.y >= 0)
            {
                ballRb.AddForce(new Vector2(xAxis, yAxis - pushPower));
            }
            else
            {
                ballRb.AddForce(new Vector2(xAxis, yAxis + pushPower) );
            }
        }
    }


}
