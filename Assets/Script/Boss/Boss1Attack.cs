using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1Attack : MonoBehaviour
{
    public Transform player;
    public Transform AttackPoint;
    public Animator animator;
    public float AttackRange = 0.5f;
    public int MeleeDamage = 20;
    public float speed = 1f;

    public GameObject Attack3Prefab;

    public float TimeRangeAttack;

    public LayerMask PlayerLayer;

    public bool isAttack = false;
    public bool Islook = true;

    void LookAtPlayer()
    {
        if (transform.position.x < player.position.x)
        {
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }
        if (transform.position.x > player.position.x)
        {
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }
    }

    private void Update()
    {
        if (Islook == true)
        {
            LookAtPlayer();
        }

        //Detection Range
        if (transform.position.x < (player.position.x + 7) && transform.position.x > player.position.x)
        {
            animator.SetBool("Run", true);
            transform.localPosition += new Vector3(-speed * Time.deltaTime, 0, 0);
        }
        if (transform.position.x > (player.position.x - 7) && transform.position.x < player.position.x)
        {
            animator.SetBool("Run", true);
            transform.localPosition += new Vector3(speed * Time.deltaTime, 0, 0);
        }
        if ((transform.position.x < (player.position.x + 2)) && (transform.position.x > (player.position.x - 2)))
        {
            animator.SetBool("Run", false);
            Attack();
        }
        //Set Idle Animation         LEFT                                       RIGHT                               
        if (transform.position.x > (player.position.x + 7) || transform.position.x < (player.position.x - 7))
        {
            animator.SetBool("Run", false);
            TimeRangeAttack += Time.deltaTime;
        }
        //Range Attack
        if (TimeRangeAttack >= 5)
        {
            animator.SetBool("Attack3", true);
            TimeRangeAttack = 0;
        }


    }

    void DamagePlayer()
    {
        Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(AttackPoint.position, AttackRange, PlayerLayer);
        foreach (Collider2D player in hitPlayer)
        {
            player.GetComponent<PlayerHealth>().TakeDamage(MeleeDamage);
        }
    }
    public void Attack()
    {
        Islook = false;
        animator.SetBool("Attack1", true);
        speed = 0;
    }

    public void AfterAttack()
    {
        Islook = true;
        animator.SetBool("Attack1", false);
        speed = 2;
    }

    public void AfterAttack3()
    {
        Islook = true;
        animator.SetBool("Attack3", false);
    }
    public void Attack3()
    {
        Instantiate(Attack3Prefab, player.position, player.rotation);
    }
}
