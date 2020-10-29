using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
야스오 플레이어 인식 범위
야스오 스킬 인식 범위
야스오 스킬 쿨타임
야스오 스킬 데미지
*/

public class YassoAttackManager : MonoBehaviour
{
    public const float DETECTDISTANCE = 2.6f;
    public const float EQRANGE = 1.5f;
    public const float QRANGE = 2f;

    private Animator animator = null;
    public GameObject yasso = null;
    public GameObject player = null;

    YassoDetect yassoDetect = null;
    YassoMove yassoMove = null;
    YassoSkill yassoSkill = null;

    private void Awake()
    {
        yassoDetect = gameObject.AddComponent<YassoDetect>();
        yassoMove = gameObject.AddComponent<YassoMove>();
        yassoSkill = gameObject.AddComponent<YassoSkill>();
        animator = GetComponent<Animator>();
    }


    private void Start()
    {
        
    }

    private void Update()
    {
        
    }

    



    public void ReturnIdle()
    {
        animator.Play("Yasso_Idle");
    }
}