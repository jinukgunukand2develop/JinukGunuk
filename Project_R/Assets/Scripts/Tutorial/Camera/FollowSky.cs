using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowSky : MonoBehaviour
{
    [SerializeField] private GameObject player = null;

    void Update()
    {
        transform.localPosition = new Vector3(player.transform.localPosition.x, (player.transform.localPosition.y + 1.4f) * 0.5f, 11);
    }
}
