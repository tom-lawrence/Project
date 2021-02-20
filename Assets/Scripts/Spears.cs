using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spears : MonoBehaviour
{
    public Rigidbody2D rb;

    [SerializeField] LayerMask playerLayer;

    [SerializeField] float timeOnScreen;

    [SerializeField] int spearDamage;

    private bool playerHit = false;

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "MainPlayer")
            collision.gameObject.GetComponent<Health>().TakeDamage(spearDamage);
    }

    public void Launch(float speed, int dir)
    {
        rb.velocity = new Vector2(-dir * speed, 0);
        Invoke(nameof(DestroyThis), timeOnScreen);
    }

    private void DestroyThis()
    {
        Destroy(gameObject);
    }

}