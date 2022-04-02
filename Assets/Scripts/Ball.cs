using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Ball : MonoBehaviour
{

    private Rigidbody2D ballRb;
    [SerializeField]
    private float speed;

    private Vector2 x;

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
        ballRb.velocity = RandomStartingPosition() * speed;
    }

    private Vector2 RandomStartingPosition()
    {
        float startingAxisPosition = 1;
        
        return new Vector2(Random.Range(-startingAxisPosition, startingAxisPosition),
            Random.Range(-startingAxisPosition, startingAxisPosition));
    }

    public void AddForce(Vector2 force)
    {
        ballRb.AddForce(force);
    }
    
    
    


}
