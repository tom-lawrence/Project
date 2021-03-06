﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashMove : MonoBehaviour
{
    const KeyCode DASH_BUTTON = KeyCode.Space;

    public float horizontal;
    float vertical;
    public Rigidbody2D rb;
    IEnumerator dashCoroutine;
    bool isDashing;
    bool canDash = true;
    float direction = 1;

    [SerializeField] float dashIFrames;
    
    [SerializeField] float force;
    [SerializeField] Animator anim;
    [SerializeField] Transform Player;
    [SerializeField] GameObject myPrefab;

    public PlayerCombat combatScript;

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

        if (Input.GetKeyDown(KeyCode.Space) && canDash == true && combatScript.lockoutTimer <=0)
        {
            //anim.SetTrigger("Dash");

            if (dashCoroutine != null)
            {
                
                StopCoroutine(dashCoroutine);
            }
            dashCoroutine = Dash(.1f, 1);
            GetComponent<Health>().StartIFramesTimer(dashIFrames);
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
        
        anim.SetTrigger("Dash");
        Instantiate(myPrefab, Player.position, new Quaternion(0,0,(horizontal * 90 - 90),0));
        SoundManager.PlaySound("PlayerDashFX");





        rb.velocity = Vector2.zero;
        yield return new WaitForSeconds(dashDuration);
        isDashing = false;
        rb.velocity = Vector2.zero;
        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
      

    }



}







