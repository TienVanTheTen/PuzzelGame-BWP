using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontal;
    [SerializeField] private float speed;
    [SerializeField] private float jumpingPower;
    private bool isFacingRight = true;
    private Rigidbody2D rb;
    private GameObject objectGroundCheck;
    private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    private void Start()
    {
        //reference rb
        rb = GetComponent<Rigidbody2D>();

        //vul groundcheck in (reference)
        objectGroundCheck = transform.GetChild(0).gameObject;
        groundCheck = objectGroundCheck.GetComponent<Transform>();
    }


    private void Update()
    {


        Jumping();

        //get input walking
        horizontal = Input.GetAxisRaw("Horizontal");
        Flip();
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }


    void Jumping()
    {
        //check for jump
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }


    }
 

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
    private void Flip()
    {
        if (isFacingRight & horizontal < 0f || !isFacingRight & horizontal > 0f)
        {
            isFacingRight = !isFacingRight; 
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}
