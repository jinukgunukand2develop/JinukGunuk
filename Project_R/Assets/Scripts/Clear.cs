using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Clear : MonoBehaviour
{
    void Start()
    {
        Invoke("GoBackToMain", 8.0f);
    }


    void GoBackToMain()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
