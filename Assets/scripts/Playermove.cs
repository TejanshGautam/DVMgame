using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public MovementJoystick movementJoystick;
    public float playerSpeed;
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sprite;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>(); // Move Animator initialization here
        sprite = GetComponent<SpriteRenderer>(); // Move SpriteRenderer initialization here
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 direction = movementJoystick.joystickVec;
        MoveCharacter(direction); // Call MoveCharacter() with joystick direction
        rb.velocity = direction * playerSpeed;
    }

    public void MoveCharacter(Vector2 direction)
    {
        // Set animation parameters based on the movement direction
        if (direction.x != 0)
        {
            anim.SetBool("Running", true);
            sprite.flipX = direction.x < 0;
        }
        else if (direction.y != 0)
        {
            anim.SetBool("Running", true);
        }
        else
        {
            anim.SetBool("Running", false);
        }
    }
}
