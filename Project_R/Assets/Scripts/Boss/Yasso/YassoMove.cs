using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YassoMove : MonoBehaviour
{
    private Animator animator = null;
    private bool bJump = false;


    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    #region Movement
    public virtual void Dash()
    {
        animator.Play("Yasso_Dash");
        Invoke("ReturnIdle", 1.0f);
    }
    public virtual void JumpLand(float to, float speed = 2, float upSpeed = 2)
    {
        bJump = true;
        animator.Play("Yasso_Jump");
        Invoke("Wait", 0.9f);
        Debug.Log("Wait 아레 코드");
        //while (bJump)
        //{
        //    transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x - to, transform.position.y + (1 * upSpeed)), Time.deltaTime * speed);
        //}
        Invoke("Wait", 0.9f);
        //while (bJump)
        //{
        //    transform.position = Vector2.down * upSpeed *  Time.deltaTime;
        //}
        ReturnIdle();
    }
    private void Wait()
    {
        bJump = false;
    }


    public virtual void ReturnIdle()
    {
        animator.Play("Yasso_idle");
    }
    public IEnumerator Rest(float millisec)
    {
        yield return new WaitForSeconds(millisec);
    }
    #endregion
}
