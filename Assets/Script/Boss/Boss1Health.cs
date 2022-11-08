using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1Health : MonoBehaviour
{
    public int MaxHealth;
    public int CurrentHealth;

    private void Start()
    {
        CurrentHealth = MaxHealth;
    }
    public void TakeDamage(int Damage)
    {
        CurrentHealth -= Damage;
    }
}

