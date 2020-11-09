using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CutScene : MonoBehaviour
{
    public GameObject image1;
    public GameObject image2;
    public GameObject image3;
    public GameObject image4;
    public GameObject image5;
    public GameObject image6;


    private void Update()
    {
        if (Input.anyKeyDown) 
        {
            image1.SetActive(true);
            image1.transform.DOLocalMoveX(0f, 1.5f).SetUpdate(true).SetEase(Ease.Unset).OnComplete(() => {
                
            });
            if (image1.activeSelf) 
            {
                image2.SetActive(true);
                image2.transform.DOLocalMoveY(127f, 3f).SetUpdate(true).SetEase(Ease.OutCirc).OnComplete(() => {
                

            
                });
            }



            if (image1.activeSelf&&image2.activeSelf) 
            {
                image3.SetActive(true);
                image3.transform.DOLocalMoveY(128.7f, 5f).SetUpdate(true).SetEase(Ease.OutCirc).OnComplete(() => {
                    
                });
            }
            if (image1.activeSelf && image2.activeSelf && image3.activeSelf) 
            {
                image4.SetActive(true);
                image4.transform.DOLocalMoveX(281.5f, 7f).SetUpdate(true).SetEase(Ease.OutCirc).OnComplete(() => {
                    
                });
            }

            if (image1.activeSelf && image2.activeSelf && image3.activeSelf && image4.activeSelf) 
            {
                image5.SetActive(true);
                image5.transform.DOLocalMoveY(-95f, 9f).SetUpdate(true).SetEase(Ease.OutCirc).OnComplete(() => {
                    
                });
            }

            if (image1.activeSelf && image2.activeSelf && image3.activeSelf && image4.activeSelf && image5.activeSelf) 
            {
                image6.SetActive(true);
                image6.transform.DOLocalMoveY(-95f, 12f).SetUpdate(true).SetEase(Ease.InQuad).OnComplete(() => {
                    
                });
            }

            StartCoroutine(SwitchScene());
            
        }
        
        IEnumerator SwitchScene() 
        {
            yield return new WaitForSeconds(16f);
            SceneManager.LoadScene("Loading");
        }
       
        
        
        
        
    }

}
