using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseWeapon : MonoBehaviour
{
    private WeaponAttackKZ kzWeapon = null;
    private WeaponAttackSZ szWeapon = null;
    private WeaponAttackZR zrWeapon = null;
    private Teemo teemo = null;

    private Vector2 V2AttackDistanceCheck = Vector2.zero;


    // 0 = 자르반, 1 = 카직스, 2 = 세주아니
    private int iCurrentWeapon = 0;


    void Start()
    {

        kzWeapon = FindObjectOfType<WeaponAttackKZ>();
        szWeapon = FindObjectOfType<WeaponAttackSZ>();
        zrWeapon = FindObjectOfType<WeaponAttackZR>();
        teemo = FindObjectOfType<Teemo>();
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
        V2AttackDistanceCheck.x = Mathf.Abs(teemo.transform.localPosition.x - transform.localPosition.x);
        V2AttackDistanceCheck.y = Mathf.Abs(teemo.transform.localPosition.y - transform.localPosition.y);
        if (V2AttackDistanceCheck.x <= 0.4f && V2AttackDistanceCheck.y <= 0.4f)
        {
            // TODO : 넉백 시스탬, 채력 감소
            //teemo.rigidbody2d.AddForce(new Vector2(2f, 0.1f));
            //--teemo.iTeemoHP;
        }
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
