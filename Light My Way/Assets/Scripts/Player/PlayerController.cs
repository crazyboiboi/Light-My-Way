using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float walkSpeed;
    public float jumpForce;
    public LayerMask groundMask;
    public Transform ground;
    public bool isGrounded;

    Rigidbody2D rb;
    bool facingRight = true;
    Animator anim;
    float groundRadius = 0.2f;
    int extraJumps;

    

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        //Reset the extra jumps to 1 only
        //The reason I hardcode the value is because I only want double jump
        if (isGrounded)
        {
            extraJumps = 1;
        }



        //Checks if player presses space and not grounded, then call Jump()
        if (Input.GetKeyDown(KeyCode.Space)  && extraJumps > 0)
        {
            Jump();
            extraJumps--;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && extraJumps == 0 && isGrounded == true)
            DoubleJump();
    }

    private void FixedUpdate()
    {
        //Checks if grounded
        isGrounded = Physics2D.OverlapCircle(ground.position, groundRadius, groundMask);

        Move();
    }


    //Function to move player character
    void Move()
    {
        //Returns value moved in the X-axis 
        float horizontalInput = Input.GetAxis("Horizontal");

        //Set player velocity
        rb.velocity = new Vector2(horizontalInput * walkSpeed, rb.velocity.y);

        //Animate our player (walk)
        anim.SetFloat("Speed", Mathf.Abs(horizontalInput));

        //Checks for input and call the FlipCharacter() function
        if (horizontalInput > 0 && !facingRight)
        {
            FlipCharacter();
        } else if (horizontalInput < 0 && facingRight)
        {
            FlipCharacter();
        }
 
    }

    //Flips the character whichever direction it is facing
    void FlipCharacter()
    {
        //Set whatever the boolean to the opposite
        facingRight = !facingRight;

        Vector3 theScale = transform.localScale;

        //This flips the sprite in the x-axis
        theScale.x *= -1;

        transform.localScale = theScale;
    }

    //Allows the character to make a jump
    void Jump()
    {
        rb.velocity = Vector2.up * jumpForce;

        //Animate our player (jump)
        anim.SetTrigger("Jump");
    }

    //Allow the player to do another jump but without animation
    void DoubleJump()
    {
        rb.velocity = Vector2.up * jumpForce;
    }



}
