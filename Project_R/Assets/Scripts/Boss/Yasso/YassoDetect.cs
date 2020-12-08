using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YassoDetect : MonoBehaviour
{
    private static YassoDetect instance = null;
    public static YassoDetect Instance
    {
        get
        {
            if(instance == null)
            {
                instance = FindObjectOfType<YassoDetect>();
                if(instance == null)
                {
                    GameObject temp = new GameObject("YassoDetect");
                    instance = temp.AddComponent<YassoDetect>();
                }
            }
            return instance;
        }
    }



    // TODO : 재사용할거면 리턴값을 갈아 엎어야 함
    // Yasso 용 플레이어 탐지


    /// <summary>
    /// 3 == Q range, 2 == EQ Range, 1 == PlayerDetect, 0 == none
    /// </summary>
    /// <param name="player"></param>
    /// <param name="fQRange"></param>
    /// <param name="fEQRange"></param>
    /// <param name="fDetectDistance"></param>
    /// <returns></returns>
    
    
    public virtual int RangeDetect(GameObject player, float fQRange, float fEQRange, float fDetectDistance)
    {
        if (Detect(player, fDetectDistance, fQRange))
        {
            return 3;
        }
        else if (Detect(player, fDetectDistance, fEQRange))
        {
            return 2;
        }
        else if (Detect(player, fDetectDistance))
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }
    /// <summary>
    /// player.transform 과 this.transform 사이의 거리 fDetectDistance 를 fDivide 만큼 나누어 그 거리 안 player.gameObject 탐지
    /// </summary>
    /// <param name="player"></param>
    /// <param name="fDetectDistance"></param>
    /// <param name="fDivide"></param>
    /// <returns></returns>
    public virtual bool Detect(GameObject player, float fDetectDistance, float fDivide = 1)
    {
        if (Vector2.Distance(player.transform.position, transform.position) <= (fDetectDistance / fDivide))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
