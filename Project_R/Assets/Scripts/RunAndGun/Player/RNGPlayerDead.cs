using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RNGPlayerDead : MonoBehaviour
{
    [SerializeField] protected int iPlayerHP = 5;

    void Start()
    {

    }

    void Update()
    {
        if (iPlayerHP <= 0)
        {
            SceneManager.LoadScene("Dead");
        }
    }
}
