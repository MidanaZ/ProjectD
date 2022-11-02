using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinBehavior : MonoBehaviour
{
    public Transform player;
    public float speed = 1f;
    public Animator animator;
    public Rigidbody2D rb;
    public LayerMask PlayerLayer;
    public Transform AttackPoint;
    public float AttackRange = 0.5f;
    public int MeleeDamage = 20;

    bool isFlipped = false;
    bool isAttack = false;
    bool Islook = true;

    void LookAtPlayer()
    {
        if (transform.position.x < player.position.x)
        {
            isFlipped = false;
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }
        if (transform.position.x > player.position.x)
        {
            isFlipped = true;
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }
    }
    private void Update()
    {
        if (Islook == true)
        {
            LookAtPlayer();
        }
        //Detection Range
        if (transform.position.x < (player.position.x + 10) && transform.position.x > player.position.x)
        {
            animator.SetBool("Movement", true);
            transform.localPosition += new Vector3(-speed * Time.deltaTime, 0, 0);
        }
        if (transform.position.x > (player.position.x - 10) && transform.position.x < player.position.x)
        {
            animator.SetBool("Movement", true);
            transform.localPosition += new Vector3(speed * Time.deltaTime, 0, 0);
        }
        if ((transform.position.x < (player.position.x + 2)) && (transform.position.x > (player.position.x - 2)))
        {
            GoblinAttack();
        }
        //Set Idle Animation         LEFT                                       RIGHT                               
        if (transform.position.x > (player.position.x + 10) || transform.position.x < (player.position.x - 10))
        {
            animator.SetBool("Movement", false);
        }
    }
    public void GoblinAttack()
    {
        Islook = false;
        animator.SetBool("Attack", true);
        speed = 0;
    }
    public void GoblinStopAttack()
    {
        Islook = true;
        animator.SetBool("Attack", false);
        speed = 1;
    }
    void OnDrawGizmosSelected()
    {
        if (AttackPoint == null)
            return;

        Gizmos.DrawWireSphere(AttackPoint.position, AttackRange);
    }
    void DamagePlayer()
    {
        Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(AttackPoint.position, AttackRange, PlayerLayer);
        foreach (Collider2D player in hitPlayer)
        {
            player.GetComponent<PlayerHealth>().TakeDamage(MeleeDamage);
        }
    }



}
