using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    //For application of health slider decling (POST Sprite APP)
    public Slider slider;
   
    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;

    }

    public void SetHealth (int health)
    {
        slider.value = health;
    }


    //following is code for player health to be implemented & tested







    //void Update()
     //{ if (Input.GetKeyDown(KeyCode.Space))
            //{ TakeDamage(20);
    //}

    //void TakeDamage (int damage)
    //{ currentHealth -= damage;


    //healthBar.SetHealth(CurrentHealth);
}
        
   

   

