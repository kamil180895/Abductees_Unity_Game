using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienScript : MonoBehaviour
{
    public enum Direction { Left, Right };
    public GameObject leftmost;
    public GameObject rightmost;
    public float speed = 1.0f;
    public Direction direction = Direction.Right;

    public Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rb.velocity = new Vector2((direction == Direction.Left ? -1f : 1f) * speed, 0);
        if (leftmost != null && direction == Direction.Left && transform.position.x < leftmost.transform.position.x)
        {
            direction = Direction.Right;
            gameObject.transform.localScale = new Vector3(1, 1, 1);
        }
        else if (rightmost != null && direction == Direction.Right && transform.position.x > rightmost.transform.position.x)
        {
            direction = Direction.Left;
            gameObject.transform.localScale = new Vector3(-1, 1, 1);
        }
    }
}
