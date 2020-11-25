using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YassoSkill : MonoBehaviour
{
    private static YassoSkill instance;
    public static YassoSkill Instance
    {
        get
        {
            if(instance == null)
            {
                instance = FindObjectOfType<YassoSkill>();
                if(instance == null)
                {
                    GameObject temp = new GameObject("YassoSkill");
                    instance = temp.AddComponent<YassoSkill>();
                }
            }
            return instance;
        }
    }


    private Animator animator = null;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }


    #region Attack
    public virtual void AttackQ()
    {
        animator.Play("Yasso_Attack_1");
        StartCoroutine(ReturnIdle(1.2f));
    }
    public virtual void AttackW()
    {
        animator.Play("Yasso_Attack_2");
        StartCoroutine(ReturnIdle(1.7f));
    }
    public virtual void AttackE()
    {
        animator.Play("Yasso_Dash_Attack");
        StartCoroutine(ReturnIdle(1.3f));
    }
    
    public IEnumerator ReturnIdle(float wait)
    {
        yield return new WaitForSeconds(wait);
        animator.Play("Yasso_idle");
    }

    public void AttackR()
    {
        // 결국 없다
    }
    #endregion
}
