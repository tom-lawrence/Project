using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BossHealth : MonoBehaviour
{
   

    public int maxHealth = 150;
    public int currentHealth;
    public HealthBar healthbar;


    void Start()
    {
        currentHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);

    }


    void Update()
    {
       

    }
    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthbar.SetHealth(currentHealth);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.CompareTag("Player"))
        {
            TakeDamage(10);
        }
    }

    void bossDeath()
    {
        //anim.play("Boss_Death");



        Debug.Log("Boss is dead");

        SceneManager.LoadScene("WinState");

    }













    
}

