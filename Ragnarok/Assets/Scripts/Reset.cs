using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset : MonoBehaviour 
{
    

	// Use this for initialization
	void Start () 
    {
      
        
            
             GameObject.FindGameObjectsWithTag("Player");
             Player.currentPlayerHealth = 10;
        
      
    }   
	
}
