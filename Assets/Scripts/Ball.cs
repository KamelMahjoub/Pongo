using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Ball : MonoBehaviour
{
    
    [Header("Variables")]
    
    [SerializeField]
    private float speed;

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
        speed = 9f; 
    }
    
    //Launches the ball in a random position
    private void LaunchBall()
    {
        ballRb.velocity = RandomStartingPosition() * speed;
    }

    //Generates a random vector2 position that the ball will be launched to 
    private Vector2 RandomStartingPosition()
    {
        float startingAxisPosition = 1;
        
        return new Vector2(Random.Range(-startingAxisPosition, startingAxisPosition),
            Random.Range(-startingAxisPosition, startingAxisPosition));
    }

    //a public AddForce method to enforce encapsulation on the private rigidbody component
    public void AddForce(Vector2 force)
    {
        ballRb.AddForce(force);
    }

    public void SpawnBall()
    {
        Instantiate()
    }
    
    
    


}
