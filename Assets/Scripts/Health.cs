using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    [SerializeField] int maxHealth = 10;

    private int health;

    [SerializeField] KeyCode damageTestButton;
    [SerializeField] int damageTestAmount;
    [SerializeField] GameObject enemy;
    [SerializeField] GameObject player;
    [SerializeField] GameObject bossSlider;
    [SerializeField] GameObject playerSlider;

    //[SerializeField] Animator anim;


    /*
    public PlayerMovement mov;

    public PlayerCombat com;

    public Jump jump;

    public DashMove dash;

    public Rigidbody2D rb;
    */


    public SpriteRenderer sprite;

    [SerializeField] float DamageIFramesTime;
    private bool isInvincible = false;


    // Start is called before the first frame update
    void Start()
    {
        //Initialise the health values.
        health = maxHealth;

        
        //playerSlider.GetComponent<PlayerSlider>().SetPlayerMaxHealth(health); 
        //bossSlider.GetComponent<BossSlider>().SetBossMaxHealth(health); 

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(damageTestButton))
            TakeDamage(damageTestAmount);
    }

    public void TakeDamage(int damage)
    {
        if (!isInvincible)
        {
            health -= damage;
           
            TakeDamageFX();

            //determine damage frame for player
            StartCoroutine(FlashRed());

            //if the player's health drops below 1, kill the player
            if (health <= 0)
                Die();
            else
                StartIFramesTimer(DamageIFramesTime);

            UpdateHP();
        }

    }

    public int GetHP()
    {
        return health;
    }
    public int GetMaxHP()
    {
        return maxHealth;
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
        /*
            anim.Play("Player_Death");

            mov.enabled = false;

            com.enabled = false;

            jump.enabled = false;

            dash.enabled = false;

            rb.isKinematic = true;

            Destroy(gameObject, .65f);
        */

        //Game over routine is called here.
        Debug.Log("player dead");
    }

    void UpdateHP()
    {
        //Updates for UI go here.
        Debug.Log("hp updated");
    }


    private void IFramesOff()    //Called when i-frames are over.
    {
        isInvincible = false;
    }


    public void StartIFramesTimer(float iFramesTime)    //Called by another script when i-frames should start.
    {
        isInvincible = true;
        Invoke(nameof(IFramesOff), iFramesTime);
    }


    public bool GetIsInvincible()    //Allows state of invicibility to be fetched externally.
    {
        return isInvincible;
    }



    public IEnumerator FlashRed()

    {

        sprite.color = Color.red;

        yield return new WaitForSeconds(0.2f);

        sprite.color = Color.white;

    }

    public void TakeDamageFX()
    {
        if(player.tag == "Player")
        {
            SoundManager.PlaySound("PlayerPainFX");
        }
        else if (player.tag == "Enemy")
        {
            SoundManager.PlaySound("BossPainFX");
        }
    }
    

}