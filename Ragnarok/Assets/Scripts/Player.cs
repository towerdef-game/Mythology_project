﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Player Movement")]
    public float speed = 3.0f;             
	public float jump = 200.0f;
	public Rigidbody2D playerRigidbody;   
    public Collider2D playerCollider;
    public LayerMask JumpLayer;
    
    public float pJumpSpeed = 100f;
     public camera cam;

	public Animator Anim;


    bool facingRight = true;
    //bool death = true;

  

    public bool walkingSound = false;
    public bool shootingSound = false;

    [Header("Player Health")]
    public int maxHealth = 100;
    public static int currentPlayerHealth;
   // public PlayerHealthBar playerHealthBar;
    public int maxKillAmount  = 0;
    public static int currentPlayerKill;


    // Start is called before the first frame update
    void Awake ()
    {
        currentPlayerHealth = maxHealth;
        currentPlayerKill = maxKillAmount;
        //playerHealthBar.setMaxHealth(maxKillAmount);
        Anim = GetComponent<Animator>();
        cam.GetComponent<camera>().player = this.transform;
    }

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D> ();
        Anim = GetComponent<Animator>();
     
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey (KeyCode.D)) 
        {
			transform.localRotation = Quaternion.Euler (0, 0, 0);
			transform.Translate (Vector2.right * speed * Time.deltaTime);

            facingRight = true;

	 

			Anim.SetBool ("move", true);
         //   animatorThor.SetBool ("move", true);
          //  animatorHeimdall.SetBool ("move", true);
            walkingSound = true;
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            Anim.SetBool("move", false);


        }

        if (Input.GetKey (KeyCode.A)) 
        {
			transform.localRotation = Quaternion.Euler (0, 180, 0);
			transform.Translate (Vector2.right * speed * Time.deltaTime);
            facingRight = false;


        

            Anim.SetBool("move", true);
         
		
            walkingSound = true;
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            Anim.SetBool("move", false);

        }


        //FIXME: player is unable to jump when the player is moving, the player has to stop moving to jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
           Jump ();
            //GetComponent<Rigidbody2D> ().AddForce (Vector2.up * jump);
        }
       
    
        if (currentPlayerHealth <=0)
        {
            Die();
        }  

    
    }

    void Flip()
    {
 
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }

    void Jump ()
    { 
        if (!playerCollider.IsTouchingLayers(JumpLayer))
        {
            return;
        }
        Vector2 jumpVelocityToAdd = new Vector2(0f, pJumpSpeed);
        playerRigidbody.velocity += jumpVelocityToAdd;
        
    }
    public void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "enemy")
        {
            TakeDamage(100);
            Debug.Log("die");
        }

   }
  public void TakeDamage(int damage)
    {

        currentPlayerHealth -= damage;
       // playerHealthBar.SetHealth(currentPlayerHealth);

    }
    public void KillCount(int damage)
    {

        currentPlayerKill += damage;
        //playerHealthBar.SetHealth(currentPlayerKill);

    }
    public void  Die()
    {
    Destroy(this.gameObject);
        //Debug.Log("Dead");
    }

}
