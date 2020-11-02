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

    private void Awake()
    {
        playerStat = gameObject.AddComponent<PlayerStatus>();
    }
    


    private void OnTriggerEnter2D(Collider2D boss)
    {
        if (boss.CompareTag("Boss"))
        {
            playerStat.hp -= 20;
            Debug.Log("피깎");
            KnockBack();
            
        }
    }

    private void KnockBack() 
    {
        player.transform.DOMoveX(-1f, animDuration);
        animator.Play("KnockBack");
    }
    
    
}
