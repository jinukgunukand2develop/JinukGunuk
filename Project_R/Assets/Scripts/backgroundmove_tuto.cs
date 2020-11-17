using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class backgroundmove_tuto : MonoBehaviour
{
    [SerializeField]

    private float backg_speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * Time.deltaTime * backg_speed); ;
    }
}
