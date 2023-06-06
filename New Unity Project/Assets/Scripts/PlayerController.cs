using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using UnityEditor.Rendering;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int speed = 10;
    private bool isFacingRight = true;
    public Rigidbody2D rb;
    public Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

    }

    private void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        animator.SetFloat("Horizontal", horizontalInput);
        float verticalInput = Input.GetAxis("Vertical");
        animator.SetFloat("Vertical", verticalInput);


        Vector2 movement = new Vector2(horizontalInput, verticalInput);

        rb.velocity = movement * speed;

        if (horizontalInput > 0 && !isFacingRight || horizontalInput < 0 && isFacingRight)
        {
            Flip();
        }
        

        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 20;
        }
        else if (Input.GetKey(KeyCode.LeftControl))
        {
            speed = 5;
            animator.SetBool("Sneak", true);
        }
        else
        {
            speed = 10;
            animator.SetBool("Sneak", false);
        }

        
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.Rotate(0f, 180f, 0f);
    }
}
