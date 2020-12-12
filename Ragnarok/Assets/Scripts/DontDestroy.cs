using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
         int numbGameManagers = FindObjectsOfType<GameManager>().Length;
        if (numbGameManagers > 1)
        {
            Destroy(gameObject);// if there is more than 1  GameManager scripts in the game destroy this one
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
