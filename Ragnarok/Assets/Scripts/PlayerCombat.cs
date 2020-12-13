﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask Enemy;
    public float attackRate = 2f;
    float nextAttack = 0;
    public int damage = 10;
    public int currentPlayerKill;
    public int poweUp = 2;
    public TextMeshProUGUI PowerText;
   // public TextMeshProUGUI PowerTextRemaining;
    public TextMeshProUGUI PowerTextRemainingTimer;
    public float timer = 3;
    private SpriteRenderer spr;
    private Material defalut;
    private Material pup;
   
   public void Start()
   {
     //PowerTextRemainingTimer.text = timer.t
     PowerTextRemainingTimer.SetText(timer.ToString());
     currentPlayerKill = 0;
        spr = GetComponent<SpriteRenderer>();
        defalut = spr.material;
        pup = Resources.Load("blue", typeof(Material)) as Material;
    }

    void Update()
    {
        if(Time.time >= nextAttack)
        {    
         if(Input.GetKeyDown(KeyCode.Mouse0 ))
            {
                Attack();
                nextAttack =  Time.time + 1f/attackRate;
            }
        }
    

        if(currentPlayerKill >= 3)
        {         
            PowerText.enabled = true;
           

            if (Input.GetKeyDown (KeyCode.Mouse1)) 
           {
                PowerText.enabled = false;
              //  PowerTextRemaining.enabled = true;
                PowerTextRemainingTimer.enabled = true;
                //  timer -= Time.deltaTime;
                StartCoroutine(("countdown"));
                StartCoroutine(("PowerUp"));
                currentPlayerKill -= 3;
               
           
            }
        }
        if (timer <= 0)
        {
            // PowerTextRemaining.enabled = false;
            PowerTextRemainingTimer.enabled = false;
        }
    }

     void Attack()
    {
        
        animator.SetTrigger("Attack");
        soundmanger.playsound("att");
        Collider2D[] hit = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, Enemy);

        foreach(Collider2D	enemy in hit)
        {
            enemy.GetComponent<EnemyTest>().TakeDamageEnemy(damage);
           // enemy.GetComponent<Animator>().SetBool("attacked", true);
        }
    }

    void OnDrawGizmosSelected()
    {
        if(attackPoint == null)
        return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
    IEnumerator countdown()
    {
        while (timer >= 0)
        {
            PowerTextRemainingTimer.text = "Time remaining: " + timer.ToString();
            yield return new WaitForSeconds(1f);
            timer--;
        }
    }
        IEnumerator  PowerUp()
    {
         damage *= poweUp;
         attackRange *= poweUp;
        spr.material = pup;
         yield return new WaitForSeconds(3);
          damage /= poweUp;
         attackRange /= poweUp;
        spr.material = defalut;
    }


}


