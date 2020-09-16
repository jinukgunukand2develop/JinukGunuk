using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAttackKZ : MonoBehaviour
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
        if ((useWeapon.bWeaponStatus ^ 1) != 0)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                animator.Play("kz q");
                AttackQ();
            }
            if (Input.GetKeyDown(KeyCode.W))
            {
                animator.Play("kz w");
                AttackW();
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                animator.Play("kz e");
                AttackE();
            }
        }
    }


    private void AttackQ()
    {
        Debug.Log("카직스 Q");
    }

    private void AttackW()
    {
        Debug.Log("카직스 W");
    }

    private void AttackE()
    {
        Debug.Log("카직스 E");
    }
}
