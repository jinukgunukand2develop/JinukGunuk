using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stage1Finish : MonoBehaviour
{
    [SerializeField] private GameObject player = null;

    void Update()
    {
        if (player.transform.position.x >= 42.0f)
        {
            Debug.Log("Finish Event");
            gameObject.SetActive(false);
            SceneManager.LoadScene("BossEntry");
        }
    }
}
