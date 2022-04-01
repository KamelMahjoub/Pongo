using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float speed;
    private float verticalInput;
    private bool isPlayer1;
    private Rigidbody2D playerRb;


 private void Start()
 { 
     speed = 8;
    playerRb = GetComponent<Rigidbody2D>();
 }

 private void Update()
 {
     verticalInput = Input.GetAxis("Vertical");
     playerRb.velocity = new Vector2(playerRb.velocity.x , verticalInput * speed);
 }
 
 
 
 
 
}
