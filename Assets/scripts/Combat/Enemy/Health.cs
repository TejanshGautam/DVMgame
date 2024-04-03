using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth=100;
    int currentHealth;
    public Animator animator;

    void Start()
    {
        currentHealth=maxHealth;
    }

    public void TakeDamage(int damage){
        currentHealth-=damage;
        
        //Hurt anim
        animator.SetTrigger("Hurt");
        if(currentHealth<=0){
            Die();
        }
    }   
    void Die(){
        //Die anim
        animator.SetBool("isDead",true);
        Debug.Log("Enemy died");
    }
    void dest(){
        Object.Destroy(this.gameObject);
    }
}
