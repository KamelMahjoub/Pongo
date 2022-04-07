using System;
using System.Collections;
using System.Collections.Generic;
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
    
    private void Awake()
    {
       Init();
    }

    private void Start()
    {
       LaunchBall(); 
    }
    
    //Initializes the variables/properties
    private void Init()
    {
        ballRb = GetComponent<Rigidbody2D>();
        speed = 5f; 
    }
    
    //Launches the ball in a random position
    private void LaunchBall()
    {
        ballRb.velocity = RandomStartingPosition() * speed;
    }

    //Generates a random vector2 position that the ball will be launched to 
    private Vector2 RandomStartingPosition()
    {
        float AxisPosition = RandomAxisPosition();
        float startingXPosition = 1;
        float startingYPosition = RandomYPosition();
        
        //if the axis position is > 0 , then the ball will go to the right; else it will go to the left.
        if (AxisPosition > 0)
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
    
}
