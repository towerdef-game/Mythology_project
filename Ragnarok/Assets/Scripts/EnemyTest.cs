using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTest : MonoBehaviour
{
   // public Player player; 
    public int maxhealth = 100;
    public int currentHealth; 
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxhealth;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentHealth<= 0)
        {
            Die();
        }
    }

   public  void OnTriggerEnter()
    {
        
    }
    public void TakeDamage(int damage)
    {

        currentHealth -= damage;
       // playerHealthBar.SetHealth(currentPlayerHealth);

    }
    public void Die()
    {
         //player.GetComponent<Player>().KillCount(3);
        // player.KillCount(3);
        Destroy(this.gameObject,0.1f);
    }
}
