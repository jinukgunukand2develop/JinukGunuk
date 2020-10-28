using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YassoSkill : MonoBehaviour
{
    private Animator animator = null;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    #region Attack
    public virtual void AttackQ()
    {
        animator.Play("Yasso_Attack_1");
        Invoke("ReturnIdle", 1.1f);
    }
    public virtual void AttackW()
    {
        animator.Play("Yasso_Attack_2");
        Invoke("ReturnIdle", 1.7f);
    }
    public virtual void AttackE()
    {
        animator.Play("Yasso_Dash_Attack");
        Invoke("ReturnIdle", 1.2f);
    }
    public void AttackR()
    {

    }
    #endregion
}
