using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMeleeAttack : MonoBehaviour
{
    public Animator animator;
    public int combo;
    public bool atacando;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayer;
    public LayerMask bossLayer;
    public int Damage = 20;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z))
        {
            Attack();
            AttackBoss();
        }
    }
    void Attack()
    {
        //atacando = true;
        animator.SetTrigger(""+combo);
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);
        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamge(Damage);
        }
    }
    void AttackBoss()
    {
        //atacando = true;
        animator.SetTrigger("" + combo);
        Collider2D[] hitBoss = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, bossLayer);
        foreach (Collider2D boss in hitBoss)
        {
            boss.GetComponent<Boss1Health>().TakeDamage(Damage);
        }
    }
    public void Start_Combo()
    {
        //atacando=false;
        if (combo < 3)
        {
            combo++;
        }
    }
    public void Finish_Ani()
    {
        //atacando = false;
        combo = 0;
    }
    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
