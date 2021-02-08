using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashMove : MonoBehaviour
{

    float horizontal;
    float vertical;
    public Rigidbody2D rb;
    IEnumerator dashCoroutine;
    bool isDashing;
    bool canDash = true;
    float direction = 1;
    
    [SerializeField] float force;


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

        if (Input.GetKeyDown(KeyCode.E) && canDash == true)
        {
            if(dashCoroutine != null)
            {
                StopCoroutine(dashCoroutine);
            }
            dashCoroutine = Dash(.1f, 1);
            StartCoroutine(dashCoroutine);


        }






    }

     void FixedUpdate()
    {
       
      

        if (isDashing)
        {
            rb.AddForce(new Vector2(direction * force, 0), ForceMode2D.Impulse);
        }
       
    }


    IEnumerator Dash(float dashDuration , float dashCooldown)
    {
        isDashing = true;
        canDash = false;
       
        rb.velocity = Vector2.zero;
        yield return new WaitForSeconds(dashDuration);
        isDashing = false;
        rb.velocity = Vector2.zero;
        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
      

    }



}







