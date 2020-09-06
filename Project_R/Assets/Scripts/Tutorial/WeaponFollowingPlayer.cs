using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponFollowingPlayer : MonoBehaviour
{
    private PlayerMove playerMove = null;
    private new Transform transform = null;
    private Vector2 V2DistBetweenPlayerAndWeapon = Vector2.zero;

    void Start()
    {
        playerMove = FindObjectOfType<PlayerMove>();
        transform = GetComponent<Transform>();
    }

    void Update()
    {
        V2DistBetweenPlayerAndWeapon.x = Mathf.Abs(transform.localPosition.x - playerMove.transform.localPosition.x);
        V2DistBetweenPlayerAndWeapon.y = Mathf.Abs(transform.localPosition.y - playerMove.transform.localPosition.y);
        if(V2DistBetweenPlayerAndWeapon.x < 0.2f && V2DistBetweenPlayerAndWeapon.y < 0.2f)
        {
            WeaponPickUp();
        }
    }

    private void WeaponPickUp()
    {
        transform.SetParent(playerMove.transform, true);
        transform.localScale = new Vector2(0.5f, 0.5f);
        transform.localPosition = new Vector2(0.2f, 0);
    }

}
