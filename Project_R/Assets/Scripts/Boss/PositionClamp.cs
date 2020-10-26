using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionClamp : MonoBehaviour
{
    public GameObject player = null;


    void Update()
    {
        ClampPlayerXPos();
    }

    void ClampPlayerXPos()
    {
        if(player.transform.position.x <= -19.4f)
        {
            player.transform.position = new Vector2(-19.4f, player.transform.position.y);
        }
        if(player.transform.position.x >= 2.6f)
        {
            player.transform.position = new Vector2(2.6f, player.transform.position.y);
        }
    }
}
