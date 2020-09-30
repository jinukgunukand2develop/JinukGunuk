using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAttackKZ : MonoBehaviour
{
    private Animator animator = null;
    private GameManager gameManager = null;
    private PlayerMove player = null;

    [SerializeField] float fPlayerJumpXForce = 3f;
    [SerializeField] float fPlayerJumpYForce = 4f;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        animator = GetComponent<Animator>();
        player = FindObjectOfType<PlayerMove>();
    }

    void Update()
    {
        if (((gameManager.bWeaponStatus & 1) == 1) && transform.parent.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                transform.localScale = new Vector2(0.6f, 0.6f);
                animator.Play("kz q");
                Invoke("AttackQ", 0.9f);

            }
            if (Input.GetKeyDown(KeyCode.W))
            {
                transform.localScale = new Vector2(1f, 1f);
                animator.Play("kz w");
                Invoke("AttackW", 0.2f);
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
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
}
