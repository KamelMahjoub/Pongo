using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float topBound;
    private float bottomBound;
    private float leftBound;
    private float rightBound;

    private void Awake()
    {
        Init();
    }

    private void Update()
    {
        DestroyBall();
    }

    private void Init()
    {
        topBound = 8f;
        bottomBound = -8f;
        leftBound = -10f;
        rightBound = 10;
    }

    private void DestroyBall()
    {
        Vector2 ballPosition = transform.position;

        if (ballPosition.x < leftBound || ballPosition.x > rightBound|| ballPosition.y > topBound || ballPosition.y < bottomBound)
        {
            Destroy(gameObject);
        }
    }

}
