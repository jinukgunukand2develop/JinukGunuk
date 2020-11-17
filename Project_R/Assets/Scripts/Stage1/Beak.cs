using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beak :CBeak
{
    private bool bAttackDelay = true;

    [SerializeField] private GameObject player = null;
    [SerializeField] private float fCollisionDamageDelay = 1f;

    private SpriteRenderer sprite = null;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

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

    public void ZrE()
    {
        StartCoroutine(Damaged());
        iHp -= 10;
    }
    public void ZrQ()
    {
        StartCoroutine(Damaged());
        iHp -= 5;
    }
    public void SzW()
    {
        StartCoroutine(Damaged());
        iHp -= 10;
    }
    public void Hit()
    {
        iHp -= 5;
    }

    private IEnumerator Damaged()
    {
        sprite.color = new Color32(255, 255, 255, 90);
        yield return new WaitForSeconds(0.1f);
        sprite.color = new Color32(255, 255, 255, 255);
    }

    protected void Dead()
    {
        Destroy(gameObject);
    }
}
