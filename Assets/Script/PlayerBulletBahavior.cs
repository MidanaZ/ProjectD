using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletBahavior : MonoBehaviour
{
    public float speed = 20f;
    public int Damage = 40;
    public Rigidbody2D Rb;
    public Collider2D collider2D;
    public Animator animator;
    public float DisapearTimer;
    void Start()
    {
        Rb.velocity = transform.right * speed;
    }
    void Update()
    {
        DisapearTimer += Time.deltaTime;
        if(DisapearTimer > 1)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamge(Damage);
        }

        //BOSSHealth boss = hitInfo.GetComponent<BOSSHealth>();
        //if (boss != null)
        //{
        //    boss.TakeDamage(Damage);
        //}

        animator.SetBool("OnHit",true);
        Rb.velocity = transform.right * 0;
        collider2D.enabled = false;
    }

    public void Dissaper()
    {
        Destroy(gameObject);
    }
}
