using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayerMovement : MonoBehaviour
{
    public Transform player;
    public Animator animator;
    public Rigidbody2D rb;
    public float runSpeed = 0f;
    public float JumpForce = 0f;
    public LayerMask LayerGroundIs;
    public bool isGrounded = false;
    public Transform GroundCheck;
    float horizontalMove = 0f;
    bool isFlip = false;

    //public LayerMask groundMask;
    public PhysicsMaterial2D bounceMat, normalMat;
    public bool canJump = true;
    public float jumpValue = 0.0f;


    void Start()
    {
        Time.timeScale = 1;
    }
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        if(jumpValue == 0.0f && isGrounded)
        {
            rb.velocity = new Vector2 (horizontalMove, rb.velocity.y);
        }

        animator.SetFloat("MoveSpeed", Mathf.Abs(horizontalMove));
        CoreMoveCode();
        Flip();
        JumpAnimation();
        AnimationOnPlatform();
        GroundChecking();

        if(Input.GetKey("space") && isGrounded && canJump)
        {
            jumpValue += 0.15f;
        }
        if(jumpValue > 0)
        {
            rb.sharedMaterial = bounceMat;
        }
        else
        {
            rb.sharedMaterial = normalMat;
        }
        if(Input.GetKeyDown("space")&& isGrounded && canJump)
        {
            rb.velocity = new Vector2(0.0f, rb.velocity.y);
        }

        if(jumpValue >= 20f && isGrounded)
        {
            float tempx = horizontalMove;
            float tempy = jumpValue;
            rb.velocity = new Vector2(tempx, tempy);
            Invoke("ResetJump", 0.2f);
        }

        if (Input.GetKeyUp("space"))
        {
            if (isGrounded)
            {
                rb.velocity =new Vector2(horizontalMove, jumpValue);
                jumpValue = 0.0f;
            }
            canJump = true;
        }

    }
    void ResetJump()
    {
        canJump = false;
        jumpValue = 0;
    }
    private void CoreMoveCode()
    {
        player.transform.localPosition += new Vector3(horizontalMove * Time.deltaTime, 0,0);
        //if(isGrounded == true && (Input.GetButtonDown("Jump")))
        //{
        //    rb.AddForce(new Vector2(0, JumpForce));
        //}
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

        //isGrounded = Physics2D.OverlapBox(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - 0.5f), new Vector2(0.9f, 0.4f), 0f, groundMask);
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
        if (Input.GetKey("space"))
        {
            animator.SetBool("Startjump",true);
        }
        if (Input.GetKeyUp("space"))
        {
            animator.SetBool("Startjump", false);
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
