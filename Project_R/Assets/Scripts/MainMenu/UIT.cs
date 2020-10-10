using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class UIT : MonoBehaviour
{
    public GameObject Keys;
    public GameObject menuSet;
    private void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            menuSet.SetActive(true);
        }
    }
    public void OnClickXBtn()
    {
        Keys.SetActive(false);
        Time.timeScale = 1;
    }
    public void OnClickContinueButton()
    {
        menuSet.SetActive(false);
        Time.timeScale = 1;
    }
    public void OnClickHomeButton()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
    }
    public void GameExit()
    {
        Application.Quit();
    }

}
