using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAttackZR : MonoBehaviour
{
    private Animator animator = null;
    private UseWeapon useWeapon = null;


    private void Start()
    {
        useWeapon = FindObjectOfType<UseWeapon>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if ((useWeapon.bWeaponStatus ^ 4) != 0)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                animator.Play("zr q");
                AttackQ();
            }
            if (Input.GetKeyDown(KeyCode.W))
            {
                AttackW();
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                AttackE();
            }
        }
    }


    private void AttackQ()
    {
        Debug.Log("자르반 Q");
    }

    private void AttackW()
    {
        Debug.Log("자르반 W");
    }

    private void AttackE()
    {
        Debug.Log("자르반 E");
    }
}
