using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hotzonecheck : MonoBehaviour
{
    private enemy_behaviour enemyparent;
    private bool inrange;
    private Animator anim;

    private void Awake()
    {
        enemyparent = GetComponentInParent<enemy_behaviour>();
        anim = GetComponentInParent<Animator>();
    }
    private void Update()
    {
         if(inrange && !anim.GetCurrentAnimatorStateInfo(0).IsName("attack"))
        {
            enemyparent.flip();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            inrange = true;
     
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            inrange = false;
            gameObject.SetActive(false);
            enemyparent.triggerarea.SetActive(true);
            enemyparent.inrange = false;
            enemyparent.selecttarget();
        }
    }
}
