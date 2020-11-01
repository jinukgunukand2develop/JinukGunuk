using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerButtonMove : MonoBehaviour
{
    [SerializeField] float fPlayerSpeed = 1f;
    [SerializeField] private float fJumpForce = 5f;

    public Rigidbody2D rigidBody = null;
    private Animator animator = null;
    private SpriteRenderer spriteRenderer = null;
    private GameManager gameManager = null;
    private GameManagerBoss gameManagerBoss = null;

    private bool bLeft = false;
    private bool bRight = false;
    private bool bJump = false;
    private bool bPlayerFacingRight = true;


    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        gameManager = FindObjectOfType<GameManager>();
    }


    void Update()
    {
        if (bRight) { MoveRight(); }
        if (bLeft) { MoveLeft(); }
    }

    public void RightButtonDown()
    {
        bRight = true; animator.Play("PlayerMove");
        spriteRenderer.flipX = false;
        gameManager.bPlayerFacingRightSide = true;
        bPlayerFacingRight = true;
    }
    public void RightButtonUp()
    {
        bRight = false; animator.Play("PlayerIdle");
    }
    public void LeftButtonDown()
    { 
        bLeft = true; animator.Play("PlayerMove");
        spriteRenderer.flipX = true;
        gameManager.bPlayerFacingRightSide = false;
        bPlayerFacingRight = false;
    }
    public void LeftButtonUp()
    {
        bLeft = false; animator.Play("PlayerIdle");
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
