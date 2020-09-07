using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RNGBackgroundMove : MonoBehaviour
{
    [Header("땅 속도의 2.154배정도")]
    [SerializeField] private float fGroundMoveSpeed = 2.5f;

    void Update()
    {
        transform.localPosition -= new Vector3(fGroundMoveSpeed, 0f, 0f) * Time.deltaTime;
        ResetMapLocation();
    }

    private void ResetMapLocation()
    {
        if (FindObjectOfType<RNGPlayerMove>().transform.localPosition.y < -5)
        {
            transform.localPosition = new Vector2(23.5f, 0f);
        }
    }
}
