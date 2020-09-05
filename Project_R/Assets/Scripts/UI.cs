using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public GameObject option;




    public void OnClickXButton() 
    {
        option.SetActive(false);
    }

    public void OnClickStartButton()
    {
        SceneManager.LoadScene("Main");
    }

    public
         void OnClickOptionButton()
    {
        option.SetActive(true);

    }
    public void OnClickHomeButton()
    {
        SceneManager.LoadScene("Start");
    }
    public void GameExit()
    {
        Application.Quit();
    }

   

}
