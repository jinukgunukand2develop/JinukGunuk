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
    [SerializeField] private GameObject mainCamera;

    [SerializeField] private float m_force = 0f;

    [SerializeField] private Vector3 m_offset = Vector2.zero;

    
    private Quaternion m_originRot;

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
        m_originRot = mainCamera.transform.rotation;
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
        GameManager.Instance.SE(GameManager.audioClip.hit);
        yield return new WaitForSeconds(0.2f);
        //StartCoroutine(Shake());
        Time.timeScale = 0.0f;
        float fTimeStop = Time.realtimeSinceStartup + 0.2f;
        while(true)
        {
            //if(Time.realtimeSinceStartup >= fTimeStop - 0.1f)
            //{
            //    StopCoroutine(Shake());
            //    CameraReset();
            //}
            if (Time.realtimeSinceStartup >= fTimeStop)
            {
                Time.timeScale = 1.0f;
                break;
            }
        }
        
    }

    IEnumerator Shake()
    {
        Vector2 t_originEuler = transform.eulerAngles;
        while (true)
        {
            float t_rotX = Random.Range(-m_offset.x, m_offset.x);
            float t_rotY = Random.Range(-m_offset.y, m_offset.y);
            Vector2 t_randomRot = t_originEuler + new Vector2(t_rotX, t_rotY);
            Quaternion t_rot = Quaternion.Euler(t_randomRot);

            while (Quaternion.Angle(mainCamera.transform.rotation, t_rot) > 0.1f)
            {
                mainCamera.transform.rotation = Quaternion.RotateTowards(transform.rotation, t_rot, m_force * Time.deltaTime);
                yield return null;
            }
            yield return null;
        }

    }

    private void CameraReset()
    {
        transform.rotation = m_originRot;

    }

    private void KnockBack()
    {

        bKnockBack = true;
        animator.enabled = false;
        if(yasso.transform.localScale.x == -1.0f)
        {
            player.GetComponent<Rigidbody2D>().AddForce(new Vector2(1.8f, 1.5f), ForceMode2D.Impulse);
        }
        else
        {
            player.GetComponent<Rigidbody2D>().AddForce(new Vector2(-1.8f, 1.5f), ForceMode2D.Impulse);
        }
        
        animator.enabled = true;
        animator.Play("PlayerKnockBack");
        float value = animator.GetCurrentAnimatorStateInfo(0).length;
        Invoke("ReturnIdle", value);
    }

    private void ReturnIdle()
    {
        bKnockBack = false;
    }


}
