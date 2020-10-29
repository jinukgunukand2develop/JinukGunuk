using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    private PlayerStatus playerStat = null;

    private void Awake()
    {
        playerStat = gameObject.AddComponent<PlayerStatus>();
    }



    private void OnTriggerEnter2D(Collider2D boss)
    {
        if (boss.CompareTag("Boss"))
        {
            playerStat.hp -= 20;
        }
    }
}
