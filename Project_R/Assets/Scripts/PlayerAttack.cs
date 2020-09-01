using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerAttack : MonoBehaviour
{

    void Start()
    {
        
    }


    void Update()
    {
        // TODO : 다 만든 스크립트가 아님
        if (Input.GetKeyDown(KeyCode.Z))
        {
            gameObject.SetActive(true);
            StartCoroutine(wait());
            gameObject.SetActive(false);
        }
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(1f);
    }
}
