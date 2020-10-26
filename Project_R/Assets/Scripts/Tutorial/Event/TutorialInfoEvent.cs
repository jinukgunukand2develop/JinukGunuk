    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialInfoEvent : MonoBehaviour
{
    private UIT uit = null;

    [SerializeField] private GameObject player = null;
    [SerializeField] private GameObject keys = null;

    private void Start()
    {
        uit = FindObjectOfType<UIT>();
    }

    void Update()
    {
        if (Vector2.Distance(transform.position, player.transform.position) <= 0.2f)
        {
            Debug.Log("Info Event");
            gameObject.SetActive(false);
            uit.bKeyTutorialActive = true;
            keys.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
