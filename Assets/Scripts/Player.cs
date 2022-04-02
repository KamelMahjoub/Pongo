using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float speed;
    private float verticalInput;
    
    [SerializeField] 
    private bool isPlayerOne;
    
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
     speed = 8.5f;
     playerRb = GetComponent<Rigidbody2D>(); 
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
 
 
 
 
}
