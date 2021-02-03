using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat_James : MonoBehaviour
{
    [SerializeField] Animator anim;
    [SerializeField] Transform heavyHitbox;
    [SerializeField] float heavyHitBoxRadius;
     
    [SerializeField] Transform lightHitbox;
    [SerializeField] float lightHitBoxRadius;
    [SerializeField] LayerMask enemiesLayer;

    [SerializeField] float lightAttackLockout;
    [SerializeField] float heavyAttackLockout;

    [SerializeField] float heavyAttackVulnerableTime;

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

    }

    //Player input goes here.
    void PlayerInput()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            LightAttack();
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            HeavyAttack();
        }

    }

    //Everything that happens when the light attack button is pressed.
    void LightAttack()
    {
        anim.SetTrigger("LightAttack"); //set trigger parameter to LightAttack

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(lightHitbox.position, lightHitBoxRadius, enemiesLayer);

        lockoutTimer = lightAttackLockout;

        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log(enemy.name + " was hit.");
        }

    }

    //Everything that happens when the heavy attack button is pressed.
    void HeavyAttack()
    {
        anim.SetTrigger("HeavyAttack");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(heavyHitbox.position, heavyHitBoxRadius, enemiesLayer);

        lockoutTimer = heavyAttackLockout;

        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log(enemy.name + " was hit.");
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