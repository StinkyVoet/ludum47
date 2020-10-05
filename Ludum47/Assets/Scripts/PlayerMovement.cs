using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Collider2D col;

    [Header("Movement Settings")]
    public float speed = 5;
    public float jumpForce = 2f;

    [Header("Groundcheck Settings")]
    public Transform groundCheck;
    public float groundDistance;
    public LayerMask groundMask;

    bool isGrounded;
    bool wallCollision;

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundDistance, groundMask);

        float x = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(x * speed, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
        else if (Input.GetButtonDown("Jump") && col.IsTouchingLayers(groundMask))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce * 1.2f);
        }
    }
}
