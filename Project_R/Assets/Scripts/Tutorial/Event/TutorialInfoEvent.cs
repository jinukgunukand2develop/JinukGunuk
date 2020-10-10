    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialInfoEvent : MonoBehaviour
{
    private Vector2 V2LocationBetweenPlayerAndFlag = Vector2.zero;
    [SerializeField] private GameObject keys = null;

    void Update()
    {
        V2LocationBetweenPlayerAndFlag.x = Mathf.Abs(FindObjectOfType<PlayerMove>().transform.localPosition.x - transform.localPosition.x);
        V2LocationBetweenPlayerAndFlag.y = Mathf.Abs(FindObjectOfType<PlayerMove>().transform.localPosition.y - transform.localPosition.y);
        if (V2LocationBetweenPlayerAndFlag.x <= 0.2f && V2LocationBetweenPlayerAndFlag.y <= 0.2f)
        {
            Debug.Log("Info Event");
            gameObject.SetActive(false);
            keys.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
