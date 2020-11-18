using System.Collections;
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
	public Animator animator;
    bool facingRight = true;
    bool death = true;

    [Header("Audio")]

    public AudioClip walking;
    public AudioSource audio1;
    public AudioClip shooting;
    public AudioSource audio2;

    public bool walkingSound = false;
    public bool shootingSound = false;

    [Header("Enemy Health")]
    public int maxHealth = 100;
    public int health;
    public PlayerHealthBar playerHealthBar;

    // Start is called before the first frame update
    void Start()
    {
       playerRigidbody = GetComponent<Rigidbody2D> ();

        audio1 = GetComponent<AudioSource>();
        audio1.clip = walking;

        audio2 = GetComponent<AudioSource>();
        audio1.clip = shooting;

         health = maxHealth;
        playerHealthBar.setMaxHealth(maxHealth);
 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey (KeyCode.D)) 
        {
			transform.localRotation = Quaternion.Euler (0, 0, 0);
			transform.Translate (Vector2.right * speed * Time.deltaTime);
			animator.SetBool ("move", true);
            walkingSound = true;
        }
		if (Input.GetKey (KeyCode.A)) 
        {
			transform.localRotation = Quaternion.Euler (0, 180, 0);
			transform.Translate (Vector2.right * speed * Time.deltaTime);
            facingRight = false;
			animator.SetBool ("move", true);
            walkingSound = true;
        }
        // player is unable to jump when the player is moving, the player has to stop moving to jump
        if (Input.GetKey(KeyCode.Space))
        {
            Jump ();
        }
         
           if (health <=0)
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
  public void TakeDamage(int damage)
    {

        health -= damage;
        playerHealthBar.SetHealth(health);

    }
    public void  Die()
    {

    }

}
