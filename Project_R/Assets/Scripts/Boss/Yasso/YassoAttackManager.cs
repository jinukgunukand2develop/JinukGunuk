using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
야스오 플레이어 인식 범위
야스오 스킬 인식 범위
야스오 스킬 쿨타임
야스오 스킬 데미지

싱글톤 안바꿈?
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

    public bool bFreeze = false;

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
        //_Transform = yassoAi.FirstAttack();
        //_Transform = yassoAi.Attack(_Transform);
        // 따로 컷신을 파서 연출 (무적권 먼저 공격한다)
    }

    private void Update()
    {


        Debug.Log(status.bIsAttacking);
        if (GameManager.Instance.bBattle && !status.bIsAttacking && !status.bJumping)
        {
            switch (_Transform)
            {
                case 0:
                    {
                        Debug.Log("0");
                        //yassoAi.MoveToRrdLoc();
                        //_Transform = yassoAi.Move(player, _Transform);
                        _Transform = 1;

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
                        _Transform = yassoAi.Attack();
                        break;
                    }
                case 4:
                    {
                        Debug.Log("4");
                        _Transform = yassoAi.Attack();
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
                                yassoAi.MoveToRrdLoc();
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
                            _Transform = yassoAi.Attack(6);
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


    private IEnumerator YassoEQed()
    {
        move.Rest(2.0f); // 나중에 수정?
        yield return new WaitForSeconds(2.0f);
        _Transform = 0;
    }
    private IEnumerator YassoQed()
    {
        move.Rest(1.0f);
        yield return new WaitForSeconds(1.0f);
        _Transform = 0;
    }
    private IEnumerator YassoDash()
    {
        StartCoroutine(DashCooldown());
        status.bIsAttacking = true;
        _Transform = move.Dash(player);
        yield return new WaitForSeconds(0.5f);
        status.bIsAttacking = false;
    }

    private IEnumerator DashCooldown()
    {
        status.bDashPosible = false;
        yield return new WaitForSeconds(10.0f);
        status.bDashPosible = true;
    }

    public void Hit()
    {
        StartCoroutine(Damaged());
        status.iHP -= 5;
    }
    public void ZrE()
    {
        StartCoroutine(Damaged());
        status.iHP -= 10;
    }
    public void ZrQ()
    {
        StartCoroutine(Damaged());
        status.iHP -= 5;
    }
    public void SzW()
    {
        StartCoroutine(Damaged());
        status.iHP -= 10;
        bFreeze = true;
        Invoke("Freeze", 2.0f);
    }
    public void Freeze()
    {
        bFreeze = false;
    }

    private IEnumerator Damaged()
    {
        sprite.color = new Color32(255, 255, 255, 90);
        yield return new WaitForSeconds(0.1f);
        sprite.color = new Color32(255, 255, 255, 255);
    }
}