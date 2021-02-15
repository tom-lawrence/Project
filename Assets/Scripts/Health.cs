using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    [SerializeField] int maxHealth;

    private int health;

    [SerializeField] KeyCode damageTestButton;
    [SerializeField] int damageTestAmount;

    [SerializeField] Animator anim;
    [SerializeField] Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {
        //Initialise the health values.
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(damageTestButton))
            TakeDamage(damageTestAmount);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        //determine damage frame for player
        playAnim();
        //if the player's health drops below 1, kill the player
        if (health <= 0)
            Die();

        UpdateHP();
    }

    public void Heal(int amount)
    {
        //If the player is healed over the max, set the health to the max.
        if (health + amount >= maxHealth)
            health = maxHealth;
        else
            //otherwise heal the player
            health += amount;

        UpdateHP();
    }

    void Die()
    {
        //Game over routine is called here.
        Debug.Log("player dead");
    }

    void UpdateHP()
    {
        //Updates for UI go here.
        Debug.Log("hp updated");
    }

    void playAnim()
    {
        if (rb.velocity.y > 0)
            anim.Play("PlayerJumpDamage");
        
        else if (rb.velocity.y < 0)
            anim.Play("PlayerFallDamage");
        
        else if (Mathf.Abs(rb.velocity.x) > 0)
            anim.Play("PlayerRunDamage");

     



    }
}