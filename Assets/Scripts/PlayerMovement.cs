using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
     public float horizontal;
    public float speed;
    public float jumpingPower;
    private bool isFacingRight = true;
    public float gravity;
    public float gravityInJump;
    public bool isDead = false;
    public bool isWin = false;
    public bool isESCMenu = false;
    public Animator animator;

    [SerializeField] public Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    private void Start() 
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        animator.SetFloat("Speed", Mathf.Abs(horizontal));
        
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            
        }

        /*if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }*/

        if(IsGrounded())
        {
            Debug.Log("Jsi na zemi");
        }
        else
        {
            Debug.Log("Nejsi na zemi");
        }

        Flip();
    }

    private void FixedUpdate() 
    {
        if (rb.velocity.y < 0 && !IsGrounded())
        {
            rb.gravityScale = gravity;
        }
        else
        {
            rb.gravityScale = gravityInJump;
        }
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);    
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            if (isDead == false && isWin == false && isESCMenu == false)
            {
                isFacingRight = !isFacingRight;
                Vector3 localScale = transform.localScale;
                localScale.x *= -1f;
                transform.localScale = localScale;
            }

        }
    }
}
