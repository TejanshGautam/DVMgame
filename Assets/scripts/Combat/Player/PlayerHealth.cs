using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float playerHealth = 100f;
    public float damageToFireball = 10f;
    public Animator animator;

    private void OnTriggerEnter2D(Collider2D col)
    {
       
        if(col.tag == "Enemy")
        {
            playerHealth -= damageToFireball;
            animator.SetTrigger("Hurt");
        }
    }
}
