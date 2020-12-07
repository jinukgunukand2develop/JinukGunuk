using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PlayerDamage : MonoBehaviour
{
    [SerializeField] private GameObject player = null;
    [SerializeField] private GameObject yasso = null;

    private PlayerStatus playerStat = null;
    private Animator animator = null;
    //private YassoStatus yassoStatus = null;
    //private GameManager gameManager = null;

    public bool bKnockBack = false;

    public Slider healthBar = null;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        playerStat = gameObject.AddComponent<PlayerStatus>();
        
    }
    private void Start()
    {
        //gameManager = FindObjectOfType<GameManager>();
        //yassoStatus = FindObjectOfType<YassoStatus>();
        healthBar.maxValue = playerStat.hp;
    }
    private void Update()
    {
        
        healthBar.value = playerStat.hp;
        if (playerStat.hp < 1)
        {
            playerStat.bPlayerDead = true;
            healthBar.gameObject.SetActive(false);
            SceneManager.LoadScene("PlayerDead");
        }
    }


    // Vector2.Distance(); 로 들어가게 해야 함?
    private void OnTriggerEnter2D(Collider2D boss)
    {
        if (boss.CompareTag("Enemy") && !bKnockBack)
        {
            if(GameManager.Instance.bShield)
            {
                playerStat.hp -= 100;
                StartCoroutine(Pause());
            }
            else
            {
                KnockBack();
                playerStat.hp -= 100;
                StartCoroutine(Pause());
            }
            if(YassoStatus.Instance != null)
            {
                if (YassoStatus.Instance.bUsedQ)
                {
                    ++YassoStatus.Instance.qHitCount;
                    Debug.Log(YassoStatus.Instance.qHitCount);
                }
            }
            Debug.Log("피깎");
        }
    }

    private IEnumerator Pause()
    {
        yield return new WaitForSeconds(0.1f);
        Time.timeScale = 0.0f;
        float fTimeStop = Time.realtimeSinceStartup + 0.8f;
        if (Time.realtimeSinceStartup >= fTimeStop)
        {
            Time.timeScale = 1.0f;
        }
            
    }

    private void KnockBack()
    {

        bKnockBack = true;
        if(yasso.transform.localScale.x == -1.0f)
        {
            player.GetComponent<Rigidbody2D>().AddForce(new Vector2(2.0f, 0.3f), ForceMode2D.Impulse);
        }
        else
        {
            player.GetComponent<Rigidbody2D>().AddForce(new Vector2(-2.0f, 0.3f), ForceMode2D.Impulse);
        }

        animator.Play("PlayerKnockBack");
        float value = animator.GetCurrentAnimatorStateInfo(0).length;
        Invoke("ReturnIdle", value);
    }

    private void ReturnIdle()
    {
        bKnockBack = false;
    }


}
