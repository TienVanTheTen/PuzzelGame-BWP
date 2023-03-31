using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    private float horizontal;
    [SerializeField] private float speed;
    [SerializeField] private float jumpingPower;
    private Rigidbody2D rb;
    private GameObject objectGroundCheck;
    private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    public Animator animator;

    private const string HORIZONTAL_AXIS = "Horizontal";
    private const string JUMPING_KEY = "Jump";

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
        JumpAnimation();
       
        //get input walking
        horizontal = Input.GetAxisRaw(HORIZONTAL_AXIS);
        Flip();


        //animation
        animator.SetFloat("Speed", Mathf.Abs( horizontal));
        
        
        
        

    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }


    void Jumping()
    {
        //check for jump
        if (Input.GetButtonDown(JUMPING_KEY) && IsGrounded())
        {
          
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }

        if (Input.GetButtonUp(JUMPING_KEY) && rb.velocity.y > 0f)
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
        Vector3 differencePos = gameObject.transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 localScale = transform.localScale;
        localScale.x = differencePos.x >= 0 ? -1 : 1;
        transform.localScale = localScale;
    }
    void JumpAnimation()
    {
        if (IsGrounded() == false)
        {
            
            animator.SetBool("IsJumping", true);
        }
        else
        {
            animator.SetBool("IsJumping", false);
        }



    }
}
