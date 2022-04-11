using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Variables")]
    
    [SerializeField] 
    private bool isPlayerOne;
    
    private float speed;
    private float verticalInput;

    private string playerOneGameObjectName;

    private Rigidbody2D playerRb;


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
     playerRb = GetComponent<Rigidbody2D>();
     speed = 9f;
     playerOneGameObjectName = "Player1";
 }
 
 //Checks for the player's type and moves the game object accordingly
 private void Move()
 {
     if (CheckPlayerOne())
     {
         verticalInput = Input.GetAxis("Vertical");
         playerRb.velocity = SetVelocity();
     }
     else
     {
         verticalInput = Input.GetAxis("Vertical2");
         playerRb.velocity = SetVelocity();
     }
      
 }

 //Checks if the player is player number one
 private bool CheckPlayerOne()
 {
     return isPlayerOne;
 }

 //Create a new Vector2 as the position that the player/paddle will move to 
 private Vector2 SetVelocity()
 {
     return new Vector2(playerRb.velocity.x , verticalInput * speed);
 }
 
 //gets the position where the ball has collided with the player
 // if it's 1, it's at the top; if it's 0, it's in the middle and if it's -1 it's at the bottom
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
     if (col.gameObject.name == playerOneGameObjectName) {
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
