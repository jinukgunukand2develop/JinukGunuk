using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YassoDetect : MonoBehaviour
{
    [SerializeField] private GameObject player;

    public const float DETECTDISTANCE = 2.6f;
    public const float EQRANGE = 1.5f;
    public const float QRANGE = 2f;


    void Update()
    {
        if(DetectPlayer())
        {
            Debug.Log("Detected Player");
        }
        if(DetectPlayer(QRANGE))
        {
            Debug.Log("Is Q Range");
        }
        if(DetectPlayer(EQRANGE))
        {
            Debug.Log("Is EQ Range");
        }
    }

    private bool DetectPlayer(float num = 1)
    {
        if (Vector2.Distance(player.transform.position, transform.position) <= (DETECTDISTANCE / num))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
