using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teemo : CTeemo
{
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
        if (bAttackDelay && Vector2.Distance(player.transform.position, transform.position) <= 0.1f)
        {
            bAttackDelay = false;
            FindObjectOfType<GameManager>().SendMessage("DecreaseHealth", collisionDamage, SendMessageOptions.DontRequireReceiver);
            yield return new WaitForSeconds(fCollisionDamageDelay);
            bAttackDelay = true;
        }
    }


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