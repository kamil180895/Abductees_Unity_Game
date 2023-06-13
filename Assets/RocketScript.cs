using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketScript : MonoBehaviour
{
    public float directingForceMagnitude;
    public float velocityMagnitude;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //rb.velocity = new Vector2(0f, velocityMagnitude);
        //rb.velocity = (transform.rotation * Vector3.forward) * velocityMagnitude;
        rb.velocity = transform.up.normalized * velocityMagnitude;
        Debug.Log(rb.velocity);
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        GameObject nearestPlayer = players[0];
        float minDist = (nearestPlayer.transform.position - transform.position).magnitude;
        foreach(GameObject p in players)
        {
            float dist = (p.GetComponent<Transform>().position - transform.position).magnitude;
            if (dist < minDist)
            {
                minDist = dist;
                nearestPlayer = p;
            }
        }

        Vector2 forceDirection = nearestPlayer.transform.position - transform.position;
        rb.AddForce(forceDirection.normalized * directingForceMagnitude);
        rb.velocity = rb.velocity.normalized * velocityMagnitude;

        Vector2 v = rb.velocity;
        float angle = Mathf.Atan2(v.y, v.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle + 90f, Vector3.forward);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject);
        //jeśli kolizja z graczem to resetuj poziom
    }
}
