using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashMove : MonoBehaviour
{

    float horizontal;
    float vertical;
    Rigidbody2D rb;
    IEnumerator dashCoroutine;
    bool isDashing;
    bool canDash = true;
    float direction = 1;
    float normalGravity;


    //Start is called before first frame update

    void start()
    {
        rb = GetComponent<Rigidbody2D>();
    }





    void Update ()
    {
        if(horizontal != 0)
        {
            direction = horizontal;
        }

        horizontal = Input.GetAxisRaw("Horizontal");
        //vertical = Input.GetAxisRaw("Jump");

        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash == true)
        {
            if(dashCoroutine != null)
            {
                StopCoroutine(dashCoroutine);
            }
            dashCoroutine = Dash(.1f, 1);
            StartCoroutine(dashCoroutine);


        }


    }

    private void FixedUpdate()
    {
        rb.AddForce(new Vector2(horizontal * 20, 0));
        //rb.AddForce(new Vector2(0, vertical), ForceMode2D.Impulse;

        if (isDashing)
        {
            rb.AddForce(new Vector2(direction * 10, 0), ForceMode2D.Impulse);
        }
       
    }


    IEnumerator Dash(float dashDuration , float dashCooldown)
    {
        isDashing = true;
        canDash = false;
        rb.gravityScale = 0;
        rb.velocity = Vector2.zero;
        yield return new WaitForSeconds(dashDuration);
        isDashing = false;
        rb.velocity = Vector2.zero;
        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
       
    }



}







