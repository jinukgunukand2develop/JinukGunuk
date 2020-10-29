using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YassoStatus : MonoBehaviour
{
    public short iHP = 500;
    public byte skillUseCount = 0;
    public byte beenIdleFor = 0;

    public bool bJumping = false;
    public bool bIsDash = false;
    public bool bUsedQ = false;
    public bool bUsedW = false;
    public bool bUsedE = false;
    public bool bDashAttacked = false;
    public bool bAbleR = false;
}