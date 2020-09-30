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
        if (((gameManager.bWeaponStatus & 4) == 4) && transform.parent.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                transform.localPosition = new Vector2(0.1f, -0.07f);
                animator.Play("zr q");
                Invoke("AttackQ", 1.1f);
            }
            if (Input.GetKeyDown(KeyCode.W))
            {
                transform.localPosition = new Vector2(0f, -0.2f);
                animator.Play("zr w");
                Invoke("AttackW", 0.8f);
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                animator.Play("zr e");
                Invoke("AttackE", 0.9f);
            }
            
        }
    }


    private void AttackQ()
    {
        Debug.Log("자르반 Q");
        animator.Play("zr idle");
        transform.localPosition = new Vector2(0.2f, 0f);
    }

    private void AttackW()
    {
        Debug.Log("자르반 W");
        animator.Play("zr idle");
        transform.localPosition = new Vector2(0.2f, 0f);
    }

    private void AttackE()
    {
        Debug.Log("자르반 E");
        animator.Play("zr idle");
        transform.localPosition = new Vector2(0.2f, 0f);
    }
}
