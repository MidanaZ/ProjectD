using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayerMovement : MonoBehaviour
{
    public Transform player;
    public Animator animator;
    public Rigidbody2D rb;
    public float runSpeed = 10f;
    public float JumpForce = 10f;
    public LayerMask LayerGroundIs;
    bool isGrounded = false;
    public Transform GroundCheck;
    float horizontalMove = 0f;
    bool isFlip = false;
    void Start()
    {
        Time.timeScale = 1;
    }
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        animator.SetFloat("MoveSpeed", Mathf.Abs(horizontalMove));
        CoreMoveCode();
        Flip();
        JumpAnimation();
        AnimationOnPlatform();
        GroundChecking();
    }
    private void CoreMoveCode()
    {
        player.transform.localPosition += new Vector3(horizontalMove * Time.deltaTime, 0,0);
        if(isGrounded == true && (Input.GetButtonDown("Jump")))
        {
            rb.AddForce(new Vector2(0, JumpForce));
        }
    }
    private void GroundChecking()
    {
        isGrounded = false;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(GroundCheck.position, .2f, LayerGroundIs);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
                isGrounded = true;
            //animator.SetBool("Grounded", true);
        }
    }
    private void AnimationOnPlatform()
    {
        if(isGrounded == true)
        {
            //animator.SetBool("Grounded", true);
        }
        if (isGrounded == false)
        {
            //animator.SetBool("Grounded", false);
        }
    }
    private void  Flip()
    {
        if (horizontalMove < 0 && isFlip == false)
        {
            isFlip = true;
            transform.Rotate(0f, 180f, 0f);
        }
        if (horizontalMove > 0 && isFlip == true)
        {
            isFlip = false;
            transform.Rotate(0f, 180f, 0f);
        }
    }
    private void JumpAnimation()
    {
        if (rb.velocity.y > 1)
        {
            animator.SetBool("Jumping", true);
        }


        if (rb.velocity.y < -2)
        {
            animator.SetBool("Jumping", false);
            animator.SetBool("Falling", true);
        }
        if (rb.velocity.y > -1 && rb.velocity.y <= 5)
        {
            animator.SetBool("Jumping", false);
            animator.SetBool("Falling", false);
        }
    }
}
