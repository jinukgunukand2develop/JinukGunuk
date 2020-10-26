using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
야스오 플레이어 인식 범위
야스오 스킬 인식 범위
야스오 스킬 쿨타임
야스오 스킬 데미지
*/

public class YassoAttackManager : MonoBehaviour, ISkill, IMovement
{
    private Animator animator = null;
    
    
    public GameObject yasso = null;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        
    }

    #region Movement
    public void Dash()
    {
        animator.Play("Yasso_Dash");
        Invoke("ReturnIdle", 1.0f);
    }
    public void Jump()
    {
        animator.Play("Yasso_Jump");
        Invoke("ReturnIdle", 1.8f);
    }
    #endregion
    #region Attack
    public void AttackQ()
    {
        animator.Play("Yasso_Attack_1");
        Invoke("ReturnIdle", 1.1f);
    }
    public void AttackW()
    {
        animator.Play("Yasso_Attack_2");
        Invoke("ReturnIdle", 1.7f);
    }
    public void AttackE()
    {
        animator.Play("Yasso_Dash_Attack");
        Invoke("ReturnIdle", 1.2f);
    }
    public void AttackR()
    {

    }
    #endregion

    public void ReturnIdle()
    {
        animator.Play("Yasso_Idle");
    }
}