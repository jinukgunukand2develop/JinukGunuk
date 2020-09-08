using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public GameObject Option;

    private void Update()
    {
        
    }


    public void OnClickStartButton()
    {
        SceneManager.LoadScene("Loading");
    }

    public void OnClickOptionButton() 
    {
        Option.SetActive(true);
    }
    public void OnClickXBtn() 
    {
        Option.SetActive(false);
    }


    public void OnClickExitButton() 
    {
        Application.Quit();
    }


}
