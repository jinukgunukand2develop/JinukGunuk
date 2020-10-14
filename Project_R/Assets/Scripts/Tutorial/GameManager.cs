using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class GameManager : MonoBehaviour
{

    [SerializeField] protected Slider slider = null;
    [SerializeField] protected float maxPlayerHP = 10000;
    [SerializeField] protected float iPlayerHP = 10000;


    public bool bAtJump = false;
    public float fGroundLevel = -0.19f;
    public byte bWeaponStatus = 0;
    public bool bPlayerFacingRightSide = true;
    public bool bKzAttackWPressed = false;
    // 비트 연산
    // 카직스       0001 (1)
    // 세주아니     0010 (2)
    // 자르반       0100 (4)
    // 카직스 무기가 있는지 확인하려면
    // bWeaponStatus & 1;

    private void Start()
    {
        slider.value = (float)iPlayerHP / (float)maxPlayerHP;
    }
    private void Update()
    {
        HandleHP();
        if (Input.GetKeyDown(KeyCode.K)) 
        {
            iPlayerHP -= 100;
        }

    }

    void HandleHP()
    {
        slider.value = (float)iPlayerHP / (float)maxPlayerHP;
    }
    public void DecreaseHealth(int collisionDamage)
    {
        Debug.Log("Health Decreased");
        iPlayerHP -= collisionDamage;
    }




}
