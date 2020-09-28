using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAttackZR : MonoBehaviour
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
        if (((gameManager.bWeaponStatus & 4) == 4) && (transform.parent.tag == "Player"))
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                transform.localPosition = new Vector2(0.1f, -0.07f);
                animator.Play("zr q");
                AttackQ();
            }
            if (Input.GetKeyDown(KeyCode.W))
            {
                transform.localPosition = new Vector2(0f, -0.2f);
                animator.Play("zr w");
                AttackW();
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                animator.Play("zr e");
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
