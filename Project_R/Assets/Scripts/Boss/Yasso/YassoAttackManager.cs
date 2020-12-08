using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
/*
야스오 플레이어 인식 범위
야스오 스킬 인식 범위
야스오 스킬 쿨타임
야스오 스킬 데미지

싱글톤 안바꿈?
*/

public class YassoAttackManager : MonoBehaviour
{
    [SerializeField] private new Camera camera = null;

    private SpriteRenderer sprite = null;
    private Animator animator = null;
    public GameObject yasso = null;
    public GameObject player = null;

    private Shader shaderGUItext;
    private Shader shaderSpritesDefault;

    private YassoAI yassoAi = null;
    private YassoSkill skill = null;
    private YassoStatus status = null;
    private YassoMove move = null;
    private YassoDetect detect = null;

    public bool bFreeze = false;
    public bool bMove = false;
    public bool bFirst = true;

    /// <summary>
    /// 0 == idle, 1 == 공격함, 2 == EQ, 3 == 플레이어 발견, 4 == EQ 공격 가능 거리, 5 == Q 공격 가능 거리,  10 == 피격
    /// </summary>
    public int _Transform = 0;

    
    

    public Slider healthBar = null;

    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        shaderGUItext = Shader.Find("GUI/Text Shader");
        shaderSpritesDefault = Shader.Find("Sprites/Default");
        detect = gameObject.AddComponent<YassoDetect>();
        yassoAi = gameObject.AddComponent<YassoAI>();
        skill = gameObject.AddComponent<YassoSkill>();
        status = gameObject.AddComponent<YassoStatus>();
        move = gameObject.AddComponent<YassoMove>();
    }

    private void Start()
    {
        
        healthBar.maxValue = status.iHP;
        
        // 따로 컷신을 파서 연출 (무적권 먼저 공격한다)
    }

    private IEnumerator YassoDead()
    {
        DOTween.Kill(this);
        healthBar.gameObject.SetActive(false);
        transform.position = new Vector2(0.0f, -1.22f);
        animator.Play("Yasso_idle");
        status.bYassoDead = true;
        player.SetActive(false);
        camera.orthographicSize = 0.5f;
        camera.transform.position = new Vector3(0.0f, -0.83f, -10.0f);
        yield return new WaitForSeconds(1.0f);
        sprite.DOFade(0.0f, 3.0f);
        yield return new WaitForSeconds(4.0f);

        SceneManager.LoadScene("YassoDead");
    }

    private void Update()
    {
        healthBar.value = status.iHP;

        if (bFreeze)
            animator.Play("Yasso_idle");
        if (!GameManager.Instance.bBattle)
            status.iHP = 100;
        if (status.iHP < 1)
        {
            StartCoroutine(YassoDead());
        }

        Debug.Log(status.bIsAttacking);
        if (GameManager.Instance.bBattle && !status.bIsAttacking && !status.bJumping)
        {
            if(bFirst)
            {
                _Transform = yassoAi.FirstAttack();
                _Transform = yassoAi.Attack(_Transform);
                bFirst = false;
            }
            switch (_Transform)
            {
                
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
                case 0:
                    {

                        Debug.Log("0");
                        //yassoAi.MoveToRrdLoc();
                        _Transform = yassoAi.Move(player, _Transform);
                        //_Transform = 1;
                        //animator.Play("Yasso_Dash");
                        //transform.position = Vector2.MoveTowards(transform.position, new Vector2(player.transform.position.x, transform.position.y), 1.7f * Time.deltaTime);


                        break;
                    }
            }
        }
    }


    private IEnumerator YassoEQed()
    {
        status.bIsAttacking = true;
        StartCoroutine(move.Rest(2.0f)); // 나중에 수정?
        yield return new WaitForSeconds(2.0f);
        _Transform = 0;
        status.bIsAttacking = false;
    }
    private IEnumerator YassoQed()
    {
        status.bIsAttacking = true;
        StartCoroutine(move.Rest(1.0f));
        yield return new WaitForSeconds(1.0f);
        status.bIsAttacking = false;
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



    #region 피격
    // 나중에 시간 있으면 따로 클래스 파도 될거 같음
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
        sprite.material.shader = shaderGUItext;
        sprite.color = Color.white;
        StartCoroutine(Pause());
        yield return new WaitForSeconds(0.5f);
        sprite.material.shader = shaderSpritesDefault;
        sprite.color = Color.white;
    }

    private IEnumerator Pause()
    {
        transform.DOMoveX(transform.position.x - 0.05f, 0.05f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(0.05f);
        transform.DOMoveX(transform.position.x + 0.05f, 0.05f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(0.15f);

        //GameManager.Instance.SE(GameManager.audioClip.hit);
        //StartCoroutine(Shake());
        Time.timeScale = 0.0f;
        float fTimeStop = Time.realtimeSinceStartup + 0.15f;
        while (true)
        {
            //if(Time.realtimeSinceStartup >= fTimeStop - 0.1f)
            //{
            //    StopCoroutine(Shake());
            //    CameraReset();
            //}
            if (Time.realtimeSinceStartup >= fTimeStop)
            {
                Time.timeScale = 1.0f;
                break;
            }
        }

    }

    #endregion 피격
}