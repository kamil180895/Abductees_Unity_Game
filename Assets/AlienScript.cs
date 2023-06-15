using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienScript : MonoBehaviour
{
    public float x_left_boundry;
    public float x_right_boundry;
    public float speed;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(speed, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < x_left_boundry || transform.position.x > x_right_boundry)
        {
            rb.velocity = -rb.velocity;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //jeśli kolizja z graczem to resetuj poziom
    }
}
