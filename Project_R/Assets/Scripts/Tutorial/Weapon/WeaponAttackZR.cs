using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAttackZR : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            AttackQ();
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            AttackW();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            AttackE();
        }
    }


    private void AttackQ()
    {
        Debug.Log("자르반 Q");
    }

    private void AttackW()
    {
        Debug.Log("자르반 W");
    }

    private void AttackE()
    {
        Debug.Log("자르반 E");
    }
}
