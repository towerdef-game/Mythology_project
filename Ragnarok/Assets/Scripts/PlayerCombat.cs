using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayer;
   
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0 ))
        {
            Attack();
        }
    }
    public void Attack()
    {
        animator.SetTrigger("Attack");
        Collider2D[] hit = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);

        foreach(Collider2D	enemy in hit)
        {

        }
    }

    void OnDrawGizmosSelected()
    {
        if(attackPoint == null)
        return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
