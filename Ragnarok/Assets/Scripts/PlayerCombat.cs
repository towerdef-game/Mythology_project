﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;
    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0 ))
        {
            Attack();
        }
    }
    public void Attack()
    {
        animator.SetTrigger("Attack");

    }
}
