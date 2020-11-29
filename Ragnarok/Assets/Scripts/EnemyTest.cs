using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTest : MonoBehaviour
{
    public GameObject player; 
    public GameObject thisobject;
    public int maxHealth = 100;
    public int currentHealh;
    // Start is called before the first frame update
    void Start()
    {
        currentHealh = maxHealth;
    
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(currentHealh <=0)
        {
     
            die();
        }
    }

   public void die()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        player.GetComponent<PlayerCombat>().currentPlayerKill++;
          Destroy(thisobject);
    }
    public void TakeDamageEnemy(int damage)
    {

        currentHealh -= damage;
       // playerHealthBar.SetHealth(currentPlayerHealth);

    }
}
