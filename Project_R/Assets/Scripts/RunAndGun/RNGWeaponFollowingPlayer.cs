using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RNGWeaponFollowingPlayer : MonoBehaviour
{
    private RNGPlayerMove rngPlayerMove = null;
    private Vector2 V2DistBetweenPlayerAndWeapon = Vector2.zero;

    void Start()
    {
        rngPlayerMove = FindObjectOfType<RNGPlayerMove>();
    }

    void Update()
    {
        V2DistBetweenPlayerAndWeapon.x = Mathf.Abs(transform.localPosition.x - rngPlayerMove.transform.localPosition.x);
        V2DistBetweenPlayerAndWeapon.y = Mathf.Abs(transform.localPosition.y - rngPlayerMove.transform.localPosition.y);
        if(V2DistBetweenPlayerAndWeapon.x < 0.2f && V2DistBetweenPlayerAndWeapon.y < 0.2f)
        {
            WeaponPickUp();
        }
    }

    private void WeaponPickUp()
    {
        transform.SetParent(rngPlayerMove.transform, true);
        transform.localScale = new Vector2(0.5f, 0.5f);
        transform.localPosition = new Vector2(0.2f, 0);
    }

}
