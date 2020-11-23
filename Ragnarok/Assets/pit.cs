using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pit : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Destroy(collision.gameObject);
        }
    }
}
