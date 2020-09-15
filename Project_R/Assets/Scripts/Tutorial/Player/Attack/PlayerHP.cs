using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    [SerializeField] private int iPlayerHP = 100;


    public void DecreaseHealth(int collisionDamage)
    {
        Debug.Log("Health Decreased");
        iPlayerHP -= collisionDamage;
    }

    
    void Update()
    {
        if(iPlayerHP <= 0)
        {
            Debug.Log("HP equal or less then 0");
            Debug.Log("HP reset to 100");
            iPlayerHP = 100;
        }
    }
}
