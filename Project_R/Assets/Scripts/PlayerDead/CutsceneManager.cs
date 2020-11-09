using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CutsceneManager : MonoBehaviour
{
    public Text text = null;
    public GameObject player = null;
    public GameObject yasso = null;
    public GameObject screenEffect = null;
    
    void Start()
    {
        text.DOFade(0.0f, 0.0f);
        StartCoroutine(CutScene());
    }

    private IEnumerator CutScene()
    {
        yasso.transform.DOMoveX(0.0f, 0.3f).SetEase(Ease.InOutCubic);
        yasso.GetComponent<Animator>().Play("Yasso_Dash_Attack");
        yield return new WaitForSeconds(0.3f);
        if(yasso.transform.position.x == 0)
        {
            player.GetComponent<Animator>().Play("PlayerKnockBack");
        }
        yield return new WaitForSeconds(0.9f);
        yasso.transform.localScale = new Vector2(-1.0f, 1.0f);
        yasso.GetComponent<Animator>().Play("Yasso_Attack_2");
        yield return new WaitForSeconds(1.2f);
        player.transform.DOMoveY(0.0f, 0.5f).SetEase(Ease.InOutQuad);
        yield return new WaitForSeconds(0.5f);
        player.transform.DOMoveY(0.2f, 1.2f);
        yasso.GetComponent<Animator>().Play("Yasso_Jump");
        yasso.transform.DOMoveY(0.0f, 0.7f).SetEase(Ease.InOutQuad);
        yield return new WaitForSeconds(0.7f);
        screenEffect.GetComponent<Animator>().Play("Yasso_Attack_Special_ScreenEffect");
        yield return new WaitForSeconds(0.6f);
        screenEffect.GetComponent<Animator>().Play("Yasso_Attack_3_ScreenEffect");
        player.transform.DOMove(new Vector2(1.7f, -1.15f), 0.2f).SetEase(Ease.OutExpo);
        yield return new WaitForSeconds(0.2f);
        yasso.transform.DOMoveY(-1.31f, 1.5f).SetEase(Ease.InOutQuad);
        yield return new WaitForSeconds(0.8f);
        screenEffect.GetComponent<Animator>().Play("Yasso_Attack_Idle_ScreenEffect");
        yasso.GetComponent<Animator>().Play("Yasso_idle");
        text.DOFade(1.0f, 2.0f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(6.0f);
        SceneManager.LoadScene("MainMenu");
    }

}
