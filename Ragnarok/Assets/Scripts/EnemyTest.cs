using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTest : MonoBehaviour
{
    public Player player; 
    public int maxHealth = 100;
    public int currentHealh;
    // Start is called before the first frame update
    void Start()
    {currentHealh = maxHealth;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(currentHealh <=0)
        {
            Destroy(this.gameObject);
        }
    }

  
    public void TakeDamageEnemy(int damage)
    {

        currentHealh -= damage;
       // playerHealthBar.SetHealth(currentPlayerHealth);

    }
}
