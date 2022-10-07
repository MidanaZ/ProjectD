using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Collider2D Collision;
    public float speed;

    private float horizontalMove;
    public bool isFlip = false;
    private void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * speed;
        CoreMoveCode();
        Flip();
    }
    private void CoreMoveCode()
    {
        transform.localPosition += new Vector3(horizontalMove * Time.deltaTime, 0, 0);
    }
    private void Flip()
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
}
