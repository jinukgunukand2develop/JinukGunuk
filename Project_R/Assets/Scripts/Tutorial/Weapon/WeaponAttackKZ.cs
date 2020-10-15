using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Runtime.ExceptionServices;
using UnityEngine;
using UnityEngine.UI;


public class WeaponAttackKZ : MonoBehaviour
{
    private Animator animator = null;
    private GameManager gameManager = null;
    private PlayerMove player = null;
    private SpriteRenderer spriteRenderer = null;

    // 기본값 = 오른쪽
    private Vector2 rayDirection = Vector2.zero;
    private bool bLandingProgress = false;
    private bool bAttacking = false;


    [SerializeField] private float fWeaponFlyingSpeed = 5f;
    [SerializeField] private float fPlayerJumpXForce = 3f;
    [SerializeField] private float fPlayerJumpYForce = 4f;
    [SerializeField] private Slider weaponPointKz = null;
    [SerializeField] private Slider weaponPointSz = null;
    [SerializeField] private Slider weaponPointZr = null;
    [SerializeField] private int kzMaxWP = 100;
    [SerializeField] private int szMaxWP = 100;
    [SerializeField] private int zrMaxWP = 100;
    [SerializeField] private int kzCurWP = 100;
    [SerializeField] private int szCurWP = 100;
    [SerializeField] private int zrCurWP = 100;

    


    private void Start()
    {
        weaponPointKz.value = (float)kzCurWP / (float)kzMaxWP;
        weaponPointSz.value = (float)szCurWP / (float)szMaxWP;
        weaponPointSz.value = (float)szCurWP / (float)szMaxWP;
        gameManager = FindObjectOfType<GameManager>();
        animator = GetComponent<Animator>();
        player = FindObjectOfType<PlayerMove>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(Kz());

        // TODO : WP 임시로 바꿔둔 것 나중에 다시 100으로 수정해야함
        // 디버그용 코드
        if (kzCurWP > 100)
            UnityEngine.Debug.LogWarning("카직스 WP 값이 디버그용 값!");
        
    }

