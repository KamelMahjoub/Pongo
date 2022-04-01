using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    
    private float speed;
    private float speedMultiplier;

    private float xPosition;
    private float yPosition;

    private float xPositionLimit;
    private float yPositionLimit;
    
    private Rigidbody2D ballRb;
    void Start()
    {
        Init();
        Move();
    }
    
    void Update()
    {
        StartCoroutine(ImproveBallSpeedRoutine());
    }

    private void Init()
    {
        ballRb = GetComponent<Rigidbody2D>();
        speed = 5;
        speedMultiplier = 1.2f;
        xPositionLimit = 4.6f;
        yPositionLimit = 17;
    }

    private void AddSpeed()
    {
        speed *= speedMultiplier;
    }

    IEnumerator ImproveBallSpeedRoutine()
    {
        yield return new WaitForSeconds(3);
        AddSpeed();
    }

    private float RandomPosition(float posLimit)
    {
        return Random.Range(-posLimit, posLimit);
    }

    private void Move()
    {
        ballRb.velocity = new Vector2(RandomPosition(xPositionLimit), RandomPosition(yPositionLimit));
    }
    
    
    
    
}
