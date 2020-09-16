using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseWeapon : MonoBehaviour
{
    private WeaponAttackKZ kzWeapon = null;
    private WeaponAttackSZ szWeapon = null;
    private WeaponAttackZR zrWeapon = null;

    public byte bWeaponStatus = 0;
    // 비트 연산
    // 카직스       0001 (1)
    // 세주아니     0010 (2)
    // 자르반       0100 (4)
    // 카직스 무기가 있는지 확인하려면
    // bWeaponStatus & 1;

    // 0 = 자르반, 1 = 카직스, 2 = 세주아니
    private byte bCurrentWeapon = 0;


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
    }

    // TODO : 보기 불편함
    void WeaponCycle()
    {
        if (transform.childCount != 0)
        {
            switch (bCurrentWeapon)
            {
                case 0:
                    {
                        if (transform.Find("zr")) zrWeapon.gameObject.SetActive(false); bWeaponStatus |= 4;
                        kzWeapon.gameObject.SetActive(true);
                        bCurrentWeapon = 1;
                        break;
                    }
                case 1:
                    {
                        if (transform.Find("kz")) kzWeapon.gameObject.SetActive(false); bWeaponStatus |= 1;
                        szWeapon.gameObject.SetActive(true);
                        bCurrentWeapon = 2;
                        break;
                    }
                case 2:
                    {
                        if (transform.Find("sz")) szWeapon.gameObject.SetActive(false); bWeaponStatus |= 2;
                        zrWeapon.gameObject.SetActive(true);
                        bCurrentWeapon = 0;
                        break;
                    }
            }
        }
    }
}
