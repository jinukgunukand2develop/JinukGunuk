using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeadScene : MonoBehaviour
{
    
    void Start()
    {
        StartCoroutine(ReturnMain());
    }

    private IEnumerator ReturnMain()
    {
        yield return new WaitForSeconds(6.0f);
        SceneManager.LoadScene("MainMenu");
    }
}
