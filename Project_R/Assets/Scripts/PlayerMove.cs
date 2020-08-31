using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float fPlayerSpeed = 5f;
    [SerializeField] private float fJumpForce = 5f;

    private Rigidbody2D rigidBody = null;
    private Animator animator = null;
    private SpriteRenderer spriteRenderer = null;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    private void Update()
    {
        MovePlayer();
        IdlePlayer();
        StartCoroutine(JumpPlayer());
    }



    private void IdlePlayer()
    {
        // TODO : 여기 좀 많이 더티함
        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            animator.Play("PlayerIdle");
        }
    }

    private void MovePlayer()
    {
        float movement = Input.GetAxis("Horizontal");

        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * fPlayerSpeed;
        transform.rotation = Quaternion.identity;

        // TODO : 여기 좀 더티함, 나아중에 입력 바꿔야 함
        if(Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            animator.Play("PlayerMove");
            spriteRenderer.flipX = true;
        }
        else if(Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            animator.Play("PlayerMove");
            spriteRenderer.flipX = false;
            
        }
    }

    IEnumerator JumpPlayer()
    {
        if (Input.GetButtonDown("Jump") && Mathf.Abs(rigidBody.velocity.y) < 0.001f)
        {
            animator.Play("PlayerJump");
            rigidBody.AddForce(new Vector2(0f, fJumpForce), ForceMode2D.Impulse);
            yield return new WaitForSeconds(0.3f);
            animator.Play("PlayerIdle");
        }
    }
}

#region 우엽이가 공부하면서 써둔 주석들 모음집
/*
ForceMode2D.Impulse
// 폭팔, 충돌과 같은 퍙! 하고 짧은 시간에 운동에너지 크기를 키우는 경우
Impluse
//충격

Mathf.Abs(float f);
//f 의 절대값을 반환함

Quaternion.identity;
// 유니티는 내부적으로 회전을 Quaternion 으로 저장
// identity 는 없음을 의미


*/
#endregion