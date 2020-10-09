using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponAttackSZ : MonoBehaviour
{
    private Animator animator = null;
    private GameManager gameManager = null;

    [SerializeField] private Slider weaponPointKz = null;
    [SerializeField] private Slider weaponPointSz = null;
    [SerializeField] private Slider weaponPointZr = null;
    [SerializeField] private int kzMaxWP = 100;
    [SerializeField] private int szMaxWP = 100;
    [SerializeField] private int zrMaxWP = 100;
    [SerializeField] private int kzCurWP = 100;
    [SerializeField] private int szCurWP = 100;
    [SerializeField] private int zrCurWP = 100;

    private void Start()
    { 
        weaponPointKz.value = (float) kzCurWP / (float) kzMaxWP;
        weaponPointSz.value = (float) szCurWP / (float) szMaxWP;
        weaponPointSz.value = (float) szCurWP / (float) szMaxWP;
       
        
        

        gameManager = FindObjectOfType<GameManager>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        HandleWPKz();
        HandleWPSz();
        HandleWPZr();

        //Debug.Log((gameManager.bWeaponStatus & 2) == 2);
        //Debug.Log(gameManager.bWeaponStatus & 2);
        //Debug.Log(gameManager.bWeaponStatus);

        if (((gameManager.bWeaponStatus & 2) == 2) && transform.parent.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.Q) && szCurWP >= 25)
            {
                animator.Play("sz q");
                AttackQ();
               
                    szCurWP -= 25;
                    if (kzCurWP < 91)
                    {
                        kzCurWP += 20;
                    }
                    if (zrCurWP < 91)
                    {
                        zrCurWP += 20;
                    }
                
            }
            if (Input.GetKeyDown(KeyCode.W) && szCurWP >= 25)
            {
                animator.Play("sz w");
                StartCoroutine(AttackW());
             
                    szCurWP -= 25;
                 
                        kzCurWP += 20;
                    
                 
                        zrCurWP += 20;
                    
                
            }
            if (Input.GetKeyDown(KeyCode.E) && szCurWP >= 25)
            {
                animator.Play("sz e");
                AttackE();
               
                
                    szCurWP -= 25;
                   
                        kzCurWP += 20;
                    
                   
                        zrCurWP += 20;
                    
                
            }
        }
    }


    private void AttackQ()
    {
        Debug.Log("세주아니 Q");
    }

    private IEnumerator AttackW()
    {
        
        yield return new WaitForSeconds(0.5f);
        
    }

    private void AttackE()
    {
        Debug.Log("세주아니 E");
    }
    void HandleWPKz()
    {
        weaponPointKz.value = (float)kzCurWP / (float)kzMaxWP;
    }
    void HandleWPSz()
    {
        weaponPointSz.value = (float)szCurWP / (float)szMaxWP;
    }
    void HandleWPZr()
    {
        weaponPointZr.value = (float)zrCurWP / (float)zrMaxWP;
    }
}
