using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;




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
    public int currentProjetiles;
    private float timeSinceLastFire;
    public float gunDelayTime;
    GameObject currentGun;
    
    //animation
    public Animator animator;
    public bool isBlue;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        distToGround = GetComponent<BoxCollider2D>().bounds.extents.y;
        playerDirection = PlayerDirection.RIGHT;
        currentProjetiles = 0;
        animator = GetComponent<Animator>();
        animator.SetBool("IsBlue", isBlue);
    }

    private void Awake()
    {
        GetComponent<PlayerInput>().SwitchCurrentControlScheme("Keyboard", Keyboard.current);
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Wall"), LayerMask.NameToLayer("Wall"));
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
        if (moveVal < 0 )
        {
            playerDirection = PlayerDirection.LEFT;
            animator.SetBool("IsMoving", true);
            transform.localScale = new Vector2(-1, 1);
        }
        else if (moveVal > 0)
        {
            playerDirection = PlayerDirection.RIGHT;
            animator.SetBool("IsMoving", true);
            transform.localScale = new Vector2(1, 1);
        }
        else
        {
            animator.SetBool("IsMoving", false);
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
        BoxCollider2D collider = GetComponent<BoxCollider2D>();
        float y = transform.position.y;
        float x = transform.position.x;
        Vector2 middle = new Vector2(x, y);
        Vector2 left = new Vector2(x - collider.bounds.extents.x, y);
        Vector2 right = new Vector2(x + collider.bounds.extents.x, y);
        collider.enabled = false;
        RaycastHit2D ray = Physics2D.Raycast(middle, -Vector2.up, distToGround + 0.1f);
        if (ray.collider != null)
        {
            collider.enabled = true;
            return true;
        }
        ray = Physics2D.Raycast(left, -Vector2.up, distToGround + 0.1f);
        if (ray.collider != null)
        {         
            collider.enabled = true;
            return true;
        }
        ray = Physics2D.Raycast(right, -Vector2.up, distToGround + 0.1f);
        if (ray.collider != null)
        {
            collider.enabled = true;
            return true;
        }
        collider.enabled = true;
        return false;
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

    void OnUse()
    {
        GameObject[] usables = GameObject.FindGameObjectsWithTag("Usable");
        GameObject nearestUsable = usables[0];
        float minDist = (nearestUsable.transform.position - transform.position).magnitude;
        foreach (GameObject p in usables)
        {
            float dist = (p.GetComponent<Transform>().position - transform.position).magnitude;
            if (dist < minDist)
            {
                minDist = dist;
                nearestUsable = p;
            }
        }

        if(minDist <= nearestUsable.GetComponent<LeverScript>().maxDistance)
            nearestUsable.GetComponent<LeverScript>().SwitchLever();
    }
}
