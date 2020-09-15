using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseWeapon : MonoBehaviour
{
    private WeaponAttackKZ kzWeapon = null;
    private WeaponAttackSZ szWeapon = null;
    private WeaponAttackZR zrWeapon = null;

    // 0 = 자르반, 1 = 카직스, 2 = 세주아니
    private byte iCurrentWeapon = 0;


    void Start()
    {

        kzWeapon = FindObjectOfType<WeaponAttackKZ>();
        szWeapon = FindObjectOfType<WeaponAttackSZ>();
        zrWeapon = FindObjectOfType<WeaponAttackZR>();

        
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            WeaponCycle();
        }
        if(Input.GetKeyDown(KeyCode.Z))
        {
            Attack();
        }
    }

    void Attack()
    {
        
    }

    // TODO : 보기 불편함
    void WeaponCycle()
    {
        if (transform.childCount != 0)
        {
            switch (iCurrentWeapon)
            {
                case 0:
                    {
                        if (transform.Find("zr")) zrWeapon.gameObject.SetActive(false);
                        kzWeapon.gameObject.SetActive(true);
                        iCurrentWeapon = 1;
                        break;
                    }
                case 1:
                    {
                        if (transform.Find("kz")) kzWeapon.gameObject.SetActive(false);
                        szWeapon.gameObject.SetActive(true);
                        iCurrentWeapon = 2;
                        break;
                    }
                case 2:
                    {
                        if (transform.Find("sz")) szWeapon.gameObject.SetActive(false);
                        zrWeapon.gameObject.SetActive(true);
                        iCurrentWeapon = 0;
                        break;
                    }
            }
        }
    }
}
