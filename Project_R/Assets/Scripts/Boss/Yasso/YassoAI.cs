using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 모든 함수의 리턴값 : 0 == idle, 1 == 공격함, 2 == EQ, 3 == 플레이어 발견, 4 == EQ 공격 가능 거리, 5 == Q 공격 가능 거리,  10 == 피격
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
    private float fRestDuration = 2.0f;

    private YassoMove move = null;
    private YassoStatus status = null;
    private YassoDetect detect = null;

    [SerializeField] private GameObject player = null;

    /// <summary>
    /// 랜덤을 위한 변수
    /// </summary>
    private float attack = 0;

    private void Awake()
    {
        move = gameObject.AddComponent<YassoMove>();
        status = gameObject.AddComponent<YassoStatus>();
        detect = gameObject.AddComponent<YassoDetect>();
    }

    /// <summary>
    /// 리턴값이 0일 경우 공격을 하지 않고 플레이어와 거리를 벌림
    /// , 리턴값이 1일 경우 거리가 어떻든 EQ
    /// </summary>
    /// <returns></returns>
    public byte FirstAttack()
    {
        attack = Random.Range(0, 1);
        if (attack < 0.5f)
        {
            return 0;
        }
        else
        {
            return 1;
        }
    }

    /// <summary>
    /// !!꼭 스킬 원본을 넣어야 함!! // 리턴값 : 1 == Q 공격함, 2 == EQ 공격함
    /// </summary>
    /// <param name="skill"></param>
    /// <param name="prevStatus"></param>
    /// <returns></returns>
    public virtual byte UseSkill(YassoSkill skill, byte prevStatus)
    {
        if(status.skillUseCount < 5 || prevStatus == 2)
        {
            attack = Random.Range(0, 10);
        }
        else
        {
            attack = Random.Range(0, 4);
        }
        return Attack(skill);
    }

    private byte Attack(YassoSkill skill)
    {
        if (attack < 3 && status.skillUseCount > 0)
        {
            --status.skillUseCount;
            return 0;
        }
        else
        {
            if (status.bIsDash) // 이동해서 때리는건 아직 개발중
            {
                // TODO : 대쉬 끝날때까지 기다려야 하나?
                StartCoroutine(DashAttacked());
                skill.AttackE();
                ++status.skillUseCount;
                attack = Random.Range(0, 1);
                if(attack > 0.5)
                {
                    skill.AttackQ();
                    ++status.skillUseCount;
                    return 2;
                }
                return 1;
            }
            else
            {
                ++status.skillUseCount;
                skill.AttackQ();
                return 1;
            }
        }
    }
    private IEnumerator DashAttacked()
    {
        status.bDashAttacked = true;
        yield return new WaitForSeconds(5.0f);
        status.bDashAttacked = false;
    }


    /// <summary>
    /// 리턴값 : 0 == idle, 3 == 플레이어 발견, 4 == EQ 거리, 5 == Q 거리
    /// </summary>
    /// <param name="prevStatus"></param>
    /// <returns></returns>
    public byte Move(byte prevStatus)
    {
        // TODO : 지난번 상태도 idle 이었다면 idle 시간을 줄인다
        if(prevStatus == 1 && prevStatus == 2)
        {
            move.ReturnIdle();
            move.Rest(fRestDuration);
            // TODO : 랜덤한 위치로 점프();
            ++status.beenIdleFor;
            return 0;
        }
        switch(detect.RangeDetect(player, QRANGE, EQRANGE, DETECTDISTANCE))
        {
            case 0:
                {
                    // TODO : 랜덤한 위치로 점프();
                    move.ReturnIdle();
                    move.Rest(fRestDuration);
                    ++status.beenIdleFor;
                    return 0;
                }
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
            default: ++status.beenIdleFor;  return 0;
        }
    }

    

    // 제작 중
}