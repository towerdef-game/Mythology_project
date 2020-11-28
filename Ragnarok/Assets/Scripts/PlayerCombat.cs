using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask Enemy;

    public float attackRate = 2f;
    float nextAttack = 0;
   // public EnemyTest enemy;
    public int damage = 10;
   
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
}
