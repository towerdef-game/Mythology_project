using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTest : MonoBehaviour
{
    //private PlayerCombat player; 
    public GameObject thisobject;
    public int maxHealth = 100;
    public int currentHealh;
    // Start is called before the first frame update
    void Start()
    {currentHealh = maxHealth;
   // player.GetComponent<PlayerCombat>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(currentHealh <=0)
        {
           // player.currentPlayerKill ++;
            
            Destroy(thisobject);
        }
    }

  
    public void TakeDamageEnemy(int damage)
    {

        currentHealh -= damage;
       // playerHealthBar.SetHealth(currentPlayerHealth);

    }
}
