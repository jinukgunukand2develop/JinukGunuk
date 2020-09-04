using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public void OnClickStartButton()
    {
        SceneManager.LoadScene("Main");
    }
    public void OnClickHomeButton()
    {
        SceneManager.LoadScene("Start");
    }
}
