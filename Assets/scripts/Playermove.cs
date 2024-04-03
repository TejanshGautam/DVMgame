using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    public MovementJoystick movementJoystick;
    public float playerSpeed;
    public float dashSpeed = 10f;
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sprite;
    private bool isDashing = false;
    private float dashDuration = 0.125f;
    private float dashTimer = 0f;
    public TrailRenderer trailRenderer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        trailRenderer.enabled = false;

        // Find the button component in the scene
        Button dashButton = GameObject.Find("DashButton").GetComponent<Button>();

        // Add a listener to the button to call the Dash method when clicked
        dashButton.onClick.AddListener(Dash);
    }

    void Update()
    {
        Vector2 direction = movementJoystick.joystickVec; // Get the direction from the joystick
        MoveCharacter(direction); // Move the character based on the joystick input

        if (isDashing)
        {
            if (dashTimer < dashDuration)
            {
                rb.velocity = direction * dashSpeed;
                dashTimer += Time.deltaTime;
            }
            else
            {
                isDashing = false;
                rb.velocity = direction * playerSpeed;
                dashTimer = 0f;
                trailRenderer.enabled = false;
            }
        }
    }

    public void MoveCharacter(Vector2 direction)
    {
        if (!isDashing)
        {
            // Set animation parameters based on the movement direction
            if (direction.x != 0)
            {
                anim.SetBool("Running", true);
                Vector3 newScale = this.transform.localScale;
                newScale.x = direction.x > 0 ? 0.8f : -0.8f;
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

            // Move the player based on joystick input
            rb.velocity = direction * playerSpeed;
        }
    }

    public void Dash()
    {
        isDashing = true;
        trailRenderer.enabled = true;
    }
}
