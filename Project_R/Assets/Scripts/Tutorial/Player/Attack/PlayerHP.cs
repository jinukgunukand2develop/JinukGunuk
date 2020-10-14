using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : GameManager
{
   

    
    


   

    private void Start()
    {
        
    }


    void Update()
    {
        
        if(iPlayerHP <= 0)
        {
            Debug.Log("HP equal or less then 0");
            Debug.Log("HP reset to 100");
            iPlayerHP = 100;
        }
    
        
    }
    

}
