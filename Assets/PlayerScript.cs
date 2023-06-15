using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    private enum PlayerDirection{ LEFT, RIGHT};

    //movement
    public float moveSpeed;
    public float maxVelocity;
    public float jumpSpeed;

    private PlayerDirection playerDirection;
    private float distToGround;
    private Rigidbody2D rb;
    private float moveVal;

    //gun
    public GameObject bullet;
    public int maxProjectiles;
    private int currentProjetiles;
    private float timeSinceLastFire;
    public float gunDelayTime;
    GameObject currentGun;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        distToGround = GetComponent<BoxCollider2D>().bounds.extents.y;
        playerDirection = PlayerDirection.RIGHT;
        currentProjetiles = 0;
    }

    void Update()
    {
        if(currentGun != null && currentProjetiles <= 0)
        {
            currentGun.SetActive(true);
            currentGun = null;
        }
        timeSinceLastFire += Time.deltaTime;
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
        if(moveVal < 0 )
        {
            playerDirection = PlayerDirection.LEFT;
        }
        else
        {
            playerDirection = PlayerDirection.RIGHT;
        }
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Gun") && currentGun == null)
        {
            currentGun = collision.gameObject;
            currentGun.SetActive(false);
            currentProjetiles = maxProjectiles;
        }
    }

    void OnFire()
    {
        if (currentProjetiles <= 0)
            return;

        if (timeSinceLastFire >= gunDelayTime)
        {
            timeSinceLastFire = 0;
            --currentProjetiles;
            float rotZ = 0;
            if (playerDirection == PlayerDirection.LEFT)
                rotZ = 180;

            GameObject instance = Instantiate(bullet, transform.position, Quaternion.Euler(0, 0, rotZ));
            Physics2D.IgnoreCollision(instance.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
    }
}
