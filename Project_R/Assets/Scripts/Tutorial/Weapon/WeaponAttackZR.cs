using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponAttackZR : MonoBehaviour
{
    private Animator animator = null;
    private GameManager gameManager = null;
    private SpriteRenderer spriteRenderer = null;

    [SerializeField] private Slider weaponPointKz = null;
    [SerializeField] private Slider weaponPointSz = null;
    [SerializeField] private Slider weaponPointZr = null;
    [SerializeField] private int kzMaxWP = 100;
    [SerializeField] private int szMaxWP = 100;
    [SerializeField] private int zrMaxWP = 100;
    [SerializeField] private int kzCurWP = 100;
    [SerializeField] private int szCurWP = 100;
    [SerializeField] private int zrCurWP = 100;
    // 건욱 이거 그냥 float 으로 선언하면 안되나욤
    //-우엽

    private void Start()
    {
        weaponPointKz.value = (float)kzCurWP / (float)kzMaxWP;
        weaponPointSz.value = (float)szCurWP / (float)szMaxWP;
        weaponPointSz.value = (float)szCurWP / (float)szMaxWP;
        spriteRenderer = GetComponent<SpriteRenderer>();
        gameManager = FindObjectOfType<GameManager>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        HandleWPKz();
        HandleWPSz();
        HandleWPZr();
        FlipSprite();
        if (((gameManager.bWeaponStatus & 4) == 4) && transform.parent.CompareTag("Player"))
        {
            switch(gameManager.bAtJump)
            {
                case true: break;
                case false:
                    {
                        if (Input.GetKeyDown(KeyCode.Q) && zrCurWP >= 25)
                        {
                            transform.localPosition = new Vector2(0.1f, -0.07f);
                            animator.Play("zr q");
                            zrCurWP -= 25;
                            kzCurWP += 20;
                            szCurWP += 20;
                            Invoke("AttackQ", 1.1f);
                        }
                        if (Input.GetKeyDown(KeyCode.W) && zrCurWP >= 25)
                        {
                            transform.localPosition = new Vector2(0f, -0.2f);
                            animator.Play("zr w");
                            zrCurWP -= 25;
                            kzCurWP += 20;
                            szCurWP += 20;
                            Invoke("AttackW", 0.8f);
                        }
                        if (Input.GetKeyDown(KeyCode.E) && zrCurWP >= 25)
                        {
                            animator.Play("zr e");
                            zrCurWP -= 25;
                            kzCurWP += 20;
                            szCurWP += 20;
                            Invoke("AttackE", 0.9f);
                        }
                        break;
                    }
            }
        }
    }
    private void FlipSprite()
    {
        switch (gameManager.bAtJump)
        {
            case false:
                {
                    if (!gameManager.bPlayerFacingRightSide)
                    {
                        spriteRenderer.flipX = true;
                        transform.localPosition = new Vector2(-0.2f, 0f);
                    }
                    else
                    {
                        spriteRenderer.flipX = false;
                        transform.localPosition = new Vector2(0.2f, 0f);
                    }
                    break;
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

}
