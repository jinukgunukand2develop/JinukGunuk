using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    private new PlayerMove gameObject = null;




    void Start()
    {
        gameObject = FindObjectOfType<PlayerMove>();
    }

    void Update()
    {
        transform.localPosition = new Vector3(gameObject.transform.localPosition.x, 0.55f, -10);
        //transform.localPosition = new Vector3(gameObject.transform.localPosition.x, (gameObject.transform.localPosition.y + 1.4f) * 0.5f, -10);
    }
}
