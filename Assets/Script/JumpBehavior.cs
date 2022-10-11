using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpBehavior : MonoBehaviour
{
    public float JumpForce;
    public Rigidbody2D rb;
    public bool isGrounded = false;
    public Transform GroundCheck1;
    public Transform GroundCheck2;
    public LayerMask LayerGroundIs;
    public PlayerMovement playerMovementScript;
    private void Update()
    {
        Jumping();
        GroundChecking();
    }
    private void Jumping()
    {
        if(Input.GetKey("space"))
        {
            JumpForce += 0.25f;
            this.GetComponent<PlayerMovement>().enabled = false;
        }
        if(JumpForce >= 20f)
        {
            rb.velocity = new Vector2(playerMovementScript.speed / 3, JumpForce);
            rb.velocity = new Vector2(playerMovementScript.speed / 3 * -1, JumpForce);
        }
        if(Input.GetKeyUp("space"))
        {
            if(playerMovementScript.isFlip == false)
            {
                rb.velocity = new Vector2(playerMovementScript.speed/3, JumpForce);
            }
            if (playerMovementScript.isFlip == true)
            {
                rb.velocity = new Vector2(playerMovementScript.speed/3 *-1, JumpForce);
            }
            JumpForce = 0;
        }
        if(isGrounded == false)
        {
            this.GetComponent<PlayerMovement>().enabled = false;
        }
        if (isGrounded == true)
        {
            this.GetComponent<PlayerMovement>().enabled = true;
        }
    }
    private void GroundChecking()
    {
        isGrounded = false;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(GroundCheck1.position, .2f, LayerGroundIs);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
                isGrounded = true;
        }
        Collider2D[] colliders2 = Physics2D.OverlapCircleAll(GroundCheck2.position, .2f, LayerGroundIs);
        for (int i = 0; i < colliders2.Length; i++)
        {
            if (colliders2[i].gameObject != gameObject)
                isGrounded = true;
        }
    }
}
