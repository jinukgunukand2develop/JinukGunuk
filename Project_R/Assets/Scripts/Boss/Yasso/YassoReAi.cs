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
    public bool bBattle = false;
    [SerializeField] float fFollowSpeed = 1.5f;

    public const float DETECTDISTANCE = 2.6f;
    public const float EQRANGE = 1.5f;
    public const float QRANGE = 2f;
    

    void Awake()
    {
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
        if (player.transform.position.x > -2.6f)
            bBattle = true;
        if (!bBattle)
            status.iHP = 100;
        if (status.iHP < 1)
        {
            StartCoroutine(YassoDead());
        }
        if (FindObjectOfType<PlayerStatus>().bPlayerDead)
            anim.Play("Yasso_idle");

        healthBar.value = status.iHP;

        Flip();
        if (!bIsAttacking && bBattle && !status.bYassoDead && !FindObjectOfType<PlayerStatus>().bPlayerDead)
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
        if(!bIsAttacking)
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

    public void Hit()
    {
        StartCoroutine(Damaged());
        status.iHP -= 5;
    }


    private IEnumerator Damaged()
    {
        sprite.color = new Color32(255, 255, 255, 90);
        yield return new WaitForSeconds(0.1f);
        sprite.color = new Color32(255, 255, 255, 255);
    }
}