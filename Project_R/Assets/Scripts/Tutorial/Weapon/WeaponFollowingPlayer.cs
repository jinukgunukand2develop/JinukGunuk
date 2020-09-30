using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponFollowingPlayer : MonoBehaviour
{
    [SerializeField] private GameObject player = null;

    private new Transform transform = null;
    private Vector2 V2DistBetweenPlayerAndWeapon = Vector2.zero;

    private GameManager gameManager = null;

    void Start()
    {
        transform = GetComponent<Transform>();
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
            else if((name == "sz") && ((gameManager.bWeaponStatus & 2) != 2))
            {
                gameManager.bWeaponStatus |= 2;
                WeaponPickUp();
            }
            else if ((name == "zr") && ((gameManager.bWeaponStatus & 4) != 4))
            {
                gameManager.bWeaponStatus |= 4;
                WeaponPickUp();
            }


            // 무기와 플레이어가 겹치면 비활성화가 되는 버그가 있었음
            //switch (name)
            //{
            //    case "kz":
            //        {
            //            gameManager.bWeaponStatus |= 1;
            //            break;
            //        }
            //    case "sz":
            //        {
            //            gameManager.bWeaponStatus |= 2;
            //            break;
            //        }
            //    case "zr":
            //        {
            //            gameManager.bWeaponStatus |= 4;
            //            break;
            //        }
            //}
            //WeaponPickUp();
        }
    }

    private void WeaponPickUp()
    {
        transform.SetParent(player.transform, true);
        transform.localScale = new Vector2(0.5f, 0.5f);
        transform.localPosition = new Vector2(0.2f, 0f);
        transform.localScale = new Vector3(1f, 1f, 1f);
        gameObject.SetActive(false);
    }

}
