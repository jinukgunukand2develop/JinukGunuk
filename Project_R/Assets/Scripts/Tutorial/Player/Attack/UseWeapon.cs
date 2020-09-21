using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UseWeapon : MonoBehaviour
{
    private WeaponAttackKZ kzWeapon = null;
    private WeaponAttackSZ szWeapon = null;
    private WeaponAttackZR zrWeapon = null;
    
    [SerializeField]
    private Slider weaponPointKz = null;
    [SerializeField]
    private Slider weaponPointSz = null;
    [SerializeField]
    private Slider weaponPointZr = null;
    [SerializeField]
    private int kzMaxWP = 100;
    [SerializeField]
    private int szMaxWP = 100;
    [SerializeField]
    private int zrMaxWP = 100;
    [SerializeField]
    private int kzCurWP = 100;
    [SerializeField]
    private int szCurWP = 100;
    [SerializeField]
    private int zrCurWP = 100;

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

        weaponPointKz.value = (float)kzCurWP / (float)kzMaxWP;
        weaponPointSz.value = (float)szCurWP / (float)szMaxWP;
        weaponPointZr.value = (float)zrCurWP / (float)zrMaxWP;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            WeaponCycle();
        }
        HandleWPKz();
        HandleWPSz();
        HandleWPZr();



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
                        if (kzCurWP > 25)
                        {
                            if (transform.Find("zr")) zrWeapon.gameObject.SetActive(false); bWeaponStatus |= 4;
                            kzWeapon.gameObject.SetActive(true);
                            bCurrentWeapon = 1;
                            kzCurWP -= 25;
                            if (szCurWP < 91)
                            {
                                szCurWP += 20;
                            }
                            if (zrCurWP < 91)
                            {
                                zrCurWP += 20;
                            }
                        }
                        break;
                    }
                case 1:
                    {
                        if (szCurWP > 25) 
                        {
                            if (transform.Find("kz")) kzWeapon.gameObject.SetActive(false); bWeaponStatus |= 1;
                            szWeapon.gameObject.SetActive(true);
                            bCurrentWeapon = 2;
                            szCurWP -= 25;
                            if (kzCurWP < 91)
                            {
                                kzCurWP += 20;
                            }
                            if (zrCurWP < 91)
                            {
                                zrCurWP += 20;
                            }
                        }
                        break;
                    }
                case 2:
                    {
                        if (zrCurWP > 25) 
                        {
                            if (transform.Find("sz")) szWeapon.gameObject.SetActive(false); bWeaponStatus |= 2;
                            zrWeapon.gameObject.SetActive(true);
                            bCurrentWeapon = 0;
                            zrCurWP -= 25;
                            if (kzCurWP < 91)
                            {
                                kzCurWP += 20;
                            }
                            if (szCurWP < 91)
                            {
                                szCurWP += 20;
                            }
                        }
                        break;
                    }
            }
        }
    }

    void HandleWPKz() 
    {
        weaponPointKz.value = (float)kzCurWP / (float)kzMaxWP;
    }                          
    void HandleWPSz()          
    {                          
        weaponPointSz.value = (float)szCurWP / (float)szMaxWP;
    }                          
    void HandleWPZr()          
    {                          
        weaponPointZr.value = (float)zrCurWP / (float)zrMaxWP;
    }

}
