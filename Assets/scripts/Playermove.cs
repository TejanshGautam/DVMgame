using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public MovementJoystick movementJoystick;
    public float playerSpeed;
    public float dashSpeed=10f;
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sprite;
    private bool isDashing=false;
    public float dashTimer=0.125f;
    private float dashStartTime=0f;
    public TrailRenderer trailRenderer;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>(); // Move Animator initialization here
        sprite = GetComponent<SpriteRenderer>(); // Move SpriteRenderer initialization here
        trailRenderer.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = movementJoystick.joystickVec;
        MoveCharacter(direction); // Call MoveCharacter() with joystick direction
        if(Input.GetKeyDown(KeyCode.Q)){
            isDashing=true;
        }
        if(isDashing && dashStartTime<=dashTimer){
            rb.velocity = direction * dashSpeed;
            dashStartTime+=Time.deltaTime;
            trailRenderer.enabled = true;
        }
        else{
            dashStartTime=0f;
            isDashing=false;
            rb.velocity = direction * playerSpeed;
            trailRenderer.enabled = false;
        }
    }

    public void MoveCharacter(Vector2 direction)
    {
        // Set animation parameters based on the movement direction
        if (direction.x != 0)
        {
            anim.SetBool("Running", true);
            Vector3 newScale = this.transform.localScale;
            if(direction.x>0)
                newScale.x = 0.8f;
            else
                newScale.x = -0.8f;
            this.transform.localScale = newScale;
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
