using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAttackSZ : MonoBehaviour
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
        Debug.Log("세주아니 Q");
    }

    private void AttackW()
    {
        Debug.Log("세주아니 W");
    }

    private void AttackE()
    {
        Debug.Log("세주아니 E");
    }
}
