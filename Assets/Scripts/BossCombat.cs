using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCombat : MonoBehaviour
{
    //[SerializeField] Animator anim;
    [SerializeField] Transform swingHitbox;
    [SerializeField] float swingHitBoxRadius;
    [SerializeField] LayerMask playerLayer;




    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
            Swing();
    }

    void Swing ()
    {
        //anim.SetTrigger("swing");
        Debug.Log("swing executed");

        //If the player is hit by 
        Collider2D hitPlayer = Physics2D.OverlapCircle(swingHitbox.position, swingHitBoxRadius, playerLayer);

        if (hitPlayer != null)
        {
            Debug.Log("Player was hit");
        }

    }

    private void OnDrawGizmosSelected()
    {
        if (swingHitbox == null)
            return;

        //Show a circle where the swing AOE is in the Unity editor
        Gizmos.DrawWireSphere(swingHitbox.position, swingHitBoxRadius);
    }

}
