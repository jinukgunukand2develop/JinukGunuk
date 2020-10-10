using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    [SerializeField] private float maxPlayerHP = 100;
    [SerializeField] private float iPlayerHP = 10000;

    
    [SerializeField] private Slider slider = null;


    public void DecreaseHealth(int collisionDamage)
    {
        Debug.Log("Health Decreased");
        iPlayerHP -= collisionDamage;
    }

    private void Start()
    {
        slider.value = (float) iPlayerHP / (float)maxPlayerHP;
    }


    void Update()
    {
        
        if(iPlayerHP <= 0)
        {
            Debug.Log("HP equal or less then 0");
            Debug.Log("HP reset to 100");
            iPlayerHP = 100;
        }
    
        HandleHP();
    }
    void HandleHP() 
    {
        slider.value = (float)iPlayerHP / (float)maxPlayerHP;
    }

}
