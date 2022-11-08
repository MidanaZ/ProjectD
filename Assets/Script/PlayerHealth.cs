using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;
    public GameObject YouDiedPanel;
    public AudioSource HealthPickUp;
    public Animator Animator;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
        if(currentHealth <=0)
        {
            PlayerDead();
        }
    }

    public void TakeDamage(int Damage)
    {
        currentHealth -= Damage;
        Animator.SetTrigger("Hurt");
        healthBar.SetHealth(currentHealth);
    }
    public void PlayerDead()
    {
        //YouDiedPanel.SetActive(true);
        //Time.timeScale = 0;
        Animator.SetBool("Dead",true);
    }
    public void HealthPack()
    {
        HealthPickUp.enabled = true;
        DoDelayAction();
    }
    void DoDelayAction()
    {
        StartCoroutine(DelayAction());
    }
    IEnumerator DelayAction()
    {
        yield return new WaitForSeconds(3);
        HealthPickUp.enabled = false;
    }
}
