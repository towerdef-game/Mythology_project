﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundmanger : MonoBehaviour
{
    public static AudioClip death, hit;
    static AudioSource src;

     void Start()
    {
        death = Resources.Load<AudioClip>("enemydeath");
        hit = Resources.Load<AudioClip>("Hit");
        src = GetComponent<AudioSource>();

    }

    public static void playsound(string clip)
    {
        switch (clip)
        {
            case "die":
                src.PlayOneShot(death);
                break;

            case "att":
                src.PlayOneShot(hit);
                break;
        }
    }
}