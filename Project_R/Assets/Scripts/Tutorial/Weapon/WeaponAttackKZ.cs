using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAttackKZ : MonoBehaviour
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
        if (((gameManager.bWeaponStatus & 1) == 1) && (transform.parent.tag == "Player"))
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                transform.localScale = new Vector2(0.6f, 0.6f);
                animator.Play("kz q");
                AttackQ();
            }
            if (Input.GetKeyDown(KeyCode.W))
            {
                transform.localScale = new Vector2(1f, 1f);
                animator.Play("kz w");
                AttackW();
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                transform.localScale = new Vector2(1f, 1f);
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
