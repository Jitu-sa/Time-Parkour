using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] int runspeed = 3;
    [SerializeField] float jumpForce = 10f;

    Rigidbody2D rb;
    Animator animator;
    bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Stop the run animation when no movement keys are pressed
        if (isGrounded && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            animator.SetBool("Run", false);
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            animator.SetBool("Jump", false); // Stop jump animation when landing
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    public void Left_Movement()
    {
        transform.rotation = Quaternion.Euler(0, 180, 0);
        transform.Translate(Vector2.right * Time.deltaTime * runspeed);

        if (isGrounded)
            animator.SetBool("Run", true);
    }

    public void Right_Movement()
    {
        transform.rotation = Quaternion.Euler(0, 0, 0);
        transform.Translate(Vector2.right * Time.deltaTime * runspeed);

        if (isGrounded)
            animator.SetBool("Run", true);
    }

    public void Jump()
    {
        if (isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            animator.SetBool("Jump", true);
        }
    }
}
