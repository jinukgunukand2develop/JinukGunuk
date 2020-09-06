using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchToTutorialScene : MonoBehaviour
{

    // Update is called once per frame
    void Start()
    {
        StartCoroutine(AutoSkip());
    }


    IEnumerator AutoSkip()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Tutorial");
    }
}
