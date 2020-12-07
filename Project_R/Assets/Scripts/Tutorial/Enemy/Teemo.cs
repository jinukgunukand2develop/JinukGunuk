using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teemo : CTeemo
{
    private bool bAttackDelay = true;

    [SerializeField] private GameObject player = null;
    [SerializeField] private float fCollisionDamageDelay = 3f;

    private SpriteRenderer sprite = null;
    private Shader shaderGUItext;
    private Shader shaderSpritesDefault;
    private void Start()
    {
        shaderGUItext = Shader.Find("GUI/Text Shader");
        shaderSpritesDefault = Shader.Find("Sprites/Default");
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
        StartCoroutine(Damaged());
        iHp -= 5;
    }

    private IEnumerator Damaged()
    {
        sprite.material.shader = shaderGUItext;
        sprite.color = Color.white;
        yield return new WaitForSeconds(0.1f);
        sprite.material.shader = shaderSpritesDefault;
        sprite.color = Color.white;
    }

    protected void Dead()
    {
        Destroy(gameObject);
    }
}


//void OnGUI()
//  if(GUI.Button(new Rect(10, 10, 150, 100), "테스트") // (10, 10) 의 위치에 (150, 100) 크기의 사각형 버튼을 만듬
//  { /*버튼의 동작 입력*/ }