using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponFollowingPlayer : MonoBehaviour
{
    [SerializeField] private GameObject player = null;
    private Vector2 V2DistBetweenPlayerAndWeapon = Vector2.zero;

    private GameManager gameManager = null;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        V2DistBetweenPlayerAndWeapon.x = Mathf.Abs(transform.localPosition.x - player.transform.localPosition.x);
        V2DistBetweenPlayerAndWeapon.y = Mathf.Abs(transform.localPosition.y - player.transform.localPosition.y);
        if(V2DistBetweenPlayerAndWeapon.x < 0.2f && V2DistBetweenPlayerAndWeapon.y < 0.2f)
        {
            if((name == "kz") && ((gameManager.bWeaponStatus & 1) != 1))
            {
                gameManager.bWeaponStatus |= 1;
                WeaponPickUp();
            }
            if ((name == "sz") && ((gameManager.bWeaponStatus & 2) != 2))
            {
                gameManager.bWeaponStatus |= 2;
                WeaponPickUp();
            }
            if ((name == "zr") && ((gameManager.bWeaponStatus & 4) != 4))
            {
                gameManager.bWeaponStatus |= 4;
                WeaponPickUp();
            }
        }
    }

    private void WeaponPickUp()
    {
        transform.SetParent(player.transform, true);
        gameObject.SetActive(false);
    }

}
