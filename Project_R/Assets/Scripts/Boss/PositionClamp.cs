using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionClamp : MonoBehaviour
{
    public GameObject player = null;
    public float temp = -19.4f;
    public bool bAtbattle = false;

    void Update()
    {
        if (player.transform.position.x > -2.6f)
        {
            temp = -2.6f;
            bAtbattle = true;
        }
        ClampPlayerXPos(temp);
    }

    void ClampPlayerXPos(float clamppos = -19.4f)
    {
        if(player.transform.position.x <= clamppos)
        {
            player.transform.position = new Vector2(clamppos, player.transform.position.y);
        }
        if(player.transform.position.x >= 2.6f)
        {
            player.transform.position = new Vector2(2.6f, player.transform.position.y);
        }
    }
}
