using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAttackSZ : MonoBehaviour
{
    private Animator animator = null;
    private UseWeapon useWeapon = null;


    private void Start()
    {
        useWeapon = FindObjectOfType<UseWeapon>();
        animator = GetComponent<Animator>();
        animator.Play("sz idle");
    }

    void Update()
    {
        if((useWeapon.bWeaponStatus ^ 2) != 0)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                animator.Play("sz q");
                AttackQ();
                animator.Play("sz idle");
            }
            if (Input.GetKeyDown(KeyCode.W))
            {
                animator.Play("sz w");
                StartCoroutine(AttackW());
                animator.Play("sz idle");
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                animator.Play("sz e");
                AttackE();
                animator.Play("sz idle");
            }
        }
    }


    private void AttackQ()
    {
        Debug.Log("세주아니 Q");
    }

    private IEnumerator AttackW()
    {
        
        yield return new WaitForSeconds(0.5f);
        
    }

    private void AttackE()
    {
        Debug.Log("세주아니 E");
    }
}
