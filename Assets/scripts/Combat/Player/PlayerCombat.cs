using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Required for UI functionality

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public int attackDamage = 40;

    void Start()
    {
        // Find the button component in the scene
        Button attackButton = GameObject.Find("AttackButton").GetComponent<Button>();

        // Add a listener to the button to call the Attack method when clicked
        attackButton.onClick.AddListener(Attack);
    }

    public void Attack()
    {
        //Play Attack Anim
        animator.SetTrigger("Attack");
        // Call the attacked method after the attack animation is played
        StartCoroutine(PerformAttack());
    }

    IEnumerator PerformAttack()
    {
        // Wait for a short duration to ensure the animation plays before attacking
        yield return new WaitForSeconds(0.1f);

        // Detect enemies in range and deal damage
        Collider2D[] hitObjects = Physics2D.OverlapCircleAll(attackPoint.position, attackRange);
        foreach (Collider2D enemy in hitObjects)
        {
            if (enemy.CompareTag("Enemy"))
            {
                enemy.GetComponent<Health>().TakeDamage(attackDamage);
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint)
        {
            Gizmos.DrawWireSphere(attackPoint.position, attackRange);
        }
    }
}
