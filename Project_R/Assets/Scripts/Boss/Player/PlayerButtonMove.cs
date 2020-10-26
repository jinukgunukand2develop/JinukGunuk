using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerButtonMove : MonoBehaviour
{
    [SerializeField] float fPlayerSpeed = 1f;

    private bool bLeft = false;
    private bool bRight = false;

    
    void Update()
    {
        if (bRight) { MoveRight(); }
        if (bLeft) { MoveLeft(); }
    }

    public void RightButtonDown() { bRight = true; }
    public void RightButtonUp() { bRight = false; }
    public void LeftButtonDown() { bLeft = true; }
    public void LeftButtonUp() { bLeft = false; }

    void MoveLeft()
    {
        transform.Translate(Vector2.left * Time.deltaTime * fPlayerSpeed);
    }

    void MoveRight()
    {
        transform.Translate(Vector2.right * Time.deltaTime * fPlayerSpeed);
    }
}
