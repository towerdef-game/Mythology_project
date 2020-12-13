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
    public SpriteRenderer sr;
    private Material red;
    private Material matdefault;
    void Start()
    {
        currentHealh = maxHealth;
        red = Resources.Load("red", typeof(Material)) as Material;
        matdefault = sr.material;
        player = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponentInParent<Animator>();
        source = GetComponent<AudioSource>();
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
        source.Play();
        player.GetComponent<PlayerCombat>().currentPlayerKill++;
          Destroy(thisobject);
    }
    public void TakeDamageEnemy(int damage)
    {
        sr.material = red;
        currentHealh -= damage;
        Invoke("resetmaterial", .5f);
        // playerHealthBar.SetHealth(currentPlayerHealth);
        //   anim.SetBool("attacked", true);
    }
    void resetmaterial()
    {
        sr.material = matdefault;
    }
}
