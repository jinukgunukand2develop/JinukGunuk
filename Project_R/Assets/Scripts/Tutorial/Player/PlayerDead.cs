using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDead : MonoBehaviour
{
    [SerializeField] protected int iPlayerHP = 5;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (iPlayerHP <= 0)
        {
            SceneManager.LoadScene("Dead");
        }
    }
}
