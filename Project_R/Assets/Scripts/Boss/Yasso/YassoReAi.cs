using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YassoReAi : MonoBehaviour
{
    private YassoDetect detect = null;
    private Animator anim = null;
    private SpriteRenderer sprite = null;


    [SerializeField] private GameObject player = null;

    private bool bIsAttacking = false;
    private bool bFlip = false;
    [SerializeField] float fFollowSpeed = 1.5f;

    public const float DETECTDISTANCE = 2.6f;
    public const float EQRANGE = 1.5f;
    public const float QRANGE = 2f;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        detect = gameObject.AddComponent<YassoDetect>();
    }

    
    void Update()
    {
        Flip();
        if (!bIsAttacking)
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
                case 1:
                    {
                        transform.position = Vector2.MoveTowards(transform.position, new Vector2(player.transform.position.x, transform.position.y), 1.1f * Time.deltaTime);
                        break;
                    }
            }
        }
    }

    public virtual IEnumerator JumpLand(float speed = 2, float upSpeed = 2)
    {
        float to = Random.Range(-2.5f, 2.5f);
        while (true)
        {
            if (player.transform.position.x > to && player.transform.position.x < to)
            {
                to = Random.Range(-2.5f, 2.5f);

            }
            else
                break;
        }
        anim.Play("Yasso_Jump");
        transform.DOMove(new Vector2(transform.position.x - to / 2, transform.position.y + 1.5f), 0.9f).SetEase(Ease.OutExpo);
        yield return new WaitForSeconds(0.9f);
        transform.DOMove(new Vector2(transform.position.x - to / 2, transform.position.y - 1.5f), 0.9f).SetEase(Ease.InQuint);
        yield return new WaitForSeconds(0.9f);
        StartCoroutine(Idle());
    }

    void Flip()
    {
        if(!bIsAttacking)
        {
            if (player.transform.position.x < transform.position.x)
            {
                bFlip = false;
            }
            else
            {
                bFlip = true;
            }
        }
        
    }



    private IEnumerator AttackQ()
    {
        bIsAttacking = true;
        anim.Play("Yasso_Attack_1");
        yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length);
        StartCoroutine(JumpLand());
    }

    private IEnumerator AttackEQ()
    {
        bIsAttacking = true;
        anim.Play("Yasso_Dash_Attack");
        float length = anim.GetCurrentAnimatorStateInfo(0).length;
        if(bFlip)
        {
            transform.DOMoveX(player.transform.position.x - 0.2f, length);
        }
        else
        {
            transform.DOMoveX(player.transform.position.x + 0.2f, length);
        }
        yield return new WaitForSeconds(length);
        StartCoroutine(AttackQ());
    }

    private IEnumerator Idle()
    {
        anim.Play("Yasso_idle");
        yield return new WaitForSeconds(1.0f);
        bIsAttacking = false;
    }


}