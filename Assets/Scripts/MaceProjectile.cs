using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaceProjectile : MonoBehaviour
{
    [SerializeField] float rotationAngle;
    [SerializeField] LayerMask playerLayer;
    [SerializeField] Transform maceProjHitbox;
    [SerializeField] float maceProjHitboxRadius;

    [SerializeField] int maceProjectileDamage;

    public Rigidbody2D rb;

    private bool playerHit = false;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, rotationAngle * Time.deltaTime);

        Collider2D hitPlayer = Physics2D.OverlapCircle(maceProjHitbox.position, maceProjHitboxRadius, playerLayer);

        if (hitPlayer != null && playerHit == false)
        {
            Debug.Log("Player was hit");
            hitPlayer.GetComponent<Health>().TakeDamage(maceProjectileDamage);
            playerHit = true;
        }
    }

    public void Throw(Vector2 velocity)
    {
        rb.velocity = velocity;
        Debug.Log(rb.velocity.ToString());
    }


    private void OnDrawGizmosSelected()
    {
        if (maceProjHitbox == null)
            return;

        //Show a circle where the swing AOE is in the Unity editor
        Gizmos.DrawWireSphere(maceProjHitbox.position, maceProjHitboxRadius);
    }

}