using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 100;
    public Animator animator;
    int currentHealth;
    public Rigidbody2D rb;
    public Collider2D collider;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamge(int damage)
    {
        currentHealth -= damage;

        animator.SetTrigger("Hurt");

        if(currentHealth <= 0)
        {
            Die();
            collider.GetComponent<Collider2D>().enabled = false;
        }
    }
    void Die()
    {
        animator.SetBool("IsDead", true);

        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        this.enabled = false;
        Destroy(gameObject);
    }

    // Update is called once per frame
    
}
