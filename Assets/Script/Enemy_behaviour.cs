using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_behaviour : MonoBehaviour
{
    public Transform rayCast;
    public LayerMask raycastMask;
    public float rayCastLenght;
    public float attackDistance;
    public float moveSpeed;
    public float timer;
    public int MeleeDamage = 20;

    private RaycastHit2D hit;
    private GameObject target;
    private Animator anim;
    private float distance;
    private bool attackMode;
    private bool inRange;
    private bool cooling;
    private float intTimer;

     void Awake()
    {
        intTimer = timer;
        anim = GetComponent<Animator>();
    }


    // Update is called once per frame
    void Update()
    {
        if (inRange)
        {
            hit = Physics2D.Raycast(rayCast.position, Vector2.left, rayCastLenght, raycastMask);
            RaycastDebugger();
            
        }
        //when player is detected
        if(hit.collider != null)
        {
            EnemyLogic();
            rayCast.GetComponent<PlayerHealth>().TakeDamage(MeleeDamage);
        }
        else if(hit.collider == null)
        {
            inRange = false;
        }
        if (inRange == false)
        {
            anim.SetBool("canWalk", false);
            StopAttack();
        }
    }

    void EnemyLogic()
    {
        distance = Vector2.Distance(transform.position, target.transform.position);

        if(distance > attackDistance)
        {
            Move();
            StopAttack();
        }
        else if(attackDistance >= distance && cooling == false)
        {
            Attack();
        }
        if (cooling)
        {
            Cooldown();
            anim.SetBool("Attack", false);
        }
    }
    void Move()
    {
        anim.SetBool("canWalk", true);
        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Skeleton_att1"))
        {
            Vector2 targetPosition1 = new Vector2(target.transform.position.x, transform.position.y);
            transform.position = Vector2.MoveTowards(transform.position, targetPosition1, moveSpeed * Time.deltaTime);

        }
    }
    void Attack()
    {
        timer = intTimer; // reset timer when player go to attack range
        attackMode = true; //to check if enemy can still attack or not

        anim.SetBool("canWalk", false);
        anim.SetBool("Attack", true);
    }
    void Cooldown()
    {
        timer -= Time.deltaTime;
        if(timer <=0 && cooling && attackMode)
        {
            cooling = false;
            timer = intTimer;
        }
    }
    void StopAttack()
    {
        cooling = false;
        attackMode = false;
        anim.SetBool("Attack", false);
    }

    private void OnTriggerEnter2D(Collider2D trig)
    {
        if(trig.gameObject.tag == "Player")
        {
            target = trig.gameObject;
            inRange = true;
        }
    }
    void RaycastDebugger()
    {
        if(distance > attackDistance)
        {
            Debug.DrawRay(rayCast.position, Vector2.left * rayCastLenght, Color.red);
        }
        else if(attackDistance > distance)
        {
            Debug.DrawRay(rayCast.position, Vector2.left * rayCastLenght, Color.green);
        }
    }
    public void TriggerCooling()
    {
        cooling = true;
    }
}
