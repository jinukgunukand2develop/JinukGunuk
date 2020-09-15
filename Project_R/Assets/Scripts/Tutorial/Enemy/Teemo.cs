using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teemo : CTeemo
{
    private PlayerMove playerMove = null;
    private Vector2 V2DistanceWithTwoObj = Vector2.zero;
    private bool bAttackDelay = true;


    [SerializeField] private float fCollisionDamageDelay = 1f;



    private void Start()
    {
        playerMove = FindObjectOfType<PlayerMove>();
        
    }

    void Update()
    {
        StartCoroutine(CheckCollision());
    }

    private IEnumerator CheckCollision()
    {
        V2DistanceWithTwoObj.x = Mathf.Abs(playerMove.transform.localPosition.x - transform.localPosition.x);
        V2DistanceWithTwoObj.y = Mathf.Abs(playerMove.transform.localPosition.y - transform.localPosition.y);
        if (bAttackDelay && V2DistanceWithTwoObj.x <= 0.1f && V2DistanceWithTwoObj.y <= 0.1f)
        {
            bAttackDelay = false;
            FindObjectOfType<PlayerHP>().DecreaseHealth(collisionDamage);
            yield return new WaitForSeconds(fCollisionDamageDelay);
            bAttackDelay = true;
        }
    }


    protected void Dead()
    {
        Destroy(gameObject);
    }
}


//void OnGUI()
//  if(GUI.Button(new Rect(10, 10, 150, 100), "테스트") // (10, 10) 의 위치에 (150, 100) 크기의 사각형 버튼을 만듬
//  { /*버튼의 동작 입력*/ }