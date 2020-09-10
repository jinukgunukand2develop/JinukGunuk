using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAttackKZ : MonoBehaviour
{
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
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
        Debug.Log("카직스 Q");
    }

    private void AttackW()
    {
        Debug.Log("카직스 W");
    }

    private void AttackE()
    {
        Debug.Log("카직스 E");
    }
}
