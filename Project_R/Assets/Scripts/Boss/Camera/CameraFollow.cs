using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player = null;
    private Vector3 cameraPosition = Vector3.zero;

    void Update()
    {
        ClampCameraXPos();
        transform.position = cameraPosition;
    }

    void ClampCameraXPos()
    {
        cameraPosition = new Vector3(player.transform.position.x, transform.position.y, -10);
        if (cameraPosition.x < -16.9f)
        {
            cameraPosition.x = -16.9f;
        }
    }
}
