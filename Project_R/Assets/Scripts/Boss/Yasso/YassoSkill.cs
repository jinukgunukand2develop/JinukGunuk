using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YassoSkill : MonoBehaviour
{

    #region Attack
    public virtual void AttackQ(Animator animator)
    {
        animator.Play("Yasso_Attack_1");
        StartCoroutine(ReturnIdle(animator, 1.2f));
    }
    public virtual void AttackW(Animator animator)
    {
        animator.Play("Yasso_Attack_2");
        StartCoroutine(ReturnIdle(animator, 1.7f));
    }
    public virtual void AttackE(Animator animator)
    {
        animator.Play("Yasso_Dash_Attack");
        StartCoroutine(ReturnIdle(animator, 1.3f));
    }
    
    public IEnumerator ReturnIdle(Animator animator, float wait)
    {
        yield return new WaitForSeconds(wait);
        animator.Play("Yasso_idle");
    }

    public void AttackR(Animator animator)
    {
        // 결국 없다
    }
    #endregion
}
