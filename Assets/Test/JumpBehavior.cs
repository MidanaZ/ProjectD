using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpBehavior : MonoBehaviour
{
    public float JumpForce;
    public Rigidbody2D rb;
    public bool isGrounded = false;
    public Transform GroundCheck;
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
            JumpForce += 0.15f;
            this.GetComponent<PlayerMovement>().enabled = false;
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
        Collider2D[] colliders = Physics2D.OverlapCircleAll(GroundCheck.position, .2f, LayerGroundIs);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
                isGrounded = true;
        }
    }
}
