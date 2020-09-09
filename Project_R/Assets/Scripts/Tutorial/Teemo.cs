using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teemo : MonoBehaviour
{
    public int iTeemoHP = 5;

    public Rigidbody2D rigidbody2d = null;

    //private float fPushPlayer = 0.1f;

    private void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (iTeemoHP <= 0)
        {
            // 나중에 뭔가를 더 넣을거 같으니
            Dead();
        }

    }

    protected void Dead()
    {
        Destroy(gameObject);
    }
}
