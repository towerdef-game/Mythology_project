﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class camera : MonoBehaviour
{

    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
    // player = GameObject.FindGameObjectWithTag("Player").transform;
    }

   

    // Update is called once per frame
    void Update()
    {
        Vector3 temp = transform.position;

        temp.x = player.position.x;
       temp.y = player.position.y;

        transform.position = temp;
    }
}
