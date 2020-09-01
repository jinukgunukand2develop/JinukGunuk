using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teemo : MonoBehaviour
{
    protected int iTeemoHP = 5;

    // Update is called once per frame
    void Update()
    {
        if (iTeemoHP <= 0)
        {
            Dead();
        }

    }

    protected void Dead()
    {
        Destroy(gameObject);
    }
}
