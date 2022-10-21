using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int MaxHealth = 100;
    public int CurrentHealth;
    public Animator animator;
    public Rigidbody2D rb;
    public Collider2D collider;


    void Start()
    {
        CurrentHealth = MaxHealth;
    }
    public void TakeDamage(int Damage)
    {
        CurrentHealth -= Damage;
        if (CurrentHealth <= 0)
        {
            DeadAnimaton();
            collider.GetComponent<Collider2D>().enabled = false;
        }
    }
    public void DeadAnimaton()
    {
        animator.SetTrigger("IsDead");
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
    }

    void Die()
    {
        Destroy(gameObject);   
    }
}
