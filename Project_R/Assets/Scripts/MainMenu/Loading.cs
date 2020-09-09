using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour
{
    [SerializeField]
    protected float speed = 0.1f;
    [SerializeField]
    protected int time = 2;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed);
        time--;

        if (time < 0) 
        {
            SceneManager.LoadScene("Tutorial");
        }
    }




}
