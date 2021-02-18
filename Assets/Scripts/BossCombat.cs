using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCombat : MonoBehaviour
{
    //[SerializeField] Animator anim;
    [SerializeField] Transform swingHitbox;
    [SerializeField] float swingHitBoxRadius;
    [SerializeField] LayerMask playerLayer;
    [SerializeField] GameObject player;
    [SerializeField] GameObject maceProjPrefab;

    Health bossHealth;

    //Below are the times the boss cant use another attack after using 
    [SerializeField] float maceThrowCooldown;
    [SerializeField] float swingCooldown;
    [SerializeField] float stompCooldown;

    [SerializeField] float maceMeleeRange;      //Range player has to be in for the boss to use the melee attack.
    [SerializeField] int swingDamage;
    [SerializeField] float maceProjSpeed;

    private float attackCooldown = 0;    //the amount of time a boss has before it can use another attack.
    [SerializeField] float initBossLockout;

    private int swinglockout;
    [SerializeField] float swingTimeBeforeDamage;

    [SerializeField] Animator anim;


    void Start()
    {
        bossHealth = GetComponent<Health>();

        attackCooldown = initBossLockout;
    }


    // Update is called once per frame
    void Update()
    {
        AI();
        if (Input.GetKeyDown(KeyCode.O))
            Swing();
    }


    void AI()
    {
        if (bossHealth.GetHP() < bossHealth.GetMaxHP())
        {
            BossMainPhase();
        }
    }

    void BossMainPhase()
    {
        attackCooldown -= Time.deltaTime;

        if (attackCooldown <= 0)
        {
            //If the player is in melee range, execute the melee attack.
            if (Vector2.Distance(transform.position, player.transform.position) <= maceMeleeRange)
            {
                attackCooldown = swingCooldown;
                anim.Play("Boss_Smash");
                Invoke(nameof(Swing), swingTimeBeforeDamage);

            }

            else
            {
                if (Random.Range(0, 1) <= 0.5)
                {
                    attackCooldown = maceThrowCooldown;
                    MaceThrow();
                }

                else
                {
                    attackCooldown = stompCooldown;
                    Stomp();

                }

            }
        }
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
            player.GetComponent<Health>().TakeDamage(swingDamage);
        }

    }

    void MaceThrow()
    {
        Debug.Log("mace thrown");
        GameObject maceproj = Instantiate(maceProjPrefab);
        maceproj.transform.position = transform.position;

        Debug.Log((player.transform.position - transform.position).ToString());
        maceproj.GetComponent<MaceProjectile>().Throw(player.transform.position - transform.position, maceProjSpeed);
    }

    void Stomp()
    {
        Debug.Log("stomp executed");
    }

    private void OnDrawGizmosSelected()
    {
        if (swingHitbox == null)
            return;

        //Show a circle where the swing AOE is in the Unity editor
        Gizmos.DrawWireSphere(swingHitbox.position, swingHitBoxRadius);
    }

}
