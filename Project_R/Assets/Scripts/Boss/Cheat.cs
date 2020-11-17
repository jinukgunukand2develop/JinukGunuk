using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheat : MonoBehaviour
{
    private string[] waSans;
    private int index = 0;

    private PlayerStatus pStat = null;

    private void Start()
    {
        pStat = FindObjectOfType<PlayerStatus>();
        waSans = new string[] {"t", "a", "s", "t", "y", "l", "o", "v", "e"};
        index = 0;
    }


    void Update()
    {
        if(Input.anyKeyDown)
        {
            if(Input.GetKeyDown(waSans[index]))
            {
                ++index;
            }
            else { index = 0; }
        }

        if(index == waSans.Length)
        {
            pStat.hp = 154154;
            gameObject.SetActive(false);
        }
    }


}
