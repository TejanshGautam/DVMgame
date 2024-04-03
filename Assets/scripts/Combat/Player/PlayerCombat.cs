using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;
    public Transform attackPoint;
    public float attackRange=0.5f;
    public int attackDamage=40;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            Attack();
        }
    }
    void Attack(){
        //Play Attack Anim
        animator.SetTrigger("Attack");
    }

    public void attacked(){
        //Detect Enemy in range
        Collider2D[] hitObjects = Physics2D.OverlapCircleAll(attackPoint.position,attackRange);
        foreach(Collider2D enemy in hitObjects)
        {
            if(enemy.tag=="Enemy")
            {
                enemy.GetComponent<Health>().TakeDamage(attackDamage);
            }
        }
    }

    void OnDrawGizmosSelected(){
        if(attackPoint){
        Gizmos.DrawWireSphere(attackPoint.position,attackRange);
        }
    }
}
