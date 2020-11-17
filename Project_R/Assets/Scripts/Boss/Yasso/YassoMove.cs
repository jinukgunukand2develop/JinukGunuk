using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class YassoMove : MonoBehaviour
{
    private SpriteRenderer sprite = null;
    private Animator animator = null;
    private bool bJump = false;

    private YassoStatus status = null;


    private void Start()
    {
        status = FindObjectOfType<YassoStatus>();

        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    #region Movement
    public virtual int Dash(GameObject player, float time = 1.0f)
    {
        animator.Play("Yasso_Dash");
        
        if (player.transform.position.x < transform.position.x)
        {
            transform.DOMoveX(transform.position.x - 2f, time);
            sprite.flipX = false;
        }
        else
        {
            transform.DOMoveX(transform.position.x + 2f, time);
            sprite.flipX = true;
        }
        
        Invoke("ReturnIdle", 1.0f);
        return 6;
    }
    public virtual IEnumerator JumpLand(float to, float speed = 2, float upSpeed = 2)
    {
        yield return new WaitForSeconds(0.2f);
        animator.Play("Yasso_Jump");
        transform.DOMove(new Vector2(transform.position.x - to / 2, transform.position.y + 1.5f), 0.9f).SetEase(Ease.OutExpo);
        yield return new WaitForSeconds(0.9f);
        transform.DOMove(new Vector2(transform.position.x - to / 2, transform.position.y - 1.5f), 0.9f).SetEase(Ease.InQuint);
        yield return new WaitForSeconds(0.9f);
        ReturnIdle();
        status.bJumping = false;
    }
    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.9f);
        bJump = false;
    }


    public virtual void ReturnIdle()
    {
        animator.Play("Yasso_idle");
    }
    public IEnumerator Rest(float millisec)
    {
        ReturnIdle();
        status.bIsAttacking = true;
        yield return new WaitForSeconds(millisec);
        status.bIsAttacking = false;
        FindObjectOfType<YassoAttackManager>()._Transform = 0;
    }
    #endregion
}
