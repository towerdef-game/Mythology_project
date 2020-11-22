using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerareacheck : MonoBehaviour
{
    private enemy_behaviour enemyparent;
    private void Awake()
    {
        enemyparent = GetComponentInParent<enemy_behaviour>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gameObject.SetActive(false);
            enemyparent.target = collision.transform;
            enemyparent.inrange = true;
            enemyparent.hotzone.SetActive(true);
        }
    }
}
