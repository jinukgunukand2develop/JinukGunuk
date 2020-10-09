using System.Collections;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
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


        // TODO : WP 임시로 바꿔둔 것 나중에 다시 100으로 수정해야함
        // 디버그용 코드
        if (kzCurWP > 100)
            Debug.LogWarning("카직스 WP 값이 디버그용 값!");
        
    }

    private void Update()
    {
        HandleWPKz();
        HandleWPSz();
        HandleWPZr();

        // TODO : 나중에 함수로 빼버리기 (다른 무기 스킬도)
        if (((gameManager.bWeaponStatus & 1) == 1) && transform.parent.CompareTag("Player"))
        {
            switch(gameManager.bAtJump)
            {
                case true: break;
                case false:
                    {
                        if (Input.GetKeyDown(KeyCode.Q) && kzCurWP >= 25)
                        {
                            KzAttackQ();
                        }
                        if (Input.GetKeyDown(KeyCode.W) && kzCurWP >= 25)
                        {
                            KzAttackW();
                        }
                        if (Input.GetKeyDown(KeyCode.E) && kzCurWP >= 25)
                        {
                            KzAttackE();
                        }
                        break;
                    }
            }
        }
    }

    private void LateUpdate()
    {
        if (gameManager.bAtJump)
            LandingCheck();
    }

    private void KzAttackQ()
    {
        transform.localScale = new Vector2(0.6f, 0.6f);
        animator.Play("kz q");
        kzCurWP -= 25;
        szCurWP += 20;
        zrCurWP += 20;
        Invoke("AttackQ", 0.9f);
    }
    private void KzAttackW()
    {
        transform.localScale = new Vector2(1f, 1f);
        animator.Play("kz w");
        kzCurWP -= 25;
        szCurWP += 20;
        zrCurWP += 20;
        Invoke("AttackW", 0.2f);
    }
    private void KzAttackE()
    {
        gameManager.bAtJump = true;
        transform.localPosition = new Vector2(0.1f, -0.16f);
        // TODO : 위치
        animator.Play("kz e");
        kzCurWP -= 25;
        szCurWP += 20;
        zrCurWP += 20;
        player.rigidBody.velocity = Vector3.zero;
        if (!player.bPlayerFacingRightSide) { player.rigidBody.AddForce(new Vector2(-fPlayerJumpXForce, fPlayerJumpYForce), ForceMode2D.Impulse); }
        else { player.rigidBody.AddForce(new Vector2(fPlayerJumpXForce, fPlayerJumpYForce), ForceMode2D.Impulse); }
        
    }
    #region 위치 초기화
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
    }
    #endregion

    private void LandingCheck()
    {
        if (player.transform.position.y <= 0.18f)
        {
            // TODO: 시발 어케해 시발 웨 안돼
            animator.Play("kz e landing");
            Invoke("AttackE", 0.6f);
            transform.localPosition = new Vector2(0.2f, 0f);
            gameManager.bAtJump = false;
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

}
