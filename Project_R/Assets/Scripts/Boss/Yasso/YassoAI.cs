﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

/// <summary>
/// 모든 함수의 리턴값 : 0 == idle, 1 == 공격함, 2 == EQ, 3 == 플레이어 발견, 4 == EQ 공격 가능 거리, 5 == Q 공격 가능 거리, 6 == 대쉬,  10 == 피격
/// </summary>
public class YassoAI : MonoBehaviour
{
    // 수정하면 탐지 범위가 이상해짐
    /// <summary>
    /// 보스가 탐지할 수 있는 범위
    /// </summary>
    public const float DETECTDISTANCE = 2.6f;
    public const float EQRANGE = 1.5f;
    public const float QRANGE = 2f;

    // TODO : idle 횟수가 늘어날 수록 짧아져야 함
    public float fRestDuration = 2.0f;

    /// <summary>
    /// 랜덤을 위한 변수
    /// </summary>
    private float attack = 0;

    //private YassoSkill skill = null;
    //private YassoStatus status = null;
    //private YassoDetect detect = null;
    //private YassoMove move = null;

    private Animator animator = null;

    private void Start()
    {
        //skill = FindObjectOfType<YassoSkill>();
        //status = FindObjectOfType<YassoStatus>();
        //detect = FindObjectOfType<YassoDetect>();
        //move = FindObjectOfType<YassoMove>();
        animator = GetComponent<Animator>();
    }



    /// <summary>
    /// 리턴값이 0일 경우 공격을 하지 않고 플레이어와 거리를 벌림
    /// , 리턴값이 1일 경우 거리가 어떻든 EQ
    /// </summary>
    /// <returns></returns>
    public int FirstAttack()
    {
        attack = Random.Range(0, 1);
        if (attack < 0.5f)
        {
            return 0;
        }
        else
        {
            return 154;
        }
    }

    /// <summary>
    /// !!꼭 스킬 원본을 넣어야 함!! // 리턴값 : 0 == idle, 1 == Q 공격함, 2 == EQ 공격함
    /// </summary>
    /// <param name="skill"></param>
    /// <param name="prevStatus"></param>
    /// <returns></returns>
    public virtual int UseSkill(int prevStatus)
    {
        if (YassoStatus.Instance.skillUseCount < 5 || prevStatus == 2)
        {
            attack = Random.Range(0, 10);
        }
        else
        {
            attack = Random.Range(0, 4);
        }
        return Attack();
    }


    public int Attack(int prevStatus = 0)
    {
        // 랜덤으로 다시 설정될 전역 변수
        if(prevStatus == 154) { attack = 3; }
        if (attack < 3 && YassoStatus.Instance.skillUseCount > 0)
        {
            --YassoStatus.Instance.skillUseCount;
            ++YassoStatus.Instance.beenIdleFor;
            return 0;
        }
        else
        {
            if (prevStatus == 6) // 이동해서 때리는건 아직 개발중
            {
                // TODO : 대쉬 끝날때까지 기다려야 하나?
                StartCoroutine(AttackEQ());
                return 2;
            }
            else
            {
                StartCoroutine(AttackQ());
                return 1;
            }
        }
    }
    private IEnumerator DashAttacked()
    {
        YassoStatus.Instance.bDashAttacked = true;
        yield return new WaitForSeconds(5.0f);
        YassoStatus.Instance.bDashAttacked = false;
    }
    private IEnumerator AttackEQ()
    {
        YassoStatus.Instance.bIsAttacking = true;
        ++YassoStatus.Instance.skillUseCount;
        StartCoroutine(DashAttacked());
        YassoSkill.Instance.AttackE();
        float length = animator.GetCurrentAnimatorStateInfo(0).length;
        yield return new WaitForSeconds(length);
        

        ++YassoStatus.Instance.skillUseCount;
        YassoSkill.Instance.AttackQ();
        length = animator.GetCurrentAnimatorStateInfo(0).length;
        yield return new WaitForSeconds(length);
        YassoStatus.Instance.bIsAttacking = false;
    }
    private IEnumerator AttackQ()
    {
        YassoStatus.Instance.bIsAttacking = true;
        ++YassoStatus.Instance.skillUseCount;
        YassoSkill.Instance.AttackQ();
        float length = animator.GetCurrentAnimatorStateInfo(0).length;
        yield return new WaitForSeconds(length);
        YassoStatus.Instance.bIsAttacking = false;
    }

    /// <summary>
    /// 1 == 점프 함, 0 == 점프 안함
    /// </summary>
    /// <param name="move"></param>
    /// <param name="status"></param>
    /// <returns></returns>
    public virtual int RandomJump()
    {
        attack = Random.Range(0.0f, 1.0f);
        if (attack > 0.5f)
        {
            MoveToRrdLoc();
            return 1;
        }
        return 0;
    }


    /// <summary>
    /// 리턴값 : 0 == idle, 3 == 플레이어 발견, 4 == EQ 거리, 5 == Q 거리
    /// </summary>
    /// <param name="prevStatus"></param>
    /// <returns></returns>
    public int Move(GameObject player, int prevStatus)
    {
        // TODO : 지난번 상태도 idle 이었다면 idle 시간을 줄인다
        switch(YassoDetect.Instance.RangeDetect(player, QRANGE, EQRANGE, DETECTDISTANCE))
        {
            case 1:
                {
                    return 3;
                }
            case 2:
                {
                    return 4;
                }
            case 3:
                {
                    return 5;
                }
            default:
                {
                    YassoStatus.Instance.bJumping = true;
                    MoveToRrdLoc();
                    ++YassoStatus.Instance.beenIdleFor;
                    return 0;
                }
                //default: ++YassoStatus.Instance.beenIdleFor;  return 0;
        }
    }

    /// <summary>
    /// 랜덤 위치로 점프 후 착지
    /// </summary>
    public void MoveToRrdLoc()
    {
        YassoStatus.Instance.bJumping = true;
        float fJumpRand = Random.Range(-2.0f, 2.0f);
        fJumpRand = RandAgain(fJumpRand);
        StartCoroutine(YassoMove.Instance.JumpLand(fJumpRand));
    }

    private float RandAgain(float fJumpRand)
    {
        while (true)
        {
            if ((transform.position.x + fJumpRand > 2.6f || transform.position.x + fJumpRand < -2.6f) && fJumpRand > -1.0f && fJumpRand < 1.0f)
            {
                fJumpRand = Random.Range(-2.0f, 2.0f);
            }
            else
                break;
        }
        return fJumpRand;
    }

    private IEnumerator ReturnIdle(float wait)
    {
        yield return new WaitForSeconds(wait);
        YassoStatus.Instance.bIsAttacking = false;
        animator.Play("Yasso_idle");
    }


    // 제작 중
}