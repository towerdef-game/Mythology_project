using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_behaviour : MonoBehaviour
{
    #region public variables
  
    public float attackdistance;
    public float movespeed;
    public float attackcooldowntime;
    public Transform leftlimit;
    public Transform rightlimit;
   [HideInInspector] public Transform target;
   [HideInInspector] public bool inrange; // check if player is in range
    public GameObject hotzone;
    public GameObject triggerarea;
    #endregion

    #region private variables


    private Animator anim;
    private float distance; // store the distacnce from player 
    private bool attackmode;
  
    private bool cooling; // check if enemy is cooling after attack
    private float intimer;
    #endregion
    // Update is called once per frame
    void Awake()
    {
        selecttarget();
        intimer = attackcooldowntime;
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (!attackmode)
        {
            move();
        }
     

        if(!insidelimits() && !inrange && !anim.GetCurrentAnimatorStateInfo(0).IsName("attack"))
        {
            selecttarget();
        }
        //when Player is detected
     
        
        if(inrange)
        {

            Enemylogic();
        }
    }
  


    void Enemylogic()
    {
        distance = Vector3.Distance(transform.position, target.position);
        if(distance> attackdistance)
        {

            stopattack();
        }
        else if(attackdistance >= distance && cooling == false)
        {
            attack();
        }
        if (cooling)
        {
            cooldown();
            anim.SetBool("attack", false);
        }
    }

    void move()
    {
        anim.SetBool("canwalk", true);
        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("attack"))
        {
            Vector2 targetPosition = new Vector2(target.position.x, transform.position.y);

            transform.position = Vector2.MoveTowards(transform.position, targetPosition, movespeed * Time.deltaTime);
        }
    }

    void attack()
    {
        attackcooldowntime = intimer;
        attackmode = true;

        anim.SetBool("canwalk", false);
        anim.SetBool("attack", true);
    }
    void cooldown()
    {
        attackcooldowntime -= Time.deltaTime;

        if(attackcooldowntime <=0 && cooling && attackmode)
        {
            cooling = false;
            attackcooldowntime = intimer;
        }
    }
    void stopattack()
    {
        cooling = false;
        attackmode = false;
        anim.SetBool("attack", false);
    }
  
    public void Triggercooling()
    {
        cooling = true;
    }

    private bool insidelimits()
    {
        return transform.position.x > leftlimit.position.x && transform.position.x < rightlimit.position.x;
    }
    
    public void selecttarget()
    {
        float distancetoleft = Vector2.Distance(transform.position, leftlimit.position);
        float distancetoright = Vector2.Distance(transform.position, rightlimit.position);

        if(distancetoleft > distancetoright)
        {
            target = leftlimit;
        }
        else
        {
            target = rightlimit;
        }
        flip();
    }
    public void flip()
    {
        Vector3 rotation = transform.eulerAngles;
        if(transform.position.x > target.position.x)
        {
            rotation.y = 180f;
        }
        else
        {
            rotation.y = 0f;
        }
        transform.eulerAngles = rotation;
    }
    
}
