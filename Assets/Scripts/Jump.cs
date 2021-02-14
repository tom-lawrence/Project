using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    const KeyCode JUMP_BUTTON = KeyCode.W;

    [SerializeField] private LayerMask platformsLayerMask;
    [SerializeField] float firstjumpVelocity = 10f;
    [SerializeField] float secondjumpVelocity = 15;

    [SerializeField] Transform Player;
    [SerializeField] GameObject landEffectPrefab;
    [SerializeField] GameObject doubleJumpEffectPrefab;
    [SerializeField] bool hasLeftGround;

    private CircleCollider2D circleCollider2d;
    private Rigidbody2D rigidbody2d;
    private bool canDoubleJump;
    public PlayerCombat combatScript;


    //Animator m_Animator;
    [SerializeField] Animator anim;

    private void Awake()
    {
        
        rigidbody2d = transform.GetComponent<Rigidbody2D>();
        circleCollider2d = transform.GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        animCheck();

        if(IsGrounded())
        {
            canDoubleJump = true;
            anim.SetTrigger("Landed");
            //anim for landing trigger called
        }

        if (Input.GetKeyDown(JUMP_BUTTON) && combatScript.lockoutTimer <= 0)
        {
            if (IsGrounded())
            {

                
                rigidbody2d.velocity = Vector2.up * firstjumpVelocity;
                
            }
            else if (canDoubleJump)
            {
                anim.Play("Player_DoubleJumpSetup");
                Instantiate(doubleJumpEffectPrefab, new Vector3(Player.position.x, Player.position.y - 0.5f, Player.position.z), doubleJumpEffectPrefab.transform.rotation);
                rigidbody2d.velocity = Vector2.up * secondjumpVelocity;
                canDoubleJump = false;
            }
            
        }

        
        //Send the message to the Animator to activate the trigger parameter named "Jump"
        //m_Animator.SetTrigger("Jump");

    }


    //Checks to see if player is grounded, (Using raycast box collider)
     private bool IsGrounded()
     {
         RaycastHit2D raycastHit2d = Physics2D.BoxCast(circleCollider2d.bounds.center, circleCollider2d.bounds.size, 0f, Vector2.down ,.1f, platformsLayerMask);
         //Debug.Log(raycastHit2d.collider);
         return raycastHit2d.collider != null;
     }
  
         void animCheck()
    {
        if (!IsGrounded())
        {
            hasLeftGround = true;
        }
        if (hasLeftGround == true && IsGrounded())
        {
            Instantiate(landEffectPrefab, new Vector3(Player.position.x, Player.position.y + 1.25f, Player.position.z), new Quaternion(0, 0, 0, 0));
            hasLeftGround = false;
        }
    }




}
