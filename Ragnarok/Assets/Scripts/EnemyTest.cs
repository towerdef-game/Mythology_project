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
<<<<<<< Updated upstream
    public AudioClip clips;
    public AudioSource source;
=======
    public SpriteRenderer sr;
    private Material red;
    private Material matdefault;
>>>>>>> Stashed changes
    void Start()
    {
        currentHealh = maxHealth;

        player = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponentInParent<Animator>();
<<<<<<< Updated upstream
        source = GetComponent<AudioSource>();
=======
        red = Resources.Load("red", typeof(Material)) as Material;
        matdefault = sr.material;
>>>>>>> Stashed changes
    }

    // Update is called once per frame
    void Update()
    {
        if(currentHealh <=0)
        {
     
            die();
        } else
        {
           
        }
    }
    void resetmaterial()
    {
        sr.material = matdefault;
    }
    public void die()
    {

        player = GameObject.FindGameObjectWithTag("Player");
        source.Play();
        player.GetComponent<PlayerCombat>().currentPlayerKill++;
          Destroy(thisobject,2f);
    }
    public void TakeDamageEnemy(int damage)
    {
        sr.material = red;
        currentHealh -= damage;
        // playerHealthBar.SetHealth(currentPlayerHealth);
        // anim.SetBool("attacked", true);
        Invoke("resetmaterial", .5f);
    }
    public void resetdamge()
    {
        anim.SetBool("attacked", false);
    }

}
