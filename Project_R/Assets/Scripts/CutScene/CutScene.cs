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
         
            image1.transform.DOLocalMoveX(0f, 0f).SetUpdate(true).SetEase(Ease.Unset).OnComplete(() => {
                image1.SetActive(true);
            });
            if (image1.activeSelf) 
            {
                
                image2.transform.DOLocalMoveY(127f, 0f).SetUpdate(true).SetEase(Ease.OutCirc).OnComplete(() => {
                image2.SetActive(true);

            
                });
            }



            if (image1.activeSelf&&image2.activeSelf) 
            {
                
                image3.transform.DOLocalMoveY(128.7f, 0f).SetUpdate(true).SetEase(Ease.OutCirc).OnComplete(() => {
                    image3.SetActive(true);
                });
            }
            if (image1.activeSelf && image2.activeSelf && image3.activeSelf) 
            {
                
                image4.transform.DOLocalMoveX(281.5f, 0f).SetUpdate(true).SetEase(Ease.OutCirc).OnComplete(() => {
                    image4.SetActive(true);
                });
            }

            if (image1.activeSelf && image2.activeSelf && image3.activeSelf && image4.activeSelf) 
            {
                
                image5.transform.DOLocalMoveY(-95f, 0f).SetUpdate(true).SetEase(Ease.OutCirc).OnComplete(() => {
                    image5.SetActive(true);
                });
            }

            if (image1.activeSelf && image2.activeSelf && image3.activeSelf && image4.activeSelf && image5.activeSelf) 
            {
                
                image6.transform.DOLocalMoveY(-95f, 0f).SetUpdate(true).SetEase(Ease.InQuad).OnComplete(() => {
                    image6.SetActive(true);
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
