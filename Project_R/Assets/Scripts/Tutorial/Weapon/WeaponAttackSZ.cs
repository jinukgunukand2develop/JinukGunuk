using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAttackSZ : MonoBehaviour
{
    private Animator animator = null;

    private void Start()
    {
        animator = GetComponent<Animator>();
        animator.Play("sz idle");
    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Q))
        {
            AttackQ();
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            StartCoroutine(AttackW());
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            AttackE();
        }
    }


    private void AttackQ()
    {
        Debug.Log("세주아니 Q");
    }

    private IEnumerator AttackW()
    {
        animator.Play("sz w");
        yield return new WaitForSeconds(0.5f);
        animator.Play("sz idle");
    }

    private void AttackE()
    {
        Debug.Log("세주아니 E");
    }
}
