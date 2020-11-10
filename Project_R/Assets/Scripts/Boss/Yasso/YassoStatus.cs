﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YassoStatus : MonoBehaviour
{
    public int iHP = 100;
    public int skillUseCount = 0;
    public int qHitCount = 0;
    public int beenIdleFor = 0;
    public bool bYassoDead = false;
    public bool bAttackFinished = true;
    public bool bIsAttacking = false;
    public bool bJumping = false;
    public bool bDashPosible = true;
    public bool bUsedQ = false;
    //public bool bUsedW = false;
    //public bool bUsedE = false;
    public bool bDashAttacked = false;
    //public bool bAbleR = false;
}