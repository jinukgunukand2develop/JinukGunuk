using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teemo : MonoBehaviour
{
    [SerializeField] protected int iTeemoHP = 5;

    private PlayerMove playerMove = null;

    private Vector2 V2DistBetweenPlayerEnemy = Vector2.zero;
    //private float fPushPlayer = 0.1f;

    private void Start()
    {
        playerMove = FindObjectOfType<PlayerMove>();
        //transform = GetComponent<Transform>();
    }

    void Update()
    {
        StartCoroutine(AttackPlayer());
        if (iTeemoHP <= 0)
        {
            // 나중에 뭔가를 더 넣을거 같으니
            Dead();
        }

    }
    private IEnumerator AttackPlayer()
    {
        V2DistBetweenPlayerEnemy.x = Mathf.Abs(transform.localPosition.x - playerMove.transform.localPosition.x);
        V2DistBetweenPlayerEnemy.y = Mathf.Abs(transform.localPosition.y - playerMove.transform.localPosition.y);
        if (V2DistBetweenPlayerEnemy.x <= 1.5f && V2DistBetweenPlayerEnemy.y <= 1.5f)
        {
            //playerMove.rigidBody.AddForce(new Vector2(fPushPlayer, 0f), ForceMode2D.Impulse);
            yield return new WaitForSeconds(1f);
        }
    }



    protected void Dead()
    {
        Destroy(gameObject);
    }
}
