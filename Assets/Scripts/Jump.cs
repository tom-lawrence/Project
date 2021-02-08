using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    const KeyCode JUMP_BUTTON = KeyCode.W;

    [SerializeField] private LayerMask platformsLayerMask;
    [SerializeField] private float jumpVelocity = 10f;
    private CircleCollider2D circleCollider2d;
    private Rigidbody2D rigidbody2d;
    private bool canDoubleJump;

    public PlayerCombat_James combatScript;
    //Animator m_Animator;
    private void Awake()
    {
        
        rigidbody2d = transform.GetComponent<Rigidbody2D>();
        circleCollider2d = transform.GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        if(IsGrounded())
        {
            canDoubleJump = true;
        }

        if (Input.GetKeyDown(KeyCode.W) && combatScript.lockoutTimer <= 0)
        {
            if (IsGrounded())
            {

                
                rigidbody2d.velocity = Vector2.up * jumpVelocity;
                
            }
            else
            {
                if (canDoubleJump)
                {
                    
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

         RaycastHit2D raycastHit2d = Physics2D.BoxCast(circleCollider2d.bounds.center, circleCollider2d.bounds.size, 0f, Vector2.down ,.1f, platformsLayerMask);
         Debug.Log(raycastHit2d.collider);
         return raycastHit2d.collider != null;
        

     }
  
            
         


    
}
