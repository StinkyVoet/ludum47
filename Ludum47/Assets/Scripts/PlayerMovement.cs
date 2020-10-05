using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;

    [Header("Movement Settings")]
    public float speed = 5;
    public float jumpForce = 2f;

    [Header("Groundcheck Settings")]
    public Transform groundCheck;
    public float groundDistance;
    public LayerMask groundMask;

    bool isGrounded;
    bool wallCollision;

    public AudioSource Jump;
    public AudioSource Walk;

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundDistance, groundMask);

        float x = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(x * speed, rb.velocity.y);

        if (isGrounded && rb.velocity.magnitude > 2f && Walk.isPlaying == false)
        {
            Walk.Play();
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            Jump.Play();
        }
        else if (Input.GetButtonDown("Jump") && wallCollision)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            Jump.Play();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        wallCollision = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        wallCollision = false;
    }
}
