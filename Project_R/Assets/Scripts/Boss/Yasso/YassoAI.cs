using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class YassoAI : MonoBehaviour
{
    // 공격을 한 경우 높은 숫자를 가진다


    public byte FirstAttack()
    {
        float attack = Random.Range(0, 1);
        if (attack !< 0.5f)
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }

    // 꼭 스킬 원본을 넣어야 함
    
    //public byte UseSkill(YassoSkill skill, byte prevStatus)
    //{
    //    if(prevStatus < 5)
    //    {
            
    //    }
    //}

    // 제작 중

}