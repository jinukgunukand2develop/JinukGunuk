using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UseWeapon : MonoBehaviour
{
    private GameManager gameManager = null;
    private PlayerDamage playerDamage = null;

    [SerializeField] private GameObject kzWeapon = null;
    [SerializeField] private GameObject szWeapon = null;
    [SerializeField] private GameObject zrWeapon = null;



    // 0 = 자르반, 1 = 카직스, 2 = 세주아니
    private byte bCurrentWeapon = 0;


    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        playerDamage = FindObjectOfType<PlayerDamage>();
    }

    void Update()
    {
        if(playerDamage != null && Input.GetKeyDown(KeyCode.F) && !gameManager.bAtJump && !gameManager.bZrAttacking && !playerDamage.bKnockBack && !gameManager.bKzAttackWPressed)
        {
            WeaponCycle();
        }
        else if(Input.GetKeyDown(KeyCode.F) && !gameManager.bAtJump && !gameManager.bZrAttacking && !gameManager.bKzAttackWPressed)
        {
            WeaponCycle();
        }
    }

    // TODO : 보기 불편함 // enum 으로 무기?
    void WeaponCycle()
    {
        if (transform.childCount != 0 && !gameManager.bCooldown)
        {
            switch (bCurrentWeapon)
            {
                case 0:
                    {
                        if (transform.Find("zr"))
                        {
                            zrWeapon.gameObject.SetActive(false);
                        }
                        kzWeapon.gameObject.SetActive(true);
                        bCurrentWeapon = 1;

                        break;
                    }
                case 1:
                    {
                        if (transform.Find("kz"))
                        {
                            kzWeapon.gameObject.SetActive(false);
                        }
                        szWeapon.gameObject.SetActive(true);
                        bCurrentWeapon = 2;

                        break;
                    }
                case 2:
                    {
                        if (transform.Find("sz"))
                        {
                            szWeapon.gameObject.SetActive(false);
                        }
                        zrWeapon.gameObject.SetActive(true);
                        bCurrentWeapon = 0;

                        break;
                    }
            }
        }
    }
}

