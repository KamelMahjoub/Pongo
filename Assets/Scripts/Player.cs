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


 private void Start()
 {
     Init();
 }

 private void Update()
 {
    Move();
 }


 public void Init()
 {
     speed = 8.5f;
     playerRb = GetComponent<Rigidbody2D>(); 
 }
 
 public void Move()
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

 public bool CheckPlayerOne()
 {
     return isPlayerOne;
 }

 public Vector2 SetVelocity()
 {
     return new Vector2(playerRb.velocity.x , verticalInput * speed);
 }
 
 
 
 
}
