using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncySurface : MonoBehaviour
{
    private float bouncePower = 0.001f;
    private Ball ball;

    private void OnCollisionEnter2D(Collision2D col)
    {
        ball = col.gameObject.GetComponent<Ball>();
        if (ball != null)
        {
            Vector2 normal = col.contacts[0].normal;
            ball.AddForce(-normal * bouncePower);
        }
    }
}
