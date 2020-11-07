using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player = null;
    private Vector3 cameraPosition = Vector3.zero;
    private PositionClamp clamp = null;

    private void Start()
    {
        clamp = FindObjectOfType<PositionClamp>();
    }


    void Update()
    {
        if(!clamp.bAtbattle)
        {
            ClampCameraXPos();
            transform.position = cameraPosition;
        }
        else
        {
            transform.position = new Vector3(0f, transform.position.y, -10);
        }
        
    }

    void ClampCameraXPos()
    {
        cameraPosition = new Vector3(player.transform.position.x, transform.position.y, -10);
        if (cameraPosition.x < -16.9f)
        {
            cameraPosition.x = -16.9f;
        }
        if(cameraPosition.x > 0.18f)
        {
            cameraPosition.x = 0.18f;
        }
    }
}
