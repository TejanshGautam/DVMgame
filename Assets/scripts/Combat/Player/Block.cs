using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Block : MonoBehaviour
{
    public Collider2D playerCollider;
    public float blockDuration = 1f;
    public float blockCooldown = 1f;
    public Animator animator;
    public bool isBlocking = false;
    private bool isCooldown = false;

    void Start()
    {
        // Find the button component in the scene
        Button blockButton = GameObject.Find("BlockButton").GetComponent<Button>();

        // Add a listener to the button to call the StartBlocking method when clicked
        blockButton.onClick.AddListener(StartBlocking);
    }

    public void StartBlocking()
    {
        if (!isCooldown && !isBlocking)
        {
            animator.SetTrigger("Block");
            StartCoroutine(BlockCoroutine());
        }
    }

    IEnumerator BlockCoroutine()
    {
        isBlocking = true;
        playerCollider.enabled = false;
        yield return new WaitForSeconds(blockDuration);
        playerCollider.enabled = true;
        isBlocking = false;
        StartCoroutine(BlockCooldownCoroutine());
    }

    IEnumerator BlockCooldownCoroutine()
    {
        isCooldown = true;
        yield return new WaitForSeconds(blockCooldown);
        isCooldown = false;
    }
}
