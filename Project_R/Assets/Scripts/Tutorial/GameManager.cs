using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.SceneManagement;
using UnityEngine.UI;





public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public enum audioClip 
    {
        q,
        w,
        e
    }

    [SerializeField] List<AudioClip> clip = new List<AudioClip>(new AudioClip[3]);

   
    [SerializeField] private AudioSource audioSource = null;
    [SerializeField] private AudioSource audioSource2 = null;
    [SerializeField] protected Slider slider = null;
    [SerializeField] protected float maxPlayerHP = 100;
    [SerializeField] protected float iPlayerHP = 100;
    [SerializeField] private GameObject music = null;
   

    public bool bAtJump = false;
    public float fGroundLevel = -0.19f;
    public byte bWeaponStatus = 0;
    public bool bPlayerFacingRightSide = true;
    public bool bKzAttackWPressed = false;
    public bool bZrAttacking = false;
    public bool bSzAttacking = false;
    public bool bShield = false;
    public bool bShieldCoolDown = false;
    public bool bCooldown = false;
    public bool bDashCooldown = false;
    // 비트 연산
    // 카직스       0001 (1)
    // 세주아니     0010 (2)
    // 자르반       0100 (4)
    // 카직스 무기가 있는지 확인하려면
    // bWeaponStatus & 1;

    public IEnumerator Wait(float wait)
    {
        yield return new WaitForSeconds(wait);
        bDashCooldown = false;
    }



    public IEnumerator CoolDown()
    {
        bShieldCoolDown = true;
        yield return new WaitForSeconds(5.0f);
        bShieldCoolDown = false;
    }

    private void Start()
    {
        instance = this;
        audioSource = music.GetComponent<AudioSource>();
        slider.value = (float)iPlayerHP / (float)maxPlayerHP;
        iPlayerHP -= 20;
    }
    private void Update()
    {
        Dead();
        if(Input.GetKeyDown(KeyCode.M))
        {
            MuteMusic();
        }
        
        if (Input.GetKeyDown(KeyCode.K)) 
        {
            iPlayerHP -= 100;
        }

    }

    void MuteMusic()
    {
        switch (audioSource.mute)
        {
            case true: audioSource.mute = false; break;
            case false: audioSource.mute = true; break;
        }
    }

    void HandleHP()
    {
        slider.value = (float)iPlayerHP / (float)maxPlayerHP;
    }
    public void DecreaseHealth(int collisionDamage)
    {
        Debug.Log("Health Decreased " + collisionDamage + "\n" + iPlayerHP);
        Debug.Log(iPlayerHP);
        HandleHP();
        iPlayerHP -= collisionDamage;
    }
    private void Dead()
    {
        if (iPlayerHP < 0)
        {
            Time.timeScale = 1;
            SceneManager.LoadScene("Tutorial");
        }
            
    }

    public void SE(audioClip aC) 
    {
        audioSource2.loop = false;
        audioSource2.clip = clip[(int)aC];
        audioSource2.Play();
    }
  

}
