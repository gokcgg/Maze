 using System;
 using System.Collections;
using System.Collections.Generic;
 using UnityEditor.Animations;
 using UnityEngine;

 public class CharacterManager : MonoBehaviour
 {
     public Animator animator;

     public static event Action OnPlayerDeath;
     public static event Action OnFinish;

     public float moveSpeed = 5f;
     public float rotSpeed = 5f;
    

     public float health = 1.0f;

     private bool allowAction = false;
    
     public float jumpValue = 10.0f;
     private bool isOnFloor = true;

     public Rigidbody rb;

     private void OnEnable()
     {
         GameManager.OnPlayGame += AllowAction;
         GameManager.OnNotPlayGame += BanAction;

         Health.OnHealthCollected += Heal;
         BasicObstacle.OnBasicDamage += GetDamage;
         AdvancedObstacle.OnAdvancedDamage += Die;

     }

     private void OnDisable()
     {
         GameManager.OnPlayGame -= AllowAction;
         GameManager.OnNotPlayGame -= BanAction;

         Health.OnHealthCollected -= Heal;
         BasicObstacle.OnBasicDamage -= GetDamage;
         AdvancedObstacle.OnAdvancedDamage -= Die;

     }

     void Update()
     {
         
         float horizontalInput = Input.GetAxisRaw("Horizontal");
         float verticalInput = Input.GetAxisRaw("Vertical");
         
         if (allowAction)
         {
             if(Input.GetKeyDown(KeyCode.Space)) 
             {
                 if (isOnFloor) 
                 {
                     Vector3 newVelocity = new Vector3(rb.velocity.x, jumpValue, rb.velocity.z);
                     rb.velocity = newVelocity;                 
                 }
             }
             
             
             Vector3 movement = new Vector3(verticalInput, 0f,horizontalInput )  ;
             Vector3 movePosition = -transform.right * movement.x + transform.forward * movement.z;
             movePosition.Normalize();
             movePosition *= moveSpeed;
             rb.velocity = new Vector3(movePosition.x, rb.velocity.y, movePosition.z);

             
             if (horizontalInput != 0 || verticalInput != 0) 
                animator.SetBool("isWalking", true);
             else
                 animator.SetBool("isWalking", false);

             
             float mouseX = Input.GetAxis("Mouse X");
             transform.Rotate(Vector3.up * mouseX * rotSpeed);
             
             
             if (gameObject.transform.position.y <= 0.8f)
                 isOnFloor = true;
             else
             {
                 isOnFloor = false;
             }
         }
     }

     void Heal()
     {
         if (health <= 0.7f)
             health += 0.3f;
     }

     void AllowAction()
     {
         allowAction = true;

     }
     void BanAction()
     {
         
         allowAction = false;

     }
     void GetDamage()
     {
         
         health -= 0.35f;
         if (health <= 0)
         {
             Die();
         }
     }

     void Die()
     {
         rb.velocity = Vector3.zero;
         
         OnPlayerDeath?.Invoke();
     }

     private void OnCollisionEnter(Collision collision)
     {
         if (collision.gameObject.tag.Equals("Exit"))
         {
             OnFinish?.Invoke();
         }
     }
 }
