using System.Collections;
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
    public TextMeshProUGUI PowerTextRemaining;
    public TextMeshProUGUI PowerTextRemainingTimer;
    public float timer = 3;
   
   public void Start()
   {
     //PowerTextRemainingTimer.text = timer.t
     PowerTextRemainingTimer.SetText(timer.ToString());
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
        if (Input.GetKeyDown (KeyCode.Mouse1)) 
            {
            //KillCount(1);
            currentPlayerKill ++;
            }

        if(currentPlayerKill >= 5)
        {         
            PowerText.enabled = true;
           

            if (Input.GetKeyDown (KeyCode.Z)) 
           {
                PowerText.enabled = false;
                PowerTextRemaining.enabled = true;
                PowerTextRemainingTimer.enabled = true;
                timer -= Time.deltaTime;
                StartCoroutine(("PowerUp"));
                currentPlayerKill -= 5;
                if(timer < 0)
                {
                    PowerTextRemaining.enabled = false;
                    PowerTextRemainingTimer.enabled = false;     
                }
           
            }
        }
    }

     void Attack()
    {
        animator.SetTrigger("Attack");
        Collider2D[] hit = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, Enemy);

        foreach(Collider2D	enemy in hit)
        {
            enemy.GetComponent<EnemyTest>().TakeDamageEnemy(damage);

        }
    }

    void OnDrawGizmosSelected()
    {
        if(attackPoint == null)
        return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    IEnumerator  PowerUp()
    {
         damage *= poweUp;
         attackRange *= poweUp;
         yield return new WaitForSeconds(3);
          damage /= poweUp;
         attackRange /= poweUp;
    }


}


