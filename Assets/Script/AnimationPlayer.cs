using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationPlayer : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator animator;
    public PlayerMovement pvm;
    public JumpBehavior jb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("MoveSpeed", Mathf.Abs(pvm.horizontalMove));
        JumpAnimation();
    }
    private void JumpAnimation()
    {
        if (rb.velocity.y > 1)
        {
            animator.SetBool("Jumping", true);
        }
        if (Input.GetKey("space"))
        {
            animator.SetBool("Startjump", true);
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
