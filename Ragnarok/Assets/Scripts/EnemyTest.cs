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
    public AudioClip clips;
    public AudioSource source;
    public bool dead = false;
    void Start()
    {
        currentHealh = maxHealth;

        player = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponentInParent<Animator>();
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(currentHealh <=0 && !false)
        {
            dead = true;
            die();
        }
    }

   public void die()
    {

        player = GameObject.FindGameObjectWithTag("Player");
        source.Play();
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