    private void Update()
    {
        HandleWPKz();
        HandleWPSz();
        HandleWPZr();
        FlipSprite();
        // TODO : 나중에 함수로 빼버리기 (다른 무기 스킬도)
        if (((gameManager.bWeaponStatus & 1) == 1) && !bAttacking)
        {
            switch(gameManager.bAtJump || gameManager.bKzAttackWPressed)
            {
                case true: break;
                case false:
                    {
                        if (Input.GetKeyDown(KeyCode.Q) )
                        {
                            bAttacking = true;
                            KzAttackQ();
                        }
                        if (Input.GetKeyDown(KeyCode.W) )
                        {
                            bAttacking = true;
                            gameManager.bKzAttackWPressed = true;
                            KzAttackW();
                        }
                        if (Input.GetKeyDown(KeyCode.E) )
                        {
                            bAttacking = true;
                            KzAttackE();
                        }
                        break;
                    }
            }
        }
    }
    private void LateUpdate()
    {
        if (gameManager.bAtJump && (player.rigidBody.velocity.y < 0))
        {
            transform.localPosition = new Vector2(0.0f, -0.16f);
            LandingCheck();
        }
        if (gameManager.bKzAttackWPressed)
        {
            KzAttackDamageW();
            switch (spriteRenderer.flipX)
            {
                case true: transform.position += Vector3.left * Time.deltaTime * fWeaponFlyingSpeed; break;
                case false: transform.position += Vector3.right * Time.deltaTime * fWeaponFlyingSpeed; break;
            }
            if (Mathf.Abs(transform.position.x - player.transform.position.x) >= 10)
                AttackW();
        }
    }

    
    private void FlipSprite()
    {
        // 에러가 떠가지고 이렇게 작성
        switch(gameManager.bKzAttackWPressed || gameManager.bAtJump)
        {
            case false:
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
    }


    private void KzAttackQ()
    {
        
        transform.localScale = new Vector2(0.6f, 0.6f);
        animator.Play("kz q");
        kzCurWP -= 25;
        szCurWP += 20;
        zrCurWP += 20;
        Invoke("KzAttackDamageQ", 0.4f);
        Invoke("AttackQ", 0.9f);
    }

    private void KzAttackDamageQ()
    {
        GameManager.instance.SE(GameManager.audioClip.q);
        switch (gameManager.bPlayerFacingRightSide)
        {
            case true: rayDirection = new Vector2(1, 0); break;
            case false: rayDirection = new Vector2(-1, 0); break;
        }
        
        RaycastHit2D foundSomething = Physics2D.Raycast(transform.position, rayDirection);
        if(foundSomething.collider != null)
        {
            float distance = Mathf.Abs(foundSomething.point.x - transform.position.x);
            if (distance <= 0.1f)
            {
                foundSomething.collider.SendMessage("Hit", SendMessageOptions.DontRequireReceiver);
            }
        }

    }
    private void KzAttackDamageW()
    {
        
        switch (gameManager.bPlayerFacingRightSide)
        {
            case true: rayDirection = new Vector2(1, 0); break;
            case false: rayDirection = new Vector2(-1, 0); break;
        }

        RaycastHit2D foundSomething = Physics2D.Raycast(transform.position, rayDirection);
        if (foundSomething.collider != null)
        {
            float distance = Mathf.Abs(foundSomething.point.x - transform.position.x);
            if (distance <= 0.1f)
            {
                foundSomething.collider.SendMessage("Hit");
                AttackW();
            }
        }

    }

    private void KzAttackW()
    {
        GameManager.instance.SE(GameManager.audioClip.w);
        transform.SetParent(null, true);
        transform.localScale = new Vector2(1f, 1f);
        animator.Play("kz w");
        kzCurWP -= 25;
        szCurWP += 20;
        zrCurWP += 20;
    }

    private void KzAttackE()
    {
        GameManager.instance.SE(GameManager.audioClip.e);
        player.rigidBody.velocity = Vector3.zero;
        animator.Play("kz e");
        gameManager.bAtJump = true;
        if (gameManager.bPlayerFacingRightSide)
        {
            transform.localPosition = new Vector2(0.1f, -0.16f);
            player.rigidBody.AddForce(new Vector2(fPlayerJumpXForce, fPlayerJumpYForce), ForceMode2D.Impulse);
        }
        else
        {
            transform.localPosition = new Vector2(-0.1f, -0.16f);
            player.rigidBody.AddForce(new Vector2(-fPlayerJumpXForce, fPlayerJumpYForce), ForceMode2D.Impulse);
        }
        transform.SetParent(null, true);
        kzCurWP -= 25;
        szCurWP += 20;
        zrCurWP += 20;
    }
    #region Invoke
    private void AttackQ()
    {
        UnityEngine.Debug.Log("카직스 Q");
        transform.localScale = new Vector2(1f, 1f);
        bAttacking = false;
    }

    private void AttackW()
    {
        UnityEngine.Debug.Log("카직스 W");
        gameManager.bKzAttackWPressed = false;
        transform.SetParent(player.transform, true);
        animator.Play("kz idle");
        bAttacking = false;
    }

    private void AttackE()
    {
        animator.Play("kz idle");
        gameManager.bAtJump = false;
        UnityEngine.Debug.Log("카직스 E");
        Invoke("Wait", 0.1f);
        bLandingProgress = false;
        bAttacking = false;
    }
    #endregion

    private void LandingCheck()
    {
        if (!bLandingProgress && ((player.transform.position.y <= 0.18f) || (player.rigidBody.velocity.y <= 0.01f && player.rigidBody.velocity.y >= -0.01f)))
        {
            bLandingProgress = true;
            transform.SetParent(player.transform, true);
            animator.Play("kz e landing");
            Invoke("AttackE", 0.7f);
        }
    }


    void HandleWPKz()
    {
        weaponPointKz.value = (float)kzCurWP / (float)kzMaxWP;
    }
    void HandleWPSz()
    {
        weaponPointSz.value = (float)szCurWP / (float)szMaxWP;
    }
    void HandleWPZr()
    {
        weaponPointZr.value = (float)zrCurWP / (float)zrMaxWP;
    }

    IEnumerator Kz()
    {
        kzCurWP += 5;
        yield return new WaitForSeconds(5f);
    }


    void Wait() { }
}
