using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponAttackSZ : MonoBehaviour
{
    private Animator animator = null;
    private GameManager gameManager = null;
    private SpriteRenderer spriteRenderer = null;
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        gameManager = FindObjectOfType<GameManager>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        FlipSprite();

        if (((gameManager.bWeaponStatus & 2) == 2) && transform.parent.CompareTag("Player"))
        {
            switch(gameManager.bAtJump)
            {
                case true: break;
                case false:
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
                        break;
                    }
            }
            
        }
    }

    private void FlipSprite()
    {
        // 에러가 떠가지고 이렇게 작성
        switch (gameManager.bKzAttackWPressed || gameManager.bAtJump)
        {
            case false:
                {
                    switch (transform.parent != null)
                    {
                        case true:
                            {
                                switch (!transform.parent.CompareTag("Player"))
                                {
                                    case false:
                                        {
                                            if (gameManager.bPlayerFacingRightSide)
                                            {
                                                spriteRenderer.flipX = false;
                                                transform.localPosition = new Vector2(0.3f, 0f);
                                            }
                                            else
                                            {
                                                spriteRenderer.flipX = true;
                                                transform.localPosition = new Vector2(-0.3f, 0f);
                                            }
                                            break;
                                        }
                                }
                                break;
                            }
                    }
                    break;
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
