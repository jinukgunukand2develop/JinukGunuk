using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GameManager : MonoSingleton<GameManager>
{
    public bool bAtJump = false;
    public float fGroundLevel = -0.19f;
    public byte bWeaponStatus = 0;
    // 비트 연산
    // 카직스       0001 (1)
    // 세주아니     0010 (2)
    // 자르반       0100 (4)
    // 카직스 무기가 있는지 확인하려면
    // bWeaponStatus & 1;




}
