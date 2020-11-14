using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponAttackSZ : MonoBehaviour
{
    private Animator animator = null;
    private GameManager gameManager = null;
    private SpriteRenderer spriteRenderer = null;
    private PlayerButtonMove player = null;

    private RaycastHit2D foundSomething;

    private bool bWAttacked = false;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        gameManager = FindObjectOfType<GameManager>();
        player = FindObjectOfType<PlayerButtonMove>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        FlipSprite();
        
        if (((gameManager.bWeaponStatus & 2) == 2) && transform.parent.CompareTag("Player") && !gameManager.bSzAttacking)
        {
            switch(gameManager.bAtJump)
            {
                case true: break;
                case false:
                    {
                        if (Input.GetKeyDown(KeyCode.Q))
                        {
                            animator.Play("sz q");
                            StartCoroutine(AttackQ());
                        }
                        if (Input.GetKeyDown(KeyCode.W))
                        {
                            // finished
                            animator.Play("sz w");
                            StartCoroutine(AttackW());
                        }
                        break;
                    }
            }
            
        }
    }

    private void FlipSprite()
    {
        // 에러가 떠가지고 이렇게 작성
        switch (gameManager.bKzAttackWPressed || gameManager.bAtJump || gameManager.bSzAttacking)
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


    private IEnumerator AttackQ()
    {
        transform.localPosition = new Vector2(0.0f, 0.0f);
        float flForceX = 3.0f;
        gameManager.bSzAttacking = true;
        if(spriteRenderer.flipX)
        {
            flForceX = -flForceX;
        }
        player.rigidBody.AddForce(new Vector2(flForceX, 0), ForceMode2D.Impulse);
        yield return new WaitForSeconds(0.5f);
        animator.Play("sz idle");
        gameManager.bSzAttacking = false;
        Debug.Log("세주아니 Q");
    }

    private IEnumerator AttackW()
    {
        bWAttacked = true;
        gameManager.bSzAttacking = true;
        yield return new WaitForSeconds(0.6f);
        Vector2 rayDirection;
        // 0.8f 거리
        if (spriteRenderer.flipX)
        {
            transform.localPosition = new Vector2(-0.3f, 0f);
            rayDirection = new Vector2(-1, 0);
        }
        else
        {
            transform.localPosition = new Vector2(0.3f, 0f);
            rayDirection = new Vector2(1, 0);
        }
        foundSomething = Physics2D.Raycast(transform.position, rayDirection);
        if (foundSomething.collider != null)
        {
            float distance = Vector2.Distance(foundSomething.point, transform.position);
            if (distance <= 0.8f)
            {
                foundSomething.collider.SendMessage("SzW", SendMessageOptions.DontRequireReceiver);
                yield return new WaitForSeconds(0.5f);
                animator.Play("sz freeze enemy");
                transform.SetParent(null, true);
                transform.position = foundSomething.transform.position;
                yield return new WaitForSeconds(1.0f);
                transform.SetParent(player.transform, true);
            }
        }
        animator.Play("sz idle");
        gameManager.bSzAttacking = false;
        bWAttacked = false;
    }
}
