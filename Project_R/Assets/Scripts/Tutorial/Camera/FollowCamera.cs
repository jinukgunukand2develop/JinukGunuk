using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] private GameObject player = null;
    private Vector3 playerOffset = new Vector3(0.1f, 0f, 0f);



    void Start()
    {
        
    }

    void Update()
    {
        //transform.localPosition = new Vector3(gameObject.transform.localPosition.x, 0.55f, -10);
        transform.position = Vector3.Lerp(new Vector3(transform.position.x, 0.65f, -10), player.transform.position + playerOffset, 0.1f);
    }
}
