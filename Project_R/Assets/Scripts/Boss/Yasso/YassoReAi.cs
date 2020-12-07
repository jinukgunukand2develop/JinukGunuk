using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class YassoReAi : MonoBehaviour
{
    private YassoDetect detect = null;
    private YassoStatus status = null;
    private Animator anim = null;
    private SpriteRenderer sprite = null;


    [SerializeField] private GameObject player = null;
    [SerializeField] private new Camera camera = null;
    public Slider healthBar = null;


    private bool bIsAttacking = false;
    private bool bFlip = false;
    private bool bFreeze = false;
    [SerializeField] float fFollowSpeed = 1.5f;

    public const float DETECTDISTANCE = 2.6f;
    public const float EQRANGE = 1.5f;
    public const float QRANGE = 2f;
    
    private Shader shaderGUItext;
    private Shader shaderSpritesDefault;

    void Awake()
    {
        shaderGUItext = Shader.Find("GUI/Text Shader");
        shaderSpritesDefault = Shader.Find("Sprites/Default");


        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        detect = gameObject.AddComponent<YassoDetect>();
        status = gameObject.AddComponent<YassoStatus>();
    }
    private void Start()
    {
        healthBar.maxValue = status.iHP;
    }

    private IEnumerator YassoDead()
    {
        DOTween.Kill(this);
        healthBar.gameObject.SetActive(false);
        transform.position = new Vector2(0.0f, -1.22f);
        anim.Play("Yasso_idle");
        status.bYassoDead = true;
        player.SetActive(false);
        camera.orthographicSize = 0.5f;
        camera.transform.position = new Vector3(0.0f, -0.83f, -10.0f);
        yield return new WaitForSeconds(1.0f);
        sprite.DOFade(0.0f, 3.0f);
        yield return new WaitForSeconds(4.0f);

        SceneManager.LoadScene("YassoDead");
    }


    void Update()
    {
        if (bFreeze)
            anim.Play("Yasso_idle");
        if (!GameManager.Instance.bBattle)
            status.iHP = 100;
        if (status.iHP < 1)
        {
            StartCoroutine(YassoDead());
        }
        if (PlayerStatus.Instance.bPlayerDead)
            anim.Play("Yasso_idle");

        healthBar.value = status.iHP;

        Flip();
        if (!bIsAttacking && GameManager.Instance.bBattle && !status.bYassoDead && !PlayerStatus.Instance.bPlayerDead && !bFreeze)
        {
            switch (detect.RangeDetect(player, QRANGE, EQRANGE, DETECTDISTANCE))
            {
                case 3:
                    {
                        StartCoroutine(AttackQ());
                        break;
                    }
                case 2:
                    {
                        StartCoroutine(AttackEQ());
                        break;
                    }
                default:
                    {
                        anim.Play("Yasso_Dash");
                        transform.position = Vector2.MoveTowards(transform.position, new Vector2(player.transform.position.x, transform.position.y), 1.7f * Time.deltaTime);
                        break;
                    }
            }
        }
    }

    private void FixedUpdate()
    {
        if(bFreeze)
        {
            DOTween.Kill(transform);
            StopAllCoroutines();
            bIsAttacking = false;
            StartCoroutine(Damaged());
        }
    }

    public virtual IEnumerator JumpLand(float cooldown, float speed = 2, float upSpeed = 2)
    {
        float to = Random.Range(-2.5f, 2.5f);
        while (true)
        {
            if (player.transform.position.x + 1.0f > to && player.transform.position.x - 1.0f < to)
            {
                to = Random.Range(-2.5f, 2.5f);

            }
            else
                break;
        }
        anim.Play("Yasso_Jump");
        transform.DOMove(new Vector2(to / 2, transform.position.y + 1.5f), 0.9f).SetEase(Ease.OutExpo);
        yield return new WaitForSeconds(0.9f);
        transform.DOMove(new Vector2(to / 2, transform.position.y - 1.5f), 0.9f).SetEase(Ease.InQuint);
        yield return new WaitForSeconds(0.9f);
        StartCoroutine(Idle(cooldown));
    }

    void Flip()
    {
        if(!bIsAttacking && !bFreeze)
        {
            if (player.transform.position.x < transform.position.x)
            {
                transform.localScale = new Vector2(1.0f, 1.0f);
                bFlip = false;
            }
            else
            {
                transform.localScale = new Vector2(-1.0f, 1.0f);
                bFlip = true;
            }
        }
        
    }


    private IEnumerator AttackQ(float cooldown = 1.0f)
    {
        bIsAttacking = true;
        status.bUsedQ = true;
        anim.Play("Yasso_Attack_1");
        if(!bFlip)
        {
            transform.position = new Vector2(transform.position.x - 0.3f, transform.position.y);
        }
        else
        {
            transform.position = new Vector2(transform.position.x + 0.3f, transform.position.y);
        }
        yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length);
        StartCoroutine(JumpLand(cooldown));
        status.bUsedQ = false;
    }

    private IEnumerator AttackEQ()
    {
        bIsAttacking = true;
        anim.Play("Yasso_Dash_Attack");
        float length = anim.GetCurrentAnimatorStateInfo(0).length;
        if(bFlip)
        {
            transform.DOMoveX(player.transform.position.x - 0.5f, length);
        }
        else
        {
            transform.DOMoveX(player.transform.position.x + 0.2f, length);
        }
        yield return new WaitForSeconds(length);
        StartCoroutine(AttackQ(1.5f));
    }

    private IEnumerator Idle(float cooldown)
    {
        anim.Play("Yasso_idle");
        yield return new WaitForSeconds(cooldown);
        bIsAttacking = false;
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