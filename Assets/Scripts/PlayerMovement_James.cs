using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement_James : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;

    [SerializeField] float BASE_SPEED;

    [SerializeField] KeyCode LEFT_BUTTON;

    [SerializeField] KeyCode RIGHT_BUTTON;

    bool facingRight = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(LEFT_BUTTON))
        {
            MoveLeft();

            if (facingRight)
                FlipPlayer();

            facingRight = false;
        }

        else if (Input.GetKey(RIGHT_BUTTON))
        {
            MoveRight();

            if (!facingRight)
                FlipPlayer();

            facingRight = true;
        }

        if (!Input.GetKey(LEFT_BUTTON) && !Input.GetKey(RIGHT_BUTTON) && rb.velocity.x != 0)
        {
            ResetVelocity();
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
    }
}
