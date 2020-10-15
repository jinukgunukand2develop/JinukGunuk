using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialFinishEvent : MonoBehaviour
{
    private Vector2 V2LocationBetweenPlayerAndFlag = Vector2.zero;

    void Update()
    {
        V2LocationBetweenPlayerAndFlag.x = Mathf.Abs(FindObjectOfType<PlayerMove>().transform.localPosition.x - transform.localPosition.x);
        V2LocationBetweenPlayerAndFlag.y = Mathf.Abs(FindObjectOfType<PlayerMove>().transform.localPosition.y - transform.localPosition.y);
        if(V2LocationBetweenPlayerAndFlag.x <= 0.2f && V2LocationBetweenPlayerAndFlag.y <= 0.2f)
        {
            Debug.Log("Finish Event");
            gameObject.SetActive(false);
            SceneManager.LoadScene("Clear");
        }
    }
}
