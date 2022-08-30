using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   [SerializeField] private ScreenTouchController input;
   [SerializeField] private Rigidbody playerRB;
   public float moveSpeed;
   private void Update()
   {
      var direction = new Vector3(input.direction.x, 0, input.direction.y);
      Move(direction);
   }

   private void Move(Vector3 Direction)
   {
      playerRB.velocity = Direction*moveSpeed*Time.deltaTime;
   }

   private void OnCollisionEnter(Collision collision)
   {
      if (collision.transform.CompareTag("Enemy"))
      {
         Dead();
      }
   }

   private void OnTriggerEnter(Collider other)
   {
      if (other.transform.CompareTag("Enemy"))
      {
         //Destroy(other.gameObject);
      }
   }

   private void Dead()
   {
      Debug.Log("Dead");
      Time.timeScale = 0;
   }
}