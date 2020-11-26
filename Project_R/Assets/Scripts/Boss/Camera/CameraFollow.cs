using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Camera cameraMain = null;
    public GameObject player = null;
    private Vector3 cameraPosition = Vector3.zero;


    private float fCameraSize = 0.0f;


    void Update()
    {
        //CameraZoomin();
        if (!GameManager.Instance.bBattle)
        {
            ClampCameraXPos();
            transform.position = cameraPosition;
        }
        else
        {
            transform.position = new Vector3(0f, transform.position.y, -10);
        }
        
    }

    private void CameraZoomin()
    {
        fCameraSize = Mathf.Abs(transform.position.x) - 6.3f;
        if (fCameraSize < 1.5f)
        {
            fCameraSize = 1.5f;
        }
        cameraMain.orthographicSize = fCameraSize;
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
