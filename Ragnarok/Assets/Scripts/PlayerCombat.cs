using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayer;

    public float attackRate = 2f;
    float nextAttack = 0;
    //public Player player;
   
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
    }
    public void Attack()
    {
        animator.SetTrigger("Attack");
        Collider2D[] hit = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);

        foreach(Collider2D	enemy in hit)
        {
            // TODO: ADD attack damage

            //ADD THAT WHEN THE ENEMY DIES IT ADDS 1 TO PLAYER KILL COUNT POWER UP
            //enemy.GetComponent<Player>().KillCount(2);

        }
    }

    void OnDrawGizmosSelected()
    {
        if(attackPoint == null)
        return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
