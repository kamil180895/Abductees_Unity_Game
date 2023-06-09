using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public float maxVelocity;
    public float jumpSpeed;

    float distToGround;
    Rigidbody2D rb;
    float moveVal;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        distToGround = GetComponent<BoxCollider2D>().bounds.extents.y;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        rb.AddForce(Vector2.right * moveVal * moveSpeed, ForceMode2D.Force);
        rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxVelocity);
    }

    void OnMove(InputValue value)
    {
        moveVal = value.Get<float>();
        //Debug.Log(moveVal.x + ", " + moveVal.y);
    }

    void OnJump()
    {
        if (IsGrounded())
        {
            rb.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
        }
    }

    bool IsGrounded()
    {
        var ray = Physics2D.Raycast(transform.position, -Vector2.up, distToGround + 0.1f);
        Debug.Log(ray.collider != null);
        Debug.DrawRay(transform.position, -Vector2.up * (distToGround + 0.1f), Color.black, 10);
        return ray.collider != null;
    }
}
