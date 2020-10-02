using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponAttackKZ : MonoBehaviour
{
    private Animator animator = null;
    private GameManager gameManager = null;
    private PlayerMove player = null;

    [SerializeField] float fPlayerJumpXForce = 3f;
    [SerializeField] float fPlayerJumpYForce = 4f;
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
    }

    void Update()
    {
        HandleWPKz();
        HandleWPSz();
        HandleWPZr();


        if (((gameManager.bWeaponStatus & 1) == 1) && transform.parent.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.Q)&& kzCurWP > 25)
            {
                transform.localScale = new Vector2(0.6f, 0.6f);
                animator.Play("kz q");
                Invoke("AttackQ", 0.9f);
                kzCurWP -= 25;
                
                    szCurWP += 20;
                
                
                    zrCurWP += 20;
                

            }
            if (Input.GetKeyDown(KeyCode.W) && kzCurWP > 25)
            {
                transform.localScale = new Vector2(1f, 1f);
                animator.Play("kz w");
                Invoke("AttackW", 0.2f);
                
                    kzCurWP -= 25;
                   
                        szCurWP += 20;
                    
                   
                        zrCurWP += 20;
                    
                
            }
            if (Input.GetKeyDown(KeyCode.E) && kzCurWP > 25)
            {
                
                    kzCurWP -= 25;
                    szCurWP += 20;
                    zrCurWP += 20;
                    
                
                gameManager.bAtJump = true;
                transform.localPosition = new Vector2(0.1f, -0.16f);
                // TODO : 위치
                animator.Play("kz e");
                if (!player.bPlayerFacingRightSide) { player.rigidBody.AddForce(new Vector2(-fPlayerJumpXForce, fPlayerJumpYForce), ForceMode2D.Impulse); }
                else { player.rigidBody.AddForce(new Vector2(fPlayerJumpXForce, fPlayerJumpYForce), ForceMode2D.Impulse); }
                if (transform.localPosition.y + gameManager.fGroundLevel < -0.01f)
                {   // 0.18                     -0.19
                    // TODO : 다 안만듬
                    animator.Play("kz e landing");
                    
                }
                    
                Invoke("AttackE", 1.0f);
                gameManager.bAtJump = false;
            }
        }
    }

    private void AttackQ()
    {
        Debug.Log("카직스 Q");
        animator.Play("kz idle");
        transform.localScale = new Vector2(1f, 1f);
    }

    private void AttackW()
    {
        Debug.Log("카직스 W");
        animator.Play("kz idle");
        transform.localPosition = new Vector2(0.2f, 0f);
    }

    private void AttackE()
    {
        Debug.Log("카직스 E");
        animator.Play("kz idle");
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
