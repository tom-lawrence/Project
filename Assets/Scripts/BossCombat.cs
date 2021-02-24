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
    [SerializeField] GameObject spearPrefab;

    Health bossHealth;

    //Below are the times the boss cant use another attack after using 
    [SerializeField] float maceThrowCooldown;
    [SerializeField] float swingCooldown;
    [SerializeField] float stompCooldown;

    [SerializeField] float maceMeleeRange;      //Range player has to be in for the boss to use the melee attack.
    [SerializeField] int swingDamage;
    [SerializeField] float maceProjSpeed;
    [SerializeField] float spearSpeed;

    private float attackCooldown = 0;    //the amount of time a boss has before it can use another attack.
    [SerializeField] float initBossLockout;

    private int swinglockout;
    [SerializeField] float swingTimeBeforeDamage;

    [SerializeField] Animator anim;

    [SerializeField] int swapOrder = 0;
    [SerializeField] bool isTPing = false;
    [SerializeField] Vector2 TopLeftPos;
    [SerializeField] Vector2 BottomRightPos;
    [SerializeField] Vector2 BottomLeftPos;
    [SerializeField] Vector2 TopRightPos;

    private int noOfAtks = 0;
    [SerializeField] int atksToTP;
    [SerializeField] GameObject bossSlider;

    private int dir = 1;
    void Start()
    {
        bossHealth = GetComponent<Health>();

        attackCooldown = initBossLockout;

        Teleport();
        Flip();
    }


    // Update is called once per frame
    void Update()
    {
        AI();
        if (Input.GetKeyDown(KeyCode.O))
            Swing();

        //bossSlider.GetComponent<BossSlider>().SetBossHealth(GetComponent<Health>().GetHP());
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

            if (noOfAtks >= atksToTP)
            {
                SoundManager.PlaySound("TeleportFX");
                StartCoroutine(TPEnum());
                
                noOfAtks = 0;
            }

            if (isTPing == false)
            {
                noOfAtks++;

                //If the player is in melee range, execute the melee attack.
                if (Vector2.Distance(transform.position, player.transform.position) <= maceMeleeRange)
                {
                    if (Random.Range(0, 100) > 50)
                    {
                        attackCooldown = swingCooldown;
                        anim.Play("Boss_Smash");
                        Invoke(nameof(Swing), swingTimeBeforeDamage);
                    }

                    else
                    {
                        anim.Play("Boss_Arrow");
                        attackCooldown = stompCooldown;
                        StartCoroutine(StompEnum());
                    }
                }
                
                else
                {
                
                    if (Random.Range(0, 100) > 65)
                    {
                        anim.Play("Boss_Arrow");
                        attackCooldown = stompCooldown;
                        StartCoroutine(StompEnum());
                    }

                    else
                    {
                        attackCooldown = maceThrowCooldown;
                        anim.Play("Boss_Yeet");
                        StartCoroutine(MaceThrowEnum());
                    }
                }
            }
        }
    }


    void Swing ()
    {
        //anim.SetTrigger("swing");
        Debug.Log("swing executed");
        //SoundManager.PlaySound("BossSwingFX");

        //If the player is hit by


        Collider2D hitPlayer = Physics2D.OverlapCircle(swingHitbox.position, swingHitBoxRadius, playerLayer);

        if (hitPlayer != null)
        {
            Debug.Log("Player was hit");
            player.GetComponent<Health>().TakeDamage(swingDamage);

        }

    }

    public IEnumerator MaceThrowEnum()
    {
        yield return new WaitForSeconds(1f);
        MaceThrow();
        yield return new WaitForSeconds(1f);
    }
    public IEnumerator SwingEnum()
    {
        yield return new WaitForSeconds(1f);
        Swing();
       
    }
    public IEnumerator StompEnum()
    {
        yield return new WaitForSeconds(1f);
        Stomp();
        yield return new WaitForSeconds(2f);
    }
    public IEnumerator TPEnum()
    {
        isTPing = true;
        anim.Play("Boss_TP");
        yield return new WaitForSeconds(0.3f);
        
        Teleport();
        yield return new WaitForSeconds(0.3f);
        isTPing = false;
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
        for(int i = 0; i < 10 ; i += 2)
        {
        GameObject spear = Instantiate(spearPrefab);
        spear.transform.position = transform.position + new Vector3(30 * dir + Random.Range(1,30),i - 4, 0);
        //spear.transform.position = new Vector3(spear.transform.position.x, spear.transform.position.y, 0.5f);
        spear.transform.localScale *= dir;

        spear.GetComponent<Spears>().Launch(spearSpeed, dir);
        }
    }

    void Teleport()
    {

        

        if (swapOrder == 0)
        {
            transform.position = BottomRightPos;
            ++swapOrder;
        }
        else if (swapOrder == 1) 
        {
            transform.position = TopLeftPos;
            ++swapOrder;
        }
        else if (swapOrder == 2)
        {
            transform.position = TopRightPos;
            ++swapOrder;
        }
        else
        {
            transform.position = BottomLeftPos;
            swapOrder = 0;
        }

        Flip();

    }

    void Flip()
    {
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        dir *= -1;
    }

    private void OnDrawGizmosSelected()
    {
        if (swingHitbox == null)
            return;

        //Show a circle where the swing AOE is in the Unity editor
        Gizmos.DrawWireSphere(swingHitbox.position, swingHitBoxRadius);
    }

}
