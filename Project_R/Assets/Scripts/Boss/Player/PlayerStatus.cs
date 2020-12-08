using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    private static PlayerStatus instance = null;
    public static PlayerStatus Instance
    {
        get
        {
            if(instance == null)
            {
                instance = FindObjectOfType<PlayerStatus>();
                if (instance == null)
                {
                    GameObject temp = new GameObject("PlayerStatus");
                    instance = temp.AddComponent<PlayerStatus>();
                }
            }
            return instance;
        }
    }


    public int hp = 500;
    public bool bPlayerDead = false;
}
