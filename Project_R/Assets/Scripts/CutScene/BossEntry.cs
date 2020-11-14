using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class BossEntry : MonoBehaviour
{
    [SerializeField] private GameObject player = null;
    [SerializeField] private GameObject ground = null;
    [SerializeField] private GameObject sky = null;
    [SerializeField] private Text text = null;

    void Start()
    {
        text.DOFade(0f, 0f);
        StartCoroutine(EntryScene());
    }

    private void Update()
    {
        ground.transform.position += Vector3.left * Time.deltaTime * 2;
        sky.transform.position += Vector3.left * Time.deltaTime;
    }

    private IEnumerator EntryScene()
    {   
        player.GetComponent<Animator>().Play("PlayerMove");
        player.transform.DOMoveX(-0.8f, 1.5f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(1.5f);
        text.DOFade(1.0f, 1.0f);
        yield return new WaitForSeconds(3.5f);
        SceneManager.LoadScene("Boss");
    }
    
}
