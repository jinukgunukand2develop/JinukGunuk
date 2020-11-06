using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    [SerializeField]
    private GameObject player = null;
    private PlayerStatus playerStat = null;
    private float animDuration;
    private Animator animator = null;

    public bool bKnockBack = false;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        playerStat = gameObject.AddComponent<PlayerStatus>();
    }


    // Vector2.Distance(); 로 들어가게 해야 함
    private void OnTriggerEnter2D(Collider2D boss)
    {
        if (boss.CompareTag("Boss") && !bKnockBack)
        {
            playerStat.hp -= 20;
            Debug.Log("피깎");
            KnockBack();

        }
    }

    private void KnockBack()
    {
        bKnockBack = true;
        player.GetComponent<Rigidbody2D>().AddForce(new Vector2(-1.0f, 0.0f), ForceMode2D.Impulse);
        animator.Play("PlayerKnockBack");
        float value = animator.GetCurrentAnimatorStateInfo(0).length;
        Invoke("ReturnIdle", value);
    }

    private void ReturnIdle()
    {
        animator.Play("PlayerIdle");
        bKnockBack = false;
    }


}
