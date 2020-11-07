using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
야스오 플레이어 인식 범위
야스오 스킬 인식 범위
야스오 스킬 쿨타임
야스오 스킬 데미지
*/

public class YassoAttackManager : MonoBehaviour
{
    private SpriteRenderer sprite = null;
    private Animator animator = null;
    public GameObject yasso = null;
    public GameObject player = null;

    private YassoAI yassoAi = null;
    private YassoSkill skill = null;
    private YassoStatus status = null;
    private YassoMove move = null;
    private YassoDetect detect = null;

    

    /// <summary>
    /// 0 == idle, 1 == 공격함, 2 == EQ, 3 == 플레이어 발견, 4 == EQ 공격 가능 거리, 5 == Q 공격 가능 거리,  10 == 피격
    /// </summary>
    public int _Transform = 0;

    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        detect = gameObject.AddComponent<YassoDetect>();
        yassoAi = gameObject.AddComponent<YassoAI>();
        skill = gameObject.AddComponent<YassoSkill>();
        status = gameObject.AddComponent<YassoStatus>();
        move = gameObject.AddComponent<YassoMove>();
    }

    private void Start()
    {
        _Transform = yassoAi.FirstAttack();
        _Transform = yassoAi.Attack(status, animator, skill, _Transform);
    }

    private void Update()
    {
        {Debug.Log(status.bIsAttacking);
        if (!status.bIsAttacking && !status.bJumping)
        {
            switch (_Transform)
            {
                case 0:
                    {
                        Debug.Log("0");
                        
                        _Transform = yassoAi.Move(player, detect, status, move, _Transform);
                        break;
                    }
                case 1:
                    {
                        Debug.Log("1");
                        StartCoroutine(YassoQed());
                        break;
                    }
                case 2:
                    {
                        Debug.Log("2");
                        StartCoroutine(YassoEQed());
                        break;
                    }
                case 5:
                    {
                        Debug.Log("5");
                        _Transform = yassoAi.Attack(status, animator, skill, 154);
                        break;
                    }
                case 4:
                    {
                        Debug.Log("4");
                        _Transform = yassoAi.Attack(status, animator, skill, 154);
                        break;
                    }
                case 3:
                    {
                        Debug.Log("3");
                        float rnd = Random.Range(0.0f, 1.0f);
                        if(rnd > 0.3f)
                        {
                            if (status.bDashPosible)
                            {
                                StartCoroutine(YassoDash());
                            }
                            else
                            {
                                _Transform = 0;
                            }
                            break;
                        }
                        else
                        {
                            if (!status.bJumping)
                            {
                                yassoAi.MoveToRrdLoc(move, status);
                            }
                            else
                            {
                                StartCoroutine(YassoQed());
                            }
                            break;
                        }
                    }
                case 6:
                    {
                        Debug.Log("6");
                        float rnd = Random.Range(0.0f, 1.0f);
                        if(rnd > 0.5f)
                        {
                            _Transform = yassoAi.Attack(status, animator, skill, 6);
                        }
                        break;
                    }
                case 10:
                    {
                        Debug.Log("10");
                        if (status.beenIdleFor > 0)
                        {
                            --status.beenIdleFor;
                        }
                        if(status.skillUseCount > 0)
                        {
                            --status.skillUseCount;
                        }
                        break;
                    }
            }
        }
        }
        
    }


    private IEnumerator YassoEQed()
    {
        move.Rest(2.0f, status); // 나중에 수정?
        yield return new WaitForSeconds(2.0f);
        _Transform = 0;
    }
    private IEnumerator YassoQed()
    {
        move.Rest(1.0f, status);
        yield return new WaitForSeconds(1.0f);
        _Transform = 0;
    }
    private IEnumerator YassoDash()
    {
        StartCoroutine(DashCooldown());
        status.bIsAttacking = true;
        _Transform = move.Dash(player, sprite);
        yield return new WaitForSeconds(0.5f);
        status.bIsAttacking = false;
    }

    private IEnumerator DashCooldown()
    {
        status.bDashPosible = false;
        yield return new WaitForSeconds(10.0f);
        status.bDashPosible = true;
    }
}