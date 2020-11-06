using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerButtonMove : MonoBehaviour
{
    // 였던 것
    [SerializeField] float fPlayerSpeed = 1f;
    [SerializeField] private float fJumpForce = 5f;

    public Rigidbody2D rigidBody = null;
    private Animator animator = null;
    private SpriteRenderer spriteRenderer = null;
    private GameManager gameManager = null;

    public PlayerDamage playerDamage = null;

    private bool bLeft = false;
    private bool bRight = false;
    private bool bJump = false;
    private bool bPlayerFacingRight = true;
    private bool bMoving = false;

    private void Awake()
    {
        playerDamage = GetComponent<PlayerDamage>();
        rigidBody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        gameManager = FindObjectOfType<GameManager>();
    }


    void Update()
    {
        if(!playerDamage.bKnockBack)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                LeftButtonDown();
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                RightButtonDown();
            }
        }
        if(Input.GetKeyUp(KeyCode.A))
        {
            LeftButtonUp();
        }
        if(Input.GetKeyUp(KeyCode.D))
        {
            RightButtonUp();
        }
    }

    private void LateUpdate()
    {
        if(bRight && !playerDamage.bKnockBack) { MoveRight(); }
        if(bLeft && !playerDamage.bKnockBack) { MoveLeft(); }
    }

    // TODO : 눌렀을때 true, false 값 전달
    public void RightButtonDown()
    {
        if(!playerDamage.bKnockBack)
        {
            bRight = true; animator.Play("PlayerMove");
            spriteRenderer.flipX = false;
            gameManager.bPlayerFacingRightSide = true;
            bPlayerFacingRight = true;
        }
    }
    public void RightButtonUp()
    {
        if(!playerDamage.bKnockBack && !bLeft)
        {
            animator.Play("PlayerIdle");
        }
        bRight = false;
    }
    public void LeftButtonDown()
    { 
        if(!playerDamage.bKnockBack)
        {
            bLeft = true; animator.Play("PlayerMove");
            spriteRenderer.flipX = true;
            gameManager.bPlayerFacingRightSide = false;
            bPlayerFacingRight = false;
        }
        
    }
    public void LeftButtonUp()
    {
        if(!playerDamage.bKnockBack && !bRight)
        {
            animator.Play("PlayerIdle");
        }
        bLeft = false;
    }
    public void JumpPlayer()
    {
        if(!bJump)
        {
            bJump = true;
            animator.Play("PlayerJump");
            rigidBody.AddForce(new Vector2(0f, fJumpForce), ForceMode2D.Impulse);
            Invoke("Wait", 1.3f);
        }
        
    }
    void Wait()
    {
        animator.Play("PlayerIdle");
        bJump = false;
    }

    void MoveLeft()
    {
        transform.Translate(Vector2.left * Time.deltaTime * fPlayerSpeed);
    }

    void MoveRight()
    {
        transform.Translate(Vector2.right * Time.deltaTime * fPlayerSpeed);
    }
}
