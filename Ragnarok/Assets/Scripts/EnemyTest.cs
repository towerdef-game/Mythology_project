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
    public Animator anim;
    void Start()
    {
        currentHealh = maxHealth;

        player = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponentInParent<Animator>();
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
     anim.SetBool("attacked", true);
    }
    public void resetdamge()
    {
        anim.SetBool("attacked", false);
    }

}
