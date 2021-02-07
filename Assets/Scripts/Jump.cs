using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    [SerializeField] private LayerMask platformsLayerMask;
    private BoxCollider2D boxCollider2d;
    private Rigidbody2D rigidbody2d;
    private bool canDoubleJump;
    //Animator m_Animator;
    private void Awake()
    {
        
        rigidbody2d = transform.GetComponent<Rigidbody2D>();
        boxCollider2d = transform.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        if(IsGrounded())
        {
            canDoubleJump = true;
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            if (IsGrounded())
            {

                float jumpVelocity = 10f;
                rigidbody2d.velocity = Vector2.up * jumpVelocity;
                
            }
            else
            {
                if (canDoubleJump)
                {
                    float jumpVelocity = 10f;
                    rigidbody2d.velocity = Vector2.up * jumpVelocity;
                    canDoubleJump = false;
                }



            }

            //Send the message to the Animator to activate the trigger parameter named "Jump"
            //m_Animator.SetTrigger("Jump");

        }



    }

    //Checks to see if player is grounded, (Using raycast box collider)
     private bool IsGrounded()
     {

         RaycastHit2D raycastHit2d = Physics2D.BoxCast(boxCollider2d.bounds.center, boxCollider2d.bounds.size, 0f, Vector2.down ,.1f, platformsLayerMask);
         Debug.Log(raycastHit2d.collider);
         return raycastHit2d.collider != null;
        

     }
  
            
         


    
}
