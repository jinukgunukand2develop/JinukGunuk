using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
using UnityEngine.XR;

public class UIT : MonoBehaviour
{
    public bool bKeyTutorialActive = false;

    public GameObject Keys;
    public GameObject menuSet;
    private void Update()
    {
        if (!Keys.activeSelf)
        {
            if (Input.GetButtonDown("Cancel"))
            {
                Time.timeScale = 0;
                menuSet.SetActive(true);
            }
        }
    }
    public void OnClickXBtn()
    {
        bKeyTutorialActive = false;
        Keys.SetActive(false);
        Time.timeScale = 1;
    }
    public void OnClickContinueButton()
    {
        menuSet.SetActive(false);
        if(!bKeyTutorialActive)
        {
            Time.timeScale = 1;
        }
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
