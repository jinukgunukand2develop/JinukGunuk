using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mist : MonoBehaviour
{

    private bool bAttackDelay = true;
    [SerializeField] private GameObject player = null;
    [SerializeField] private float fCollisionDamageDelay = 2f;
    [SerializeField] private GameObject mist = null;
    private void Update()
    {
        StartCoroutine(MistCheck1());
        
    }
    private IEnumerator MistCheck1() 
    {
        if (bAttackDelay && Vector2.Distance(player.transform.position, transform.position) <= 0.1f)
        {
            
            bAttackDelay = false;
            if (!mist.activeSelf) 
            {
                mist.SetActive(true);
            }
            yield return new WaitForSeconds(6f);
            
                mist.SetActive(false);
            
            bAttackDelay = true;
        }
       

    }

    





}
