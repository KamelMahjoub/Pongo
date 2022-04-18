using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player :  Paddle
{
    
    private float verticalInput;
    //private Rigidbody2D playerRb;


 private void Awake()
 {
     Init();
 }

 private void Update()
 {
    Move();
 }

//Initializes the variables/properties
 private void Init()
 {
     speed = 9f;
 }
 
 //Checks for the player's type and moves the game object accordingly
 private void Move()
 {
     if (CheckPlayerOne())
     {
         verticalInput = Input.GetAxis("Vertical");
         paddleRb.velocity = SetVelocity();
     }
     else
     {
         verticalInput = Input.GetAxis("Vertical2");
         paddleRb.velocity = SetVelocity();
     }
      
 }

 //Checks if the player is player number one
 private bool CheckPlayerOne()
 {
     return gameObject.CompareTag("Player1");
 }

 //Create a new Vector2 as the position that the player/paddle will move to 
 private Vector2 SetVelocity()
 {
     return new Vector2(paddleRb.velocity.x , verticalInput * speed);
 }
}
