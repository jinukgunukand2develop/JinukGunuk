using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YassoDetect : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private float minX = 0f;
    private float maxX = 0f;

    void Start()
    {
        
    }
    
    void Update()
    {
        if(IsDetected())
        {
            Debug.Log("Detected Player");
        }
        if(IsQRange())
        {
            Debug.Log("Is Q Range");
        }
        if(IsEQRange())
        {
            Debug.Log("Is EQ Range");
        }
    }

    public bool IsDetected()
    {
        DetectPlayer();
        if (player.transform.position.x >= minX && player.transform.position.x <= maxX)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool IsQRange()
    {
        DetectPlayer();
        if (player.transform.position.x >= (minX / 2f) && player.transform.position.x <= (maxX / 2f))
        {
            return true;
        }
        else
        {
            return false;
        }
    }    

    public bool IsEQRange()
    {
        DetectPlayer();
        if (player.transform.position.x >= (minX / 1.5f) && player.transform.position.x <= (maxX / 1.5f))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void DetectPlayer()
    {
        minX = transform.position.x - 2.6f;
        maxX = transform.position.x + 2.6f;
    }
}
