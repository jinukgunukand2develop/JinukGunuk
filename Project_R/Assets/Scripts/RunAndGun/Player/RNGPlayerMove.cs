using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.Tilemaps;

public class RNGPlayerMove : MonoBehaviour
{
    [SerializeField] private float fSpeed = 1.54f;
    [SerializeField] private float fJumpForce = 5f;

    public Rigidbody2D rigidBody = null;
    private Animator animator = null;
    

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        transform.rotation = Quaternion.identity;
        StartCoroutine(JumpPlayer());
        ResetPlayerLocation();
        MovePlayer();
    }

    private void MovePlayer()
    {
        transform.position += Vector3.right * fSpeed *  Time.deltaTime;
    }

    private void ResetPlayerLocation()
    {
        if(transform.localPosition.y < -5)
        {
            transform.localPosition = new Vector2(0.5f, -0.15f);
        }
    }

    IEnumerator JumpPlayer()
    {
        if (Input.GetButtonDown("Jump") && Mathf.Abs(rigidBody.velocity.y) < 0.001f)
        {
            animator.Play("PlayerJump");
            rigidBody.AddForce(new Vector2(0f, fJumpForce), ForceMode2D.Impulse);
            yield return new WaitForSeconds(1.3f);
            animator.Play("PlayerMove");
        }
    }
}