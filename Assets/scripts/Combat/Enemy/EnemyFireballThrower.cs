using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFireballThrower : MonoBehaviour
{
    public GameObject fireballPrefab;
    public Transform playerTransform;
    public float throwForce = 10f;
    public float throwInterval = 2f;
    public int fireballLifetime=2;
    private float throwTimer = 0f;
    Vector3 direction;
    public Animator animator;
    RaycastHit2D hit;
    public float moveSpeed=0.5f;

    void Start()
    {
        // Find the player GameObject
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        // Check if it's time to throw a fireball
        throwTimer += Time.deltaTime;

        // Calculate direction towards the player
        direction = (playerTransform.position - transform.position).normalized;
        Vector3 newScale = this.transform.localScale;
        if(direction.x>0)
            newScale.x = 0.8f;
        else
            newScale.x = -0.8f;
        this.transform.localScale = newScale;
        
        if (throwTimer >= throwInterval)
        {
             if(Physics2D.Linecast(transform.position,playerTransform.position)){
                hit=Physics2D.Linecast(transform.position,playerTransform.position);
                if(hit.collider.gameObject.tag=="Player"){

                    animator.SetTrigger("fire");
                    // Reset the timer
                    throwTimer = 0f;

                    // Instantiate fireball prefab
                    GameObject fireball = Instantiate(fireballPrefab, transform.position, Quaternion.identity);

                    // Apply force to the fireball
                    fireball.GetComponent<Rigidbody2D>().velocity = direction * throwForce;

                        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                    fireball.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

                    Destroy(fireball, fireballLifetime);

                    throwInterval=2+Random.Range(-1,1);
                }
             }
        }
    }
}
