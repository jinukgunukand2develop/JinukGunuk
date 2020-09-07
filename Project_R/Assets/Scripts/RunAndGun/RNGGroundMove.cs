using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RNGGroundMove : MonoBehaviour
{
    [Header("걸어가는 속도에는 0.9가 적당한듯 함")]
    [SerializeField] private float fGroundMoveSpeed = 1.2f;

    void Update()
    {
        transform.localPosition -= new Vector3(fGroundMoveSpeed, 0f, 0f) * Time.deltaTime;
        ResetMapLocation();
    }

    private void ResetMapLocation()
    {
        if (FindObjectOfType<RNGPlayerMove>().transform.localPosition.y < -5)
        {
            transform.localPosition = Vector2.zero;
        }
    }
}
