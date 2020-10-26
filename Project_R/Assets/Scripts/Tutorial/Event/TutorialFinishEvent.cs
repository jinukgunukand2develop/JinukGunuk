using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialFinishEvent : MonoBehaviour
{
    [SerializeField] private GameObject player = null;

    void Update()
    {
        if(Vector2.Distance(transform.position, player.transform.position) <= 0.2f)
        {
            Debug.Log("Finish Event");
            gameObject.SetActive(false);
            SceneManager.LoadScene("Clear");
        }
    }
}
