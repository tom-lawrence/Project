using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat_James : MonoBehaviour
{
    [SerializeField] Animator anim;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }


    }


    void Attack()
    {
        anim.SetTrigger("Attack");
    }

    
}