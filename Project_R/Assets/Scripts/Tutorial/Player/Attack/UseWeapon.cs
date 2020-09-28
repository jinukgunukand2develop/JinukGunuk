using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UseWeapon : MonoBehaviour
{
    [SerializeField] private GameObject kzWeapon = null;
    [SerializeField] private GameObject szWeapon = null;
    [SerializeField] private GameObject zrWeapon = null;
    [SerializeField] private Slider weaponPointKz = null;
    [SerializeField] private Slider weaponPointSz = null;
    [SerializeField] private Slider weaponPointZr = null;
    [SerializeField] private int kzMaxWP = 100;
    [SerializeField] private int szMaxWP = 100;
    [SerializeField] private int zrMaxWP = 100;
    [SerializeField] private int kzCurWP = 100;
    [SerializeField] private int szCurWP = 100;
    [SerializeField] private int zrCurWP = 100;

    // 0 = 자르반, 1 = 카직스, 2 = 세주아니
    private byte bCurrentWeapon = 0;


    void Start()
    {
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
                            if (transform.Find("zr"))
                            {
                                zrWeapon.gameObject.SetActive(false);
                            }
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
                            if (transform.Find("kz"))
                            {
                                kzWeapon.gameObject.SetActive(false);
                            }
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
                            if (transform.Find("sz"))
                            {
                                szWeapon.gameObject.SetActive(false);
                            }
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
