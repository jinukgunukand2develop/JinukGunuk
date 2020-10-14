using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teemo : CTeemo
{
    
    private Vector2 V2DistanceWithTwoObj = Vector2.zero;
    private bool bAttackDelay = true;

    [SerializeField] private GameObject player = null;
    [SerializeField] private float fCollisionDamageDelay = 1f;

    void Update()
    {
        StartCoroutine(CheckCollision());
        if (iHp <= 0)
            Destroy(gameObject);
    }

    private IEnumerator CheckCollision()
    {
        V2DistanceWithTwoObj.x = Mathf.Abs(player.transform.localPosition.x - transform.localPosition.x);
        V2DistanceWithTwoObj.y = Mathf.Abs(player.transform.localPosition.y - transform.localPosition.y);
        if (bAttackDelay && V2DistanceWithTwoObj.x <= 0.1f && V2DistanceWithTwoObj.y <= 0.1f)
        {
            bAttackDelay = false;
            FindObjectOfType<GameManager>().DecreaseHealth(collisionDamage);
            yield return new WaitForSeconds(fCollisionDamageDelay);
            bAttackDelay = true;
        }
    }


    // TODO : 리짓바디 안붙이고 하는법 연구중
    private void Hit()
    {
        iHp -= 5;
    }


    protected void Dead()
    {
        Destroy(gameObject);
    }
}


//void OnGUI()
//  if(GUI.Button(new Rect(10, 10, 150, 100), "테스트") // (10, 10) 의 위치에 (150, 100) 크기의 사각형 버튼을 만듬
//  { /*버튼의 동작 입력*/ }