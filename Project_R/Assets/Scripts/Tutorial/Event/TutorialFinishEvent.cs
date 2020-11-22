using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialFinishEvent : MonoBehaviour
{
    [SerializeField] private GameObject player = null;

    void Update()
    {
        if(player.transform.position.x >= 59.4f)
        {
            Debug.Log("Finish Event");
            gameObject.SetActive(false);
            SceneManager.LoadScene("Stage1Entry");
        }
    }
}
