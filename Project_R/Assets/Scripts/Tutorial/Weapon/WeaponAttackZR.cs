using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponAttackZR : MonoBehaviour
{
    private Animator animator = null;
    private GameManager gameManager = null;
    private SpriteRenderer spriteRenderer = null;

    [SerializeField] private float fEDistance = 1.0f;
    [SerializeField] GameObject player = null;
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        gameManager = FindObjectOfType<GameManager>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        FlipSprite();
        switch(transform.parent != null)
        {
            case true:
                {
                    if (((gameManager.bWeaponStatus & 4) == 4))
                    {
                        switch (gameManager.bAtJump || gameManager.bShield)
                        {
                            case true: break;
                            case false:
                                {
                                    if (Input.GetKeyDown(KeyCode.Q))
                                    {
                                        transform.localPosition = new Vector2(0.1f, -0.07f);
                                        animator.Play("zr q");
                                        gameManager.bZrAttacking = true;
                                        StartCoroutine(ZrAttackQ());

                                    }
                                    if (Input.GetKeyDown(KeyCode.W))
                                    {
                                        transform.localPosition = new Vector2(0f, -0.2f);
                                        animator.Play("zr w");
                                        gameManager.bShield = true;
                                        gameManager.bZrAttacking = true;
                                        ZrAttackW();
                                    }
                                    if (Input.GetKeyDown(KeyCode.E))
                                    {
                                        gameManager.bZrAttacking = true;
                                        StartCoroutine(ZrAttackE());
                                    }
                                    break;
                                }
                        }
                    }
                    break;
                }
            
        }
    }
    private void FlipSprite()
    {
        switch (gameManager.bZrAttacking || gameManager.bAtJump)
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

    private IEnumerator ZrAttackQ()
    {
        yield return new WaitForSeconds(0.4f);
        Vector2 rayDirection;
        // 0.8f 거리
        if(spriteRenderer.flipX)
        {
            transform.localPosition = new Vector2(-0.3f, 0f);
            rayDirection = new Vector2(-1, 0);
        }
        else
        {
            transform.localPosition = new Vector2(0.3f, 0f);
            rayDirection = new Vector2(1, 0);
        }
        RaycastHit2D foundSomething = Physics2D.Raycast(transform.position, rayDirection);
        if (foundSomething.collider != null)
        {
            float distance = Vector2.Distance(foundSomething.point, transform.position);
            if (distance <= 0.8f)
            {
                foundSomething.collider.SendMessage("ZrQ", SendMessageOptions.DontRequireReceiver);
            }
        }
        
        yield return new WaitForSeconds(0.7f);
        AttackQ();
    }
    private void ZrAttackW()
    {
        // Finished
        Invoke("AttackW", 0.8f);
    }
    private IEnumerator ZrAttackE()
    {
        // Finished
        bool bFinded = false;
        GameObject closestEnemy = null;
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        animator.Play("zr e");
        yield return new WaitForSeconds(0.3f);
        foreach (GameObject target in enemies)
        {
            float fDistance = Vector2.Distance(transform.position, target.transform.position);
            if (fDistance <= fEDistance)
            {
                bFinded = true;
                fEDistance = fDistance;
                closestEnemy = target.gameObject;
            }
        }
        transform.SetParent(null, true);
        if (bFinded)
        {
            transform.position = new Vector2(closestEnemy.transform.position.x, -1.22f);
            closestEnemy.SendMessage("ZrE");
        }

        yield return new WaitForSeconds(0.5f);
        gameManager.bWeaponStatus -= 4;
        AttackE();
    }

    private void AttackQ()
    {
        Debug.Log("자르반 Q");
        animator.Play("zr idle");
        gameManager.bZrAttacking = false;
    }

    private void AttackW()
    {
        Debug.Log("자르반 W");
        animator.Play("zr idle");
        gameManager.bZrAttacking = false;
        gameManager.bShield = false;
    }

    private void AttackE()
    {
        Debug.Log("자르반 E");
        animator.Play("zr idle");
        gameManager.bZrAttacking = false;
    }


    private void Wait() { }
}
