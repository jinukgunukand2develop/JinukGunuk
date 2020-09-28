using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAttackSZ : MonoBehaviour
{
    private Animator animator = null;
    private GameManager gameManager = null;


    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        //Debug.Log((gameManager.bWeaponStatus & 2) == 2);
        //Debug.Log(gameManager.bWeaponStatus & 2);
        //Debug.Log(gameManager.bWeaponStatus);

        if(((gameManager.bWeaponStatus & 2) == 2) && transform.parent.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                animator.Play("sz q");
                AttackQ();
            }
            if (Input.GetKeyDown(KeyCode.W))
            {
                animator.Play("sz w");
                StartCoroutine(AttackW());
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                animator.Play("sz e");
                AttackE();
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
