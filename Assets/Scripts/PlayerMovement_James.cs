using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement_James : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    
    // For setting animation values
    [SerializeField] Animator animator;

    public PlayerCombat_James combatScript;

    [SerializeField] float BASE_SPEED;

    private KeyCode LEFT_BUTTON = KeyCode.A;
    private KeyCode LEFT_BUTTON_ALT = KeyCode.LeftArrow;

    private KeyCode RIGHT_BUTTON = KeyCode.D;
    private KeyCode RIGHT_BUTTON_ALT = KeyCode.RightArrow;

    bool facingRight = true;

    // Update is called once per frame
    void Update()
    {
        //If the player is locked out.
        if (combatScript.lockoutTimer <= 0)
            PlayerInput();
        else
            ResetVelocity();

        SetAnimations();
    }

    //Player input goes here
    void PlayerInput()
    {

        if (Input.GetKey(LEFT_BUTTON) || Input.GetKey(LEFT_BUTTON_ALT))
        {
            MoveLeft();

            if (facingRight)
                FlipPlayer();

            facingRight = false;
        }

        else if (Input.GetKey(RIGHT_BUTTON) || Input.GetKey(RIGHT_BUTTON_ALT))
        {
            MoveRight();

            if (!facingRight)
                FlipPlayer();

            facingRight = true;
        }

        else if (rb.velocity.x != 0)
        {
            ResetVelocity();
        }
    }

    //Turn the player in the direction they are moving.
    void FlipPlayer()
    {
        transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
    }

    //Ran when player inputs to move left
    void MoveLeft()
    {
        rb.velocity = new Vector2(-BASE_SPEED, rb.velocity.y);
    }


    //Ran when player inputs to move left
    void MoveRight()
    {
        rb.velocity = new Vector2(BASE_SPEED, rb.velocity.y);
    }

    //Ran when the player isnt inputting any horizontal movement.
    void ResetVelocity()
    {
        rb.velocity = new Vector2(0, rb.velocity.y);
    }

    void SetAnimations()
    {
        float animMove;

        // Determines if the character is moving for anim transition.
        animMove = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("Move", Mathf.Abs(animMove * BASE_SPEED));
    }
}
