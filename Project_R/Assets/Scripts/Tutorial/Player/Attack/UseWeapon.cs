using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UseWeapon : MonoBehaviour
{
    
    private PlayerDamage playerDamage = null;

    [SerializeField] private GameObject kzWeapon = null;
    [SerializeField] private GameObject szWeapon = null;
    [SerializeField] private GameObject zrWeapon = null;



    // 0 = 자르반, 1 = 카직스, 2 = 세주아니
    private byte bCurrentWeapon = 0;

    

    void Start()
    {
        playerDamage = FindObjectOfType<PlayerDamage>();
    }

    void Update()
    {
        if(playerDamage != null  && !GameManager.Instance.bShieldCoolDown && !GameManager.Instance.bAtJump && !GameManager.Instance.bZrAttacking && !playerDamage.bKnockBack && !GameManager.Instance.bKzAttackWPressed && !GameManager.Instance.bSzAttacking)
        {
            WeaponCycle();
        }
        else if(!GameManager.Instance.bAtJump && !GameManager.Instance.bShieldCoolDown && !GameManager.Instance.bZrAttacking && !GameManager.Instance.bKzAttackWPressed && !GameManager.Instance.bSzAttacking)
        {
            WeaponCycle();
        }
    }

    // TODO : 보기 불편함 // enum 으로 무기?
    void WeaponCycle()
    {
        if (transform.childCount != 0 && !GameManager.Instance.bCooldown)
        {
            if(Input.GetKeyDown(KeyCode.Alpha8))
            {
                if (transform.Find("zr"))
                {
                    zrWeapon.gameObject.SetActive(false);
                }
                if (transform.Find("sz"))
                {
                    szWeapon.gameObject.SetActive(false);
                }
                kzWeapon.gameObject.SetActive(true);
                bCurrentWeapon = 1;
            }
            if(Input.GetKeyDown(KeyCode.Alpha9))
            {
                if (transform.Find("kz"))
                {
                    kzWeapon.gameObject.SetActive(false);
                }
                if (transform.Find("zr"))
                {
                    zrWeapon.gameObject.SetActive(false);
                }
                szWeapon.gameObject.SetActive(true);
                bCurrentWeapon = 2;
            }
            if(Input.GetKeyDown(KeyCode.Alpha0))
            {
                if (transform.Find("sz"))
                {
                    szWeapon.gameObject.SetActive(false);
                }
                if (transform.Find("kz"))
                {
                    kzWeapon.gameObject.SetActive(false);
                }
                zrWeapon.gameObject.SetActive(true);
                bCurrentWeapon = 0;
            }
            if(Input.GetKeyDown(KeyCode.F))
            {
                switch (bCurrentWeapon)
                {
                    case 0:
                        {
                            if (transform.Find("zr"))
                            {
                                zrWeapon.gameObject.SetActive(false);
                            }
                            if (transform.Find("sz"))
                            {
                                szWeapon.gameObject.SetActive(false);
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
                            if (transform.Find("zr"))
                            {
                                zrWeapon.gameObject.SetActive(false);
                            }
                            szWeapon.gameObject.SetActive(true);
                            bCurrentWeapon = 2;

                            break;
                        }
                    case 2:
                        {
                            if (transform.Find("kz"))
                            {
                                kzWeapon.gameObject.SetActive(false);
                            }
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
}

