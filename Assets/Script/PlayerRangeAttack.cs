using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRangeAttack : MonoBehaviour
{
    public Transform RangePoint;
    public GameObject BulletTypePrefab;
    public Animator Animator;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            Animator.SetTrigger("IsRangeAttack");
        }
    }
    void Shoot()
    {
        Instantiate(BulletTypePrefab, RangePoint.position, RangePoint.rotation);
    }
}
