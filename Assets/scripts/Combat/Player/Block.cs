using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public Collider2D playerCollider;
    public float blockDuration = 1f;
    public float blockCooldown = 1f;
    public Animator animator;
    public bool isBlocking = false;
    private bool isCooldown = false;

    void Update()
    {
        if (!isCooldown && Input.GetKeyDown(KeyCode.E))
        {
            animator.SetTrigger("Block");
            StartCoroutine(BlockCoroutine());

        }
    }

    IEnumerator BlockCoroutine()
    {
        if (!isBlocking)
        {
            isBlocking = true;
            playerCollider.enabled = false;

            yield return new WaitForSeconds(blockDuration);

            playerCollider.enabled = true;
            isBlocking = false;

            StartCoroutine(BlockCooldownCoroutine());
        }
    }

    IEnumerator BlockCooldownCoroutine()
    {
        isCooldown = true;
        yield return new WaitForSeconds(blockCooldown);
        isCooldown = false;
    }
}
