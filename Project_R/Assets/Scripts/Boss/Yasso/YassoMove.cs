using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YassoMove : MonoBehaviour
{
    private Animator animator = null;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    #region Movement
    public virtual void Dash()
    {
        animator.Play("Yasso_Dash");
        Invoke("ReturnIdle", 1.0f);
    }
    public virtual void Jump()
    {
        animator.Play("Yasso_Jump");
        Invoke("ReturnIdle", 1.8f);
    }
    public virtual void ReturnIdle()
    {
        animator.Play("Yasso_Idle");
    }
    public IEnumerator Rest(float millisec)
    {
        yield return new WaitForSeconds(millisec);
    }
    #endregion
}
