using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    //Controls

    [SerializeField] KeyCode lightAttack;
    [SerializeField] KeyCode heavyAttack;


    [SerializeField] Animator anim;
    [SerializeField] Transform heavyHitbox;
    [SerializeField] float heavyHitBoxRadius;

    [SerializeField] Transform lightHitbox;
    [SerializeField] float lightHitBoxRadius;
    [SerializeField] LayerMask enemiesLayer;

    [SerializeField] float lightAttackLockout;
    [SerializeField] float heavyAttackLockout;

    [SerializeField] float timeBeforeHeavyAttack;
    [SerializeField] float timeBeforeLightAttack;

    [SerializeField] int lightAttackDamage;
    [SerializeField] int heavyAttackDamage;


    [SerializeField] float heavyAttackVulnerableTime;

    //[SerializeField] GameObject playerSlider;

    public float lockoutTimer = 0;

    public bool heavyAttackVulnerable = false;


    // Update is called once per frame
    void Update()
    {
        if (lockoutTimer >= 0)
        {
            //if it is the first x seconds of the heavy attack, make the player vulnerable.
            if (lockoutTimer >= heavyAttackLockout - heavyAttackVulnerableTime)
                heavyAttackVulnerable = true;
            else
                heavyAttackVulnerable = false;


            lockoutTimer -= Time.deltaTime;
        }
        else
            //If the lockout timer is zero, allow the player to input.
            PlayerInput();

        //playerSlider.GetComponent<PlayerSlider>().SetPlayerHealth(GetComponent<Health>().GetHP());
      
    }

    //Player input goes here.
    void PlayerInput()
    {

        if (Input.GetKeyDown(lightAttack))
        {
            anim.SetTrigger("LightAttack"); //set trigger parameter to LightAttack
            lockoutTimer = lightAttackLockout;
            Invoke(nameof(LightAttack), timeBeforeLightAttack);
        }

        if (Input.GetKeyDown(heavyAttack))
        {
           
            anim.SetTrigger("HeavyAttack");
            lockoutTimer = heavyAttackLockout;
            Invoke(nameof(HeavyAttack), timeBeforeHeavyAttack);
        }

    }

    //Everything that happens when the light attack button is pressed.
    void LightAttack()
    {

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(lightHitbox.position, lightHitBoxRadius, enemiesLayer);

        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log(enemy.name + " was hit.");
            enemy.gameObject.GetComponent<Health>().TakeDamage(lightAttackDamage);
        }

    }

    //Everything that happens when the heavy attack button is pressed.
    void HeavyAttack()
    {

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(heavyHitbox.position, heavyHitBoxRadius, enemiesLayer);


        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log(enemy.name + " was hit.");
            enemy.gameObject.GetComponent<Health>().TakeDamage(heavyAttackDamage);

        }

    }

    private void OnDrawGizmosSelected()
    {
        if (lightHitbox == null)
            return;

        //Show a circle where the light attack AOE is in the Unity editor
        Gizmos.DrawWireSphere(lightHitbox.position, lightHitBoxRadius);


        if (heavyHitbox == null)
            return;

        //Show a circle where the heavy attack AOE is in the Unity editor
        Gizmos.DrawWireSphere(heavyHitbox.position, heavyHitBoxRadius);
    }

}