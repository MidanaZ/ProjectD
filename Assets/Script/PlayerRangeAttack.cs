using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRangeAttack : MonoBehaviour
{
    public int maxMana = 100;
    public int currentMana;
    public ManaBar manaBar;
    public Transform RangePoint;
    public GameObject BulletTypePrefab;
    public Animator Animator;

    // Update is called once per frame
    void Start()
    {
        currentMana = maxMana;
        manaBar.SetMaxMana(maxMana);
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.C) && currentMana >= 10)
        {
            CostMana(10);
        }
    }
    public void CostMana(int mana)
    {
        currentMana -= mana;
        Animator.SetTrigger("IsRangeAttack");
        manaBar.SetMana(currentMana);
    }
    void Shoot()
    {
        Instantiate(BulletTypePrefab, RangePoint.position, RangePoint.rotation);
    }
}
