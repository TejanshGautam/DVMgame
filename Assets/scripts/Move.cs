using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed = 3;
    Vector2 velocity;
    Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sprite;
    // Start is called before the first frame update
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        velocity = Vector2.zero;
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();

    }
    private void Update()
    {
        velocity.x = Input.GetAxisRaw("Horizontal");
        velocity.y = Input.GetAxisRaw("Vertical");
    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + velocity * speed * Time.fixedDeltaTime);
        if(velocity.x > 0 )
        {
            anim.SetBool("running",true);
            sprite.flipX = false;
        }
        else if (velocity.x < 0 )
        {
            anim.SetBool("running", true);
            sprite.flipX = true;
        }
        else if (velocity.y < 0 || velocity.y > 0f)
        {
            anim.SetBool("running", true);
        }
        else
        {
            anim.SetBool("running", false);
        }

    }
}
