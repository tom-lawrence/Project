using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpAnims : MonoBehaviour
{
    [SerializeField] Animator anim;
    [SerializeField] Rigidbody2D rb;
 

    // Update is called once per frame
    void Update()
    {
       if(rb.velocity.y > 0)
       {
            anim.SetBool("Jumping", true);
            anim.SetBool("Falling", false);
       }
       else if(rb.velocity.y < 0)
       {
           anim.SetBool("Jumping", false);
           anim.SetBool("Falling", true);
       }
       else if(rb.velocity.y == 0)
       {
           anim.SetBool("Jumping", false);
           anim.SetBool("Falling", false);
           anim.SetTrigger("Landed");

       }

        

    }




}
