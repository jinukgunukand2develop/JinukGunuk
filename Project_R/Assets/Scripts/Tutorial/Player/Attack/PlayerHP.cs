﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    [SerializeField]
    private int maxPlayerHP = 100;
    [SerializeField] 
    private int iPlayerHP = 100;

    
    [SerializeField]
    private Slider slider;


    public void DecreaseHealth(int collisionDamage)
    {
        Debug.Log("Health Decreased");
        iPlayerHP -= collisionDamage;
    }

    private void Start()
    {
        slider.value = (float)iPlayerHP / (float)maxPlayerHP;
    }


    void Update()
    {
        if(iPlayerHP <= 0)
        {
            Debug.Log("HP equal or less then 0");
            Debug.Log("HP reset to 100");
            iPlayerHP = 100;
        }
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            iPlayerHP -= 10;
        }
        HandleHP();
    }
    void HandleHP() 
    {
        slider.value = (float)iPlayerHP / (float)maxPlayerHP;
    }

}
